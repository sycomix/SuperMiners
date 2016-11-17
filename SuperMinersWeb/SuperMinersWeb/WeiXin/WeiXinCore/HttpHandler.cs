﻿using SuperMinersWeb.Utility;
using SuperMinersWeb.WeiXin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;

namespace SuperMinersWeb.WeiXin.WeiXinCore
{
    public static class HttpHandler
    {
        //public static event Action<HttpGetReturnModel> AsyncGetCallback;

        public static bool AsyncGet<T>(string url, Action<HttpGetReturnModel> callback)
        {

            //{
            //"access_token":"bG_m-XbByI8L6MzdjPKYWVISx1JydfbZquy2x9q5Be1evUU_6bxkPrLvxHKW_wv7h-n_Z0s5SxQAHA5xAmQ4pdTMg5-iYTX5cUYro56x_k0",
            //"expires_in":7200,
            //"refresh_token":"Spe2THkGdS3La8kv_zolsuuMmv1-wh74qpQNJgmABvkJp-9WKl9sRDOUzPSrXyI8gM7G11VhvK1lEMDSKARTrBqivM1qni3l9ulRT8Gw6H8",
            //"openid":"o3_dVweaHgdE-Fl5jlMpk80E3lIY",
            //"scope":"snsapi_userinfo"}

            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                myReq.ContentType = "get";
                myReq.BeginGetResponse(o =>
                {
                    HttpGetReturnModel value = new HttpGetReturnModel();
                    try
                    {
                        if (o.IsCompleted)
                        {
                            var response = (HttpWebResponse)myReq.EndGetResponse(o);
                            using (Stream stream = response.GetResponseStream())
                            {
                                if (stream != null)
                                {
                                    StreamReader reader = new StreamReader(stream);
                                    string getString = reader.ReadToEnd();
                                    LogHelper.Instance.AddInfoLog("WeiXin Server Response: " + getString);
                                    if (getString.Contains("errcode"))
                                    {
                                        DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(ErrorModel));
                                        ErrorModel err = (ErrorModel)deseralizer.ReadObject(stream);// //反序列化ReadObject
                                        value.ResponseError = err;
                                    }
                                    else
                                    {
                                        DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(T));
                                        T model = (T)deseralizer.ReadObject(stream);// //反序列化ReadObject
                                        value.ResponseResult = model;
                                    }
                                    reader.Close();
                                    reader.Dispose();
                                }
                            }

                            if (callback != null)
                            {
                                callback(value);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        LogHelper.Instance.AddInfoLog("HttpHandler AsyncGet Response Exception:" + exc);
                        value.Exception = exc;
                        if (callback != null)
                        {
                            callback(value);
                        }
                    }
                }, null);

                return true;
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddInfoLog("HttpHandler AsyncGet Request Exception:" + exc);
                return false;
            }
        }
    }
}