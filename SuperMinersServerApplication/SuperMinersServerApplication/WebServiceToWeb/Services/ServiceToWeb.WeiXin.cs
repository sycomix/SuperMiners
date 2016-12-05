﻿using MetaData;
using MetaData.Trade;
using MetaData.User;
using SuperMinersServerApplication.Controller;
using SuperMinersServerApplication.Controller.Trade;
using SuperMinersServerApplication.Utility;
using SuperMinersServerApplication.WebServiceToWeb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.WebServiceToWeb.Services
{
    public partial class ServiceToWeb : IServiceToWeb
    {

        public string GetAccessToken()
        {
            try
            {
                return App.TokenController.GetWeiXinAccessToken();
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("ServiceToWeb.WeiXin.GetAccessToken Exception. ", exc);

                return "";
            }
        }

        /// <summary>
        /// 绑定加登录
        /// </summary>
        /// <param name="wxUserOpenID"></param>
        /// <param name="wxUserName"></param>
        /// <param name="xlUserName"></param>
        /// <param name="xlUserPassword"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int BindWeiXinUser(string wxUserOpenID, string wxUserName, string xlUserName, string xlUserPassword, string ip)
        {
            try
            {
                int userID = DBProvider.UserDBProvider.JudgeWeiXinOpenIDorXLUserName_Binded(wxUserOpenID, xlUserName);
                if (userID > 0)
                {
                    return OperResult.RESULTCODE_WEIXIN_USERBINDEDBYOTHER;
                }

                return InnerBindWeixinUser(wxUserOpenID, wxUserName, xlUserName, xlUserPassword, ip);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。绑定玩家信息异常。 wxUserOpenID: " + wxUserOpenID + "，绑定用户：[" + xlUserName + "]失败.", exc);
                return OperResult.RESULTCODE_EXCEPTION;
            }
        }

        private int InnerBindWeixinUser(string wxUserOpenID, string wxUserName, string xlUserName, string xlUserPassword, string ip)
        {
            PlayerInfo player = DBProvider.UserDBProvider.GetPlayer(xlUserName);
            if (player == null)
            {
                return OperResult.RESULTCODE_USER_NOT_EXIST;
            }
            if (xlUserPassword != player.SimpleInfo.Password)
            {
                return OperResult.RESULTCODE_USER_NOT_EXIST;
            }

            int result = PlayerController.Instance.BindWeiXinUser(wxUserOpenID, player);
            if (result == OperResult.RESULTCODE_TRUE)
            {
                LogHelper.Instance.AddInfoLog("wxUserOpenID: " + wxUserOpenID + "，成功绑定用户：" + xlUserName);
                if (player.SimpleInfo.LockedLogin)
                {
                    return OperResult.RESULTCODE_USER_IS_LOCKED;
                }

                string mac = "weixin";
                player.SimpleInfo.LastLoginIP = ip;
                player.SimpleInfo.LastLoginMac = mac;
                PlayerController.Instance.WeiXinLoginPlayer(wxUserOpenID, player);
                LogHelper.Instance.AddInfoLog("微信玩家 [" + wxUserName + "] 登录用户[" + player.SimpleInfo.UserName + "]成功, IP=" + ip + ", Mac=" + mac);
                result = OperResult.RESULTCODE_TRUE;
            }

            return result;
        }

        /// <summary>
        /// 注册加绑定  RESULTCODE_REGISTER_USERNAME_LENGTH_SHORT; RESULTCODE_FALSE; RESULTCODE_REGISTER_USERNAME_EXIST; RESULTCODE_TRUE; RESULTCODE_EXCEPTION
        /// </summary>
        /// <param name="clientIP"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="qq"></param>
        /// <param name="invitationCode"></param>
        /// <returns></returns>
        public int RegisterUserFromWeiXin(string wxUserOpenID, string wxUserName, string clientIP, string userName, string nickName, string password,
            string alipayAccount, string alipayRealName, string IDCardNo, string email, string qq, string invitationCode)
        {
            try
            {
                if (string.IsNullOrEmpty(wxUserOpenID))
                {
                    return OperResult.RESULTCODE_PARAM_INVALID;
                }
                if (string.IsNullOrEmpty(wxUserName))
                {
                    return OperResult.RESULTCODE_PARAM_INVALID;
                }

                var player = DBProvider.UserDBProvider.GetPlayerByWeiXinOpenID(wxUserOpenID);
                if (player != null)
                {
                    return OperResult.RESULTCODE_WEXIN_REGISTER_OPENID_EXIST;
                }

                if (string.IsNullOrEmpty(userName) || userName.Length < 3)
                {
                    return OperResult.RESULTCODE_REGISTER_USERNAME_LENGTH_SHORT;
                }
                if (string.IsNullOrEmpty(password))
                {
                    return OperResult.RESULTCODE_PARAM_INVALID;
                }
                //if (string.IsNullOrEmpty(alipayAccount))
                //{
                //    return OperResult.RESULTCODE_PARAM_INVALID;
                //}
                //if (string.IsNullOrEmpty(alipayRealName))
                //{
                //    return OperResult.RESULTCODE_PARAM_INVALID;
                //}
                //if (string.IsNullOrEmpty(IDCardNo))
                //{
                //    return OperResult.RESULTCODE_PARAM_INVALID;
                //}
                //if (string.IsNullOrEmpty(email))
                //{
                //    return OperResult.RESULTCODE_PARAM_INVALID;
                //}
                int result = PlayerController.Instance.RegisterUser(clientIP, userName, nickName, password, alipayAccount, alipayRealName, IDCardNo, email, qq, invitationCode);
                if (result == OperResult.RESULTCODE_TRUE)
                {
                    result = InnerBindWeixinUser(wxUserOpenID, wxUserName, userName, password, clientIP);
                }

                return result;
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("WeiXinRegisterUser Exception. wxUserOpenID: " + wxUserOpenID + ";wxUserName:"+ wxUserName + ";clientIP:" + clientIP + ";userName: " + userName + ";password: " + password
                                    + "alipayAccount:" + alipayAccount + ";alipayRealName:" + alipayRealName + ";IDCardNo:" + IDCardNo + ";email: " + email + ";qq: " + qq, exc);

                return OperResult.RESULTCODE_EXCEPTION;
            }
        }

        public int WeiXinLogin(string wxUserOpenID, string wxUserName, string ip)
        {
            string mac = "weixin";
            try
            {
                PlayerInfo player = DBProvider.UserDBProvider.GetPlayerByWeiXinOpenID(wxUserOpenID);
                if (player == null)
                {
                    return OperResult.RESULTCODE_USER_NOT_EXIST;
                }
                if (player.SimpleInfo.LockedLogin)
                {
                    return OperResult.RESULTCODE_USER_IS_LOCKED;
                }
                
                player.SimpleInfo.LastLoginIP = ip;
                player.SimpleInfo.LastLoginMac = mac;
                PlayerController.Instance.WeiXinLoginPlayer(wxUserOpenID, player);

                //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                //rsa.FromXmlString(key);

                //token = Guid.NewGuid().ToString();
                //RSAProvider.SetRSA(token, rsa);
                //RSAProvider.LoadRSA(token);

                //ClientManager.AddClient(userName, token);
                //lock (this._callbackDicLocker)
                //{
                //    this._callbackDic[token] = new Queue<CallbackInfo>();
                //}

                LogHelper.Instance.AddInfoLog("微信玩家 [" + wxUserName + "] 登录用户[" + player .SimpleInfo.UserName+ "]成功, IP=" + ip + ", Mac=" + mac);

                return OperResult.RESULTCODE_TRUE;
            }
            catch (Exception ex)
            {
                LogHelper.Instance.AddErrorLog("微信玩家 [" + wxUserName + "] 登录失败, IP=" + ip + ", Mac=" + mac, ex);
                return OperResult.RESULTCODE_EXCEPTION;
            }
            //if (!string.IsNullOrEmpty(token))
            //{
            //    PlayerActionController.Instance.AddLog(userName, MetaData.ActionLog.ActionType.Login, 1);
            //    new Thread(new ParameterizedThreadStart(o =>
            //    {
            //        this.LogedIn(o.ToString());
            //    })).Start(token);
            //}

            //return token;
        }


        public MetaData.User.PlayerInfo GetPlayerByWeiXinOpenID(string openid)
        {
            try
            {
                return PlayerController.Instance.GetPlayerByWeiXinOpenID(openid);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。ServiceToWeb.WeiXin.GetPlayerByWeiXinOpenID Exception openid=" + openid, exc);
                return null;
            }
        }

        public MetaData.User.PlayerInfo GetPlayerByXLUserName(string xlUserName)
        {
            try
            {
                return PlayerController.Instance.GetPlayerInfo(xlUserName);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。ServiceToWeb.WeiXin.GetPlayerByXLUserName Exception xlUserName=" + xlUserName, exc);
                return null;
            }
        }

        public int GatherStones(string userName, decimal stones)
        {
            try
            {
                return PlayerController.Instance.GatherStones(userName, stones);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。玩家[" + userName + "] 收取矿石异常，矿石数为:" + stones, exc);
                return 0;
            }
        }

        public int BuyMiner(string userName, int minersCount)
        {
            try
            {
                return PlayerController.Instance.BuyMiner(userName, minersCount);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。玩家[" + userName + "] 购买矿工异常，购买矿工数为:" + minersCount, exc);
                return 0;
            }
        }

        public TradeOperResult BuyMine(string userName, int minesCount, PayType payType)
        {
            TradeOperResult result = new TradeOperResult();
            try
            {
                result.PayType = (int)payType;
                if (minesCount <= 0)
                {
                    result.ResultCode = OperResult.RESULTCODE_PARAM_INVALID;
                    return result;
                }

                return OrderController.Instance.MineOrderController.BuyMine(userName, minesCount, (int)payType);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。玩家[" + userName + "] 购买矿山异常，购买矿山数为:" + minesCount + ",支付类型为:" + ((PayType)payType).ToString(), exc);
                result.ResultCode = OperResult.RESULTCODE_EXCEPTION;
                return result;
            }
        }

        public TradeOperResult RechargeGoldCoin(string userName, int goldCoinCount, PayType payType)
        {
            try
            {
                TradeOperResult result = new TradeOperResult();
                result.PayType = (int)payType;
                result.TradeType = (int)AlipayTradeInType.BuyGoldCoin;

                int valueRMB = (int)Math.Ceiling(goldCoinCount / GlobalConfig.GameConfig.RMB_GoldCoin);
                return OrderController.Instance.GoldCoinOrderController.RechargeGoldCoin(userName, valueRMB, goldCoinCount, (int)payType);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。玩家[" + userName + "] 金币充值异常，充值金币数为:" + goldCoinCount + ",支付类型为:" + (payType).ToString(), exc);
                return null;
            }
        }

        public int WithdrawRMB(string userName, int getRMBCount)
        {
            try
            {
                if (getRMBCount <= 0)
                {
                    return OperResult.RESULTCODE_FALSE;
                }

                return PlayerController.Instance.CreateWithdrawRMB(userName, getRMBCount);
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("微信端。玩家[" + userName + "] 灵币提现异常，提现灵币为:" + getRMBCount, exc);
                return OperResult.RESULTCODE_EXCEPTION;
            }
        }
    }
}
