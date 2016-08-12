﻿using DataBaseProvider;
using MetaData;
using MetaData.Trade;
using MetaData.User;
using SuperMinersServerApplication.Controller;
using SuperMinersServerApplication.Controller.Trade;
using SuperMinersServerApplication.Encoder;
using SuperMinersServerApplication.Utility;
using SuperMinersServerApplication.WebService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.WebService.Services
{
    public partial class ServiceToClient : IServiceToClient
    {
        #region IServiceToClient Members
        
        /// <summary>
        /// 0表示成功；-1表示查询不到该用户; -2表示该用户不在线；-3表示异常；1表示本次出售的矿石数超出可出售的矿石数；2表示本次出售的矿石不足支付最低手续费；
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userName"></param>
        /// <param name="sellStonesCount"></param>
        /// <returns></returns>
        public int SellStone(string token, string userName, int sellStonesCount)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                if (ClientManager.GetClientUserName(token) != userName)
                {
                    return OperResult.RESULTCODE_USER_NOT_EXIST;
                }
                if (sellStonesCount <= 0)
                {
                    return OperResult.RESULTCODE_EXCEPTION;
                }

                SellStonesOrder order = null;
                CustomerMySqlTransaction trans = MyDBHelper.Instance.CreateTrans();
                try
                {
                    order = OrderController.Instance.StoneOrderController.CreateSellOrder(userName, sellStonesCount);
                    if (order.ValueRMB <= 0)
                    {
                        return OperResult.RESULTCODE_USER_OFFLINE;
                    }

                    int result = PlayerController.Instance.SellStones(order, trans);
                    if (result != OperResult.RESULTCODE_TRUE)
                    {
                        trans.Rollback();
                        return result;
                    }
                    OrderController.Instance.StoneOrderController.AddSellOrder(order, trans);
                    trans.Commit();
                    PlayerActionController.Instance.AddLog(userName, MetaData.ActionLog.ActionType.SellStone, sellStonesCount);

                    return result;
                }
                catch (Exception exc)
                {
                    string errMessage = "Add Sell Order Exception: ";
                    if (order == null)
                    {
                        errMessage += " (User Error) UserName:" + userName;
                    }
                    else
                    {
                        errMessage += " (Order Error) Order:" + order.ToString();
                    }

                    try
                    {
                        trans.Rollback();
                        PlayerController.Instance.RollbackUserFromDB(userName);
                        if (order != null)
                        {
                            OrderController.Instance.StoneOrderController.ClearSellStonesOrder(order);
                        }
                        LogHelper.Instance.AddErrorLog(errMessage, exc);
                    }
                    catch (Exception ee)
                    {
                        LogHelper.Instance.AddErrorLog("Add Sell Order Rollback Exception: " + errMessage, ee);
                    }

                    return OperResult.RESULTCODE_EXCEPTION;
                }
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 0表示成功；1表示操作异常；-1表示查询不到该用户；-2表示订单号为空；-3表示订单号不存在；-4表示非本人订单；-5表示订单已被锁定 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userName"></param>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public int CancelSellStone(string token, string userName, string orderNumber)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                if (string.IsNullOrEmpty(orderNumber))
                {
                    return -2;
                }
                if (ClientManager.GetClientUserName(token) != userName)
                {
                    return -1;
                }

                try
                {
                    return OrderController.Instance.StoneOrderController.CancelSellOrder(userName, orderNumber);
                }
                catch (Exception exc)
                {
                    string errMessage = "UserName: " + userName + " Cancel Sell Order: " + orderNumber + " Exception.";
                    LogHelper.Instance.AddErrorLog(errMessage, exc);
                    return 1;
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public LockSellStonesOrder GetOrderLockedBySelf(string token)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                string userName = ClientManager.GetClientUserName(token);
                return OrderController.Instance.StoneOrderController.GetLockedOrderByUserName(userName);
            }
            else
            {
                throw new Exception();
            }
        }

        public SellStonesOrder[] GetAllNotFinishedSellOrders(string token)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                return OrderController.Instance.StoneOrderController.GetSellOrders();
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userName"></param>
        /// <param name="buyStonesCount"></param>
        /// <returns></returns>
        public LockSellStonesOrder AutoMatchLockSellStone(string token, string userName, int buyStonesCount)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                if (ClientManager.GetClientUserName(token) != userName)
                {
                    return null;
                }

                if (OrderController.Instance.StoneOrderController.CheckUserHasNotPayOrder(userName))
                {
                    return null;
                }

                return OrderController.Instance.StoneOrderController.AutoMatchLockSellStone(userName, buyStonesCount);
            }
            else
            {
                throw new Exception();
            }
        }

        public LockSellStonesOrder LockSellStone(string token, string userName, string orderNumber)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                if (ClientManager.GetClientUserName(token) != userName)
                {
                    return null;
                }

                if (OrderController.Instance.StoneOrderController.CheckUserHasNotPayOrder(userName))
                {
                    return null;
                }

                return OrderController.Instance.StoneOrderController.LockSellStone(userName, orderNumber);
            }
            else
            {
                throw new Exception();
            }
        }

        public bool CheckUserHasNotPayOrder(string token)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                string userName = ClientManager.GetClientUserName(token);
                return OrderController.Instance.StoneOrderController.CheckUserHasNotPayOrder(userName);
            }
            else
            {
                throw new Exception();
            }
        }

        public bool ReleaseLockOrder(string token, string orderNumber)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                string userName = ClientManager.GetClientUserName(token);
                return OrderController.Instance.StoneOrderController.ReleaseLockSellOrder(orderNumber);
            }
            else
            {
                throw new Exception();
            }
        }

        public bool PayStoneOrder(string token, string orderNumber, float rmb, int payType)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                string userName = ClientManager.GetClientUserName(token);
                if (!string.IsNullOrEmpty(userName))
                {
                    return false;
                }

                PlayerInfo player = PlayerController.Instance.GetPlayerInfo(userName);
                if (player == null)
                {
                    return false;
                }

                return OrderController.Instance.StoneOrderController.PayStoneTrade(player, orderNumber, true, rmb);
            }
            else
            {
                throw new Exception();
            }
        }

        public SellStonesOrder[] SearchUserSellStoneOrders(string token, string userName, int beginYear, int beginMonth, int beginDay, int endYear, int endMonth, int endDay)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                if (ClientManager.GetClientUserName(token) != userName)
                {
                    return null;
                }

                DateTime beginTime = new DateTime(beginYear, beginMonth, beginDay);
                DateTime endTime = new DateTime(endYear, endMonth, endDay);
                return DBProvider.StoneOrderDBProvider.GetSellOrderList(null, userName, beginTime, endTime.AddDays(1));
            }
            else
            {
                throw new Exception();
            }
        }

        public BuyStonesOrder[] SearchUserBuyStoneOrders(string token, string userName, int beginYear, int beginMonth, int beginDay, int endYear, int endMonth, int endDay)
        {
#if Delay

            Thread.Sleep(5000);

#endif

            if (RSAProvider.LoadRSA(token))
            {
                if (ClientManager.GetClientUserName(token) != userName)
                {
                    return null;
                }

                DateTime beginTime = new DateTime(beginYear, beginMonth, beginDay);
                DateTime endTime = new DateTime(endYear, endMonth, endDay);
                return DBProvider.StoneOrderDBProvider.GetBuyStonesOrderList(userName, beginTime, endTime.AddDays(1));
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion
    }
}
