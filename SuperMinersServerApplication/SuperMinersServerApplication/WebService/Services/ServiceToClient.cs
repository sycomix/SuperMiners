﻿using MetaData.User;
using SuperMinersServerApplication.Controller;
using SuperMinersServerApplication.Encoder;
using SuperMinersServerApplication.Model;
using SuperMinersServerApplication.WebService.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.WebService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public partial class ServiceToClient : IServiceToClient, IDisposable
    {
        private Dictionary<string, Queue<CallbackInfo>> _callbackDic = new Dictionary<string, Queue<CallbackInfo>>();
        private readonly object _callbackDicLocker = new object();

        public ServiceToClient()
        {
            this._userStateCheck.Elapsed += new System.Timers.ElapsedEventHandler(_userStateCheck_Elapsed);
            this._userStateCheck.Start();

            PlayerController.Instance.PlayerInfoChanged += Instance_PlayerInfoChanged;
            PlayerActionController.Instance.PlayerActionAdded += Instance_PlayerActionAdded;
        }

        void Instance_PlayerActionAdded()
        {
            var allClients = ClientManager.AllClients;
            foreach (var client in allClients)
            {
                new Thread(new ParameterizedThreadStart(o =>
                {
                    this.SendPlayerActionLog(o.ToString());
                })).Start(client.Token);
            }
        }

        void Instance_PlayerInfoChanged(PlayerInfo player)
        {
            string token = ClientManager.GetToken(player.SimpleInfo.UserName);
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            new Thread(new ParameterizedThreadStart(o =>
            {
                this.PlayerInfoChanged(token);
            })).Start();
        }

        public Stream GetClientAccessPolicy()
        {
            RSAProvider.LoadNoRSA();

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";

            const string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                                    <access-policy>
                                                        <cross-domain-access>
                                                            <policy>
                                                                <allow-from http-request-headers=""*"">
                                                                    <domain uri=""*""/>
                                                                </allow-from>
                                                                <grant-to>
                                                                    <resource path=""/"" include-subpaths=""true""/>
                                                                </grant-to>
                                                            </policy>
                                                        </cross-domain-access>
                                                    </access-policy>";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        public Stream GetCrossDomain()
        {
            RSAProvider.LoadNoRSA();

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";

            const string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                                    <cross-domain-policy>
                                                      <allow-access-from domain=""*"" />
                                                    </cross-domain-policy>";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        public CallbackInfo Callback(string token)
        {
            if (RSAProvider.LoadRSA(token))
            {
                bool valid = false;
                Queue<CallbackInfo> queue = null;
                DateTime start = DateTime.Now;
                while (!valid)
                {
                    if (!App.ServiceToRun.IsStarted)
                    {
                        throw new Exception();
                    }

                    lock (this._callbackDicLocker)
                    {
                        if (this._callbackDic.TryGetValue(token, out queue))
                        {
                            lock (queue)
                            {
                                valid = queue.Count > 0;
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }

                    if (!valid)
                    {
                        if ((DateTime.Now - start).TotalSeconds >= GlobalData.KeepAliveTimeSeconds)
                        {
                            return new CallbackInfo()
                            {
                                MethodName = String.Empty
                            };
                        }

                        Thread.Sleep(100);
                    }
                }

                if (!valid)
                {
                    throw new Exception();
                }

                lock (queue)
                {
                    return queue.Dequeue();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public string GetTimeZone(string token)
        {
            if (RSAProvider.LoadRSA(token))
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Append("(GMT");
                    TimeSpan ts = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                    if (ts.TotalSeconds == 0)
                    {
                        sb.Append(") ");
                    }
                    else
                    {
                        if (ts.TotalSeconds > 0)
                        {
                            sb.Append("+");
                        }

                        sb.Append(ts.Hours.ToString("d2"));
                        sb.Append(":");
                        sb.Append(ts.Minutes.ToString("d2"));
                        sb.Append(") ");
                    }
                    sb.Append(TimeZone.CurrentTimeZone.StandardName);
                }
                catch (Exception e)
                {
                    return string.Empty;
                }

                return sb.ToString();
            }
            else
            {
                throw new Exception();
            }
        }

        private void InvokeCallback(string token, string methodName, params object[] paras)
        {
            Queue<CallbackInfo> queue;
            lock (this._callbackDicLocker)
            {
                if (!this._callbackDic.TryGetValue(token, out queue))
                {
                    return;
                }
            }

            lock (queue)
            {
                queue.Enqueue(new CallbackInfo()
                {
                    MethodName = methodName,
                    Parameters = (paras == null) ? null : paras.Select(p =>
                    {
                        Type type = p.GetType();
                        DataContractJsonSerializer s = new DataContractJsonSerializer(type, GetKnownTypes(type));
                        using (MemoryStream ms = new MemoryStream())
                        {
                            s.WriteObject(ms, p);
                            return Encoding.UTF8.GetString(ms.ToArray()).Trim();
                        }
                    }).ToArray()
                });
            }
        }

        private static Type[] GetKnownTypes(Type type)
        {
            Func<MemberInfo, Type, bool> hasAttribute = (info, attrType) =>
            {
                var typeAttrs = info.GetCustomAttributes(attrType, false);
                if ((typeAttrs != null) && (typeAttrs.Length > 0))
                {
                    return true;
                }

                return false;
            };

            List<Type> typeList = new List<Type>();

            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                if (hasAttribute(prop, typeof(DataMemberAttribute)))
                {
                    if (!typeList.Contains(prop.PropertyType))
                    {
                        typeList.Add(prop.PropertyType);
                    }
                }
            }

            return typeList.Count > 0 ? typeList.ToArray() : null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._userStateCheck.Dispose();
        }

        #endregion
    }
}
