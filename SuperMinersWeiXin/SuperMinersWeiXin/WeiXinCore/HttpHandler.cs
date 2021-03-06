﻿using SuperMinersWeiXin.Model;
using SuperMinersWeiXin.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace SuperMinersWeiXin.WeiXinCore
{
    public static class HttpHandler
    {
        //public static event Action<HttpGetReturnModel> AsyncGetCallback;

        public static bool AsyncGet(string url)
        {
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                myReq.ContentType = "get";
                myReq.BeginGetResponse(o =>
                {
                }, null);

                return true;
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddInfoLog("HttpHandler AsyncGet Request Exception:" + exc);
                return false;
            }
        }

        public static HttpGetReturnModel SyncGet<T>(string url)
        {

            //{
            //"access_token":"bG_m-XbByI8L6MzdjPKYWVISx1JydfbZquy2x9q5Be1evUU_6bxkPrLvxHKW_wv7h-n_Z0s5SxQAHA5xAmQ4pdTMg5-iYTX5cUYro56x_k0",
            //"expires_in":7200,
            //"refresh_token":"Spe2THkGdS3La8kv_zolsuuMmv1-wh74qpQNJgmABvkJp-9WKl9sRDOUzPSrXyI8gM7G11VhvK1lEMDSKARTrBqivM1qni3l9ulRT8Gw6H8",
            //"openid":"o3_dVweaHgdE-Fl5jlMpk80E3lIY",
            //"scope":"snsapi_userinfo"}

            HttpGetReturnModel value = new HttpGetReturnModel();

            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                myReq.ContentType = "get";
                var response = myReq.GetResponse() as HttpWebResponse;
                string getString = "";
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        StreamReader reader = new StreamReader(stream);
                        getString = reader.ReadToEnd();
                        reader.Close();
                        reader.Dispose();

                    }
                }

                LogHelper.Instance.AddInfoLog("WeiXin Server Response: " + getString);

                if (!string.IsNullOrEmpty(getString))
                {
                    using (MemoryStream memstream = new MemoryStream())
                    {
                        StreamWriter writer = new StreamWriter(memstream);
                        writer.Write(getString);
                        writer.Flush();
                        memstream.Position = 0;
                        if (getString.Contains("errcode"))
                        {
                            DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(ErrorModel));
                            ErrorModel err = (ErrorModel)deseralizer.ReadObject(memstream);// //反序列化ReadObject
                            value.ResponseError = err;
                        }
                        else
                        {
                            DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(T));
                            T model = (T)deseralizer.ReadObject(memstream);// //反序列化ReadObject
                            value.ResponseResult = model;
                        }
                    }
                }

                //if (callback != null)
                //{
                //    callback(value);
                //}

                return value;
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddInfoLog("HttpHandler AsyncGet Request Exception:" + exc);
                value.Exception = exc;
                return value;
            }
        }


        public static string SyncPost(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...  
            try
            {
                // 设置参数  
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                //Response.Write(content);
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
            finally
            {
                if (outstream != null)
                {
                    outstream.Close();
                    outstream.Dispose();
                }
                if (sr != null)
                {
                    sr.Close();
                }
                if (instream != null)
                {
                    instream.Close();
                    instream.Dispose();
                }
            }
        }  
    }
}