﻿using DataBaseProvider;
using MetaData;
using MetaData.Trade;
using SuperMinersServerApplication.Controller.Trade;
using SuperMinersServerApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersServerApplication.Controller
{
    class StoneOrderRunnable
    {
        private SellStonesOrder _sellOrder;
        private object _lock = new object();
        private LockSellStonesOrder _lockOrderObject;

        public SellStonesOrder SellOrder
        {
            get
            {
                return _sellOrder;
            }
        }

        public LockSellStonesOrder LockedOrder
        {
            get
            {
                return this._lockOrderObject;
            }
        }

        public string OrderNumber
        {
            get
            {
                return this._sellOrder.OrderNumber;
            }
        }

        public SellOrderState OrderState
        {
            get
            {
                return this._sellOrder.OrderState;
            }
        }

        public int StoneCount
        {
            get
            {
                return this._sellOrder.SellStonesCount;
            }
        }

        public decimal ValueRMB
        {
            get
            {
                return this._sellOrder.ValueRMB;
            }
        }

        public StoneOrderRunnable(SellStonesOrder sellOrder)
        {
            this._sellOrder = sellOrder;
        }

        public StoneOrderRunnable(LockSellStonesOrder lockInfo)
        {
            _lockOrderObject = lockInfo;
            this._sellOrder = lockInfo.StonesOrder;
        }

        public void UpdateLockedOrder(LockSellStonesOrder lockInfo)
        {
            _lockOrderObject = lockInfo;
            this._sellOrder = lockInfo.StonesOrder;
        }

        public string GetLockedByUserName()
        {
            return this._lockOrderObject.LockedByUserName;
        }
        
        public bool CheckBuyerName(string buyerUserName)
        {
            lock (this._lock)
            {
                if ((this._sellOrder.OrderState == SellOrderState.Lock || this._sellOrder.OrderState == SellOrderState.Exception) 
                    && this._lockOrderObject != null)
                {
                    return this._lockOrderObject.LockedByUserName == buyerUserName;
                }

                return false;
            }
        }

        public int CheckStoneOrder_BeforeBuy(string orderNumber, string buyerUserName, decimal rmb)
        {
            int result = OperResult.RESULTCODE_TRUE;
            if (!this.CheckBuyerName(buyerUserName))
            {
                result = OperResult.RESULTCODE_ORDER_NOT_BELONE_CURRENT_PLAYER;
                LogHelper.Instance.AddInfoLog("支付订单时错误，此订单不是被当前玩家锁定。 orderNumber: " + orderNumber + "。 buyerUserName: " + buyerUserName + "。 rmb: " + rmb.ToString());
                return result;
            }
            if (rmb < this.ValueRMB)
            {
                result = OperResult.RESULTCODE_PARAM_INVALID;
                LogHelper.Instance.AddInfoLog("支付订单时错误，玩家支付的灵币不足，无法完成订单。 orderNumber: " + orderNumber + "。 buyerUserName: " + buyerUserName + "。 rmb: " + rmb.ToString());
                return result;
            }

            return result;
        }
        
        public BuyStonesOrder Pay(CustomerMySqlTransaction trans)
        {
            lock (this._lock)
            {
                //此处暂不检查TimeOut
                BuyStonesOrder buyOrder = new BuyStonesOrder()
                {
                    StonesOrder = this._sellOrder,
                    BuyerUserName = this._lockOrderObject.LockedByUserName,
                    BuyTime = this._lockOrderObject.LockedTime,
                    AwardGoldCoin = (int)((this.ValueRMB * GlobalConfig.GameConfig.StoneBuyerAwardGoldCoinMultiple) * GlobalConfig.GameConfig.RMB_GoldCoin)
                };
                
                this._sellOrder.OrderState = SellOrderState.Finish;
                DBProvider.StoneOrderDBProvider.PayOrder(buyOrder, trans);
                DBProvider.StoneOrderDBProvider.FinishOrderLock(this._sellOrder.OrderNumber, trans);

                return buyOrder;
            }
        }

        public LockSellStonesOrder Lock(string playerUserName)
        {
            lock (this._lock)
            {
                CustomerMySqlTransaction trans = null;
                try
                {
                    if (this._lockOrderObject != null && !CheckOrderLockedTimeOut())
                    {
                        return this._lockOrderObject;
                    }

                    if (trans == null)
                    {
                        trans = MyDBHelper.Instance.CreateTrans();
                    }

                    this._lockOrderObject = new LockSellStonesOrder()
                    {
                        StonesOrder = this._sellOrder,
                        PayUrl = OrderController.Instance.CreateAlipayLink(playerUserName, this.OrderNumber, "迅灵矿石", this.ValueRMB, GlobalConfig.GameConfig.Stones_RMB + "矿石 = 1 灵币 = " + 1 / GlobalConfig.GameConfig.Yuan_RMB + "元人民币"),
                        LockedByUserName = playerUserName,
                        LockedTime = DateTime.Now,
                        OrderLockedTimeSpan = 0
                    };
                    this._sellOrder.OrderState = SellOrderState.Lock;
                    DBProvider.StoneOrderDBProvider.LockOrder(this._lockOrderObject, trans);

                    trans.Commit();

                    return this._lockOrderObject;
                }
                catch (Exception exc)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    this._sellOrder.OrderState = SellOrderState.Wait;
                    this._lockOrderObject = null;
                    LogHelper.Instance.AddErrorLog("Lock Order[" + this._sellOrder.OrderNumber + "] by User[" + playerUserName + "] Error", exc);
                    return null;
                }
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 如果订单状态为异常时，不取消锁定
        /// </summary>
        /// <returns></returns>
        public bool ReleaseLock()
        {
            lock (this._lock)
            {
                if (this._sellOrder.OrderState == SellOrderState.Exception)
                {
                    return false;
                }
                CustomerMySqlTransaction trans = null;
                try
                {
                    trans = MyDBHelper.Instance.CreateTrans();
                    DBProvider.StoneOrderDBProvider.ReleaseOrderLock(this._sellOrder.OrderNumber, trans);
                    trans.Commit();
                    this._sellOrder.OrderState = SellOrderState.Wait;
                    this._lockOrderObject = null;
                    return true;
                }
                catch (Exception exc)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    LogHelper.Instance.AddErrorLog("ReleaseLock Order[" + this._sellOrder.OrderNumber + "] Error", exc);
                    return false;
                }
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckOrderLockedTimeOut()
        {
            if (this._sellOrder.OrderState != SellOrderState.Lock || this._lockOrderObject == null)
            {
                return false;
            }


            TimeSpan span = DateTime.Now - this._lockOrderObject.LockedTime;
            this._lockOrderObject.OrderLockedTimeSpan = (int)span.TotalSeconds;

            if (this._lockOrderObject.OrderLockedTimeSpan >= GlobalConfig.GameConfig.BuyOrderLockTimeMinutes * 60)
            {
                bool isOK = this.ReleaseLock();
                LogHelper.Instance.AddInfoLog("矿石订单" + this._sellOrder.OrderNumber + " 锁定超间，解锁结果为：" + isOK);
                return isOK;
            }

            return false;
        }

        public void SetOrderState(SellOrderState state)
        {
            lock (this._lock)
            {
                this._sellOrder.OrderState = state;
            }
        }

        /// <summary>
        /// RESULTCODE_ORDER_NOT_BE_LOCKED; RESULTCODE_ORDER_NOT_BELONE_CURRENT_PLAYER; RESULTCODE_TRUE; RESULTCODE_FALSE;
        /// </summary>
        /// <param name="buyerUserName"></param>
        /// <returns></returns>
        public int SetSellOrderPayException(string buyerUserName)
        {
            lock (this._lock)
            {
                if (this.OrderState != SellOrderState.Lock)
                {
                    return OperResult.RESULTCODE_ORDER_NOT_BE_LOCKED;
                }

                if (!this.CheckBuyerName(buyerUserName))
                {
                    return OperResult.RESULTCODE_ORDER_NOT_BELONE_CURRENT_PLAYER;
                }

                if (DBProvider.StoneOrderDBProvider.SetSellOrderException(this.OrderNumber))
                {
                    this._sellOrder.OrderState = SellOrderState.Exception;
                    return OperResult.RESULTCODE_TRUE;
                }

                return OperResult.RESULTCODE_FALSE;
            }
        }
    }
}
