﻿using MetaData;
using MetaData.Game.StoneStack;
using SuperMinersWPF.Models;
using SuperMinersWPF.Utility;
using SuperMinersWPF.Wcf.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersWPF.ViewModels
{
    public class StackStoneViewModel
    {
        System.Timers.Timer _timer = new System.Timers.Timer(10 * 1000);

        private TodayStoneStackTradeRecordInfoUIModel _currentTodayStackInfo = new TodayStoneStackTradeRecordInfoUIModel(new MetaData.Game.StoneStack.TodayStoneStackTradeRecordInfo());
        public TodayStoneStackTradeRecordInfoUIModel TodayStackInfo
        {
            get
            {
                return this._currentTodayStackInfo;
            }
        }

        private ObservableCollection<StoneStackDailyRecordInfo> _listTodayRealTimeTradeRecords = new ObservableCollection<StoneStackDailyRecordInfo>();

        public ObservableCollection<StoneStackDailyRecordInfo> ListTodayRealTimeTradeRecords
        {
            get { return _listTodayRealTimeTradeRecords; }
        }
        
        private ObservableCollection<StoneDelegateSellOrderInfoUIModel> _allFinishedSellOrders = new ObservableCollection<StoneDelegateSellOrderInfoUIModel>();
        public ObservableCollection<StoneDelegateSellOrderInfoUIModel> AllFinishedSellOrders
        {
            get { return this._allFinishedSellOrders; }
        }

        private ObservableCollection<StoneDelegateSellOrderInfoUIModel> _allNotFinishedSellOrders = new ObservableCollection<StoneDelegateSellOrderInfoUIModel>();
        public ObservableCollection<StoneDelegateSellOrderInfoUIModel> AllNotFinishedSellOrders
        {
            get { return _allNotFinishedSellOrders; }
        }

        private ObservableCollection<StoneDelegateBuyOrderInfoUIModel> _allFinishedBuyOrders = new ObservableCollection<StoneDelegateBuyOrderInfoUIModel>();
        public ObservableCollection<StoneDelegateBuyOrderInfoUIModel> AllFinishedBuyOrders
        {
            get { return this._allFinishedBuyOrders; }
        }

        private ObservableCollection<StoneDelegateBuyOrderInfoUIModel> _allNotFinishedBuyOrders = new ObservableCollection<StoneDelegateBuyOrderInfoUIModel>();
        public ObservableCollection<StoneDelegateBuyOrderInfoUIModel> AllNotFinishedBuyOrders
        {
            get { return _allNotFinishedBuyOrders; }
        }

        public void AsyncGetAllFinishedBuyOrders(MyDateTime myBeginCreateTime, MyDateTime myEndCreateTime, int pageItemCount, int pageIndex)
        {
            App.BusyToken.ShowBusyWindow("正在查询数据...");
            GlobalData.Client.GetFinishedDelegateBuyStoneOrders(myBeginCreateTime, myEndCreateTime, pageItemCount, pageIndex, null);
        }

        public void AsyncGetAllFinishedSellOrders(MyDateTime myBeginFinishedTime, MyDateTime myEndFinishedTime, int pageItemCount, int pageIndex)
        {
            App.BusyToken.ShowBusyWindow("正在查询数据...");
            GlobalData.Client.GetFinishedDelegateSellStoneOrders(myBeginFinishedTime, myEndFinishedTime, pageItemCount, pageIndex, null);
        }

        public void AsyncGetAllNotFinishedBuyOrders()
        {
            if (GlobalData.Client == null || !GlobalData.Client.IsEnable)
            {
                return;
            }

            App.BusyToken.ShowBusyWindow("正在提交数据...");
            GlobalData.Client.GetNotFinishedDelegateBuyStoneOrders(null);
        }

        public void AsyncGetAllNotFinishedSellOrders()
        {
            if (GlobalData.Client == null || !GlobalData.Client.IsEnable)
            {
                return;
            }

            App.BusyToken.ShowBusyWindow("正在提交数据...");
            GlobalData.Client.GetNotFinishedDelegateSellStoneOrders(null);
        }

        public void AsyncCancelDelegateBuyStoneOrder(StoneDelegateBuyOrderInfo buyOrder)
        {
            if (GlobalData.Client == null || !GlobalData.Client.IsEnable)
            {
                return;
            }

            App.BusyToken.ShowBusyWindow("正在提交数据...");
            GlobalData.Client.CancelDelegateBuyStone(buyOrder, null);
        }

        public void AsyncCancelDelegateSellStoneOrder(StoneDelegateSellOrderInfo sellOrder)
        {
            if (GlobalData.Client == null || !GlobalData.Client.IsEnable)
            {
                return;
            }

            App.BusyToken.ShowBusyWindow("正在提交数据...");
            GlobalData.Client.CancelDelegateSellStone(sellOrder, null);
        }

        public void AsyncGetTodayRealTimeTradeRecords()
        {
            GlobalData.Client.GetTodayRealTimeTradeRecords(null);
        }

        public void AsyncGetAllStoneStackDailyRecords()
        {
            GlobalData.Client.GetAllStoneStackDailyRecordInfo(null);
        }

        public void RegisterEvent()
        {
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            GlobalData.Client.OnDelegateStoneOrderTradeSucceed += Client_OnDelegateStoneOrderTradeSucceed;
            GlobalData.Client.GetTodayStoneStackInfoCompleted += Client_GetTodayStoneStackInfoCompleted;
            GlobalData.Client.GetNotFinishedDelegateBuyStoneOrdersCompleted += Client_GetNotFinishedDelegateBuyStoneOrdersCompleted;
            GlobalData.Client.GetNotFinishedDelegateSellStoneOrdersCompleted += Client_GetNotFinishedDelegateSellStoneOrdersCompleted;
            GlobalData.Client.CancelDelegateBuyStoneCompleted += Client_CancelDelegateBuyStoneCompleted;
            GlobalData.Client.CancelDelegateSellStoneCompleted += Client_CancelDelegateSellStoneCompleted;
            GlobalData.Client.GetFinishedDelegateSellStoneOrdersCompleted += Client_GetFinishedDelegateSellStoneOrdersCompleted;
            GlobalData.Client.GetFinishedDelegateBuyStoneOrdersCompleted += Client_GetFinishedDelegateBuyStoneOrdersCompleted;
            GlobalData.Client.GetTodayRealTimeTradeRecordsCompleted += Client_GetTodayRealTimeTradeRecordsCompleted;
            GlobalData.Client.GetAllStoneStackDailyRecordInfoCompleted += Client_GetAllStoneStackDailyRecordInfoCompleted;
        }

        void Client_GetAllStoneStackDailyRecordInfoCompleted(object sender, WebInvokeEventArgs<StoneStackDailyRecordInfo[]> e)
        {
            try
            {
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetAllStoneStackDailyRecordInfoCompleted Server Exception", e.Error);
                    return;
                }

                if (GetAllStoneStackDailyRecordInfoCompleted != null)
                {
                    GetAllStoneStackDailyRecordInfoCompleted(e.Result);
                }
                //this.ListAllHistoryDailyTradeRecords.Clear();
                //foreach (var item in e.Result)
                //{
                //    this.ListAllHistoryDailyTradeRecords.Add(item);
                //}
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetAllStoneStackDailyRecordInfoCompleted Exception", exc);
            }
        }

        void Client_GetTodayRealTimeTradeRecordsCompleted(object sender, WebInvokeEventArgs<StoneStackDailyRecordInfo[]> e)
        {
            try
            {
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetTodayRealTimeTradeRecordsCompleted Server Exception", e.Error);
                    return;
                }
                this.ListTodayRealTimeTradeRecords.Clear();
                foreach (var item in e.Result)
                {
                    this.ListTodayRealTimeTradeRecords.Add(item);
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetTodayRealTimeTradeRecordsCompleted Exception", exc);
            }
        }

        public void StopListen()
        {
            _timer.Close();
        }

        void Client_OnDelegateStoneOrderTradeSucceed()
        {
            try
            {
                this.AsyncGetAllNotFinishedBuyOrders();
                this.AsyncGetAllNotFinishedSellOrders();
                App.UserVMObject.AsyncGetPlayerInfo();
            }
            catch (Exception exc)
            {

            }
        }

        void Client_GetFinishedDelegateBuyStoneOrdersCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<StoneDelegateBuyOrderInfo[]> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetFinishedDelegateBuyStoneOrdersCompleted Server Exception", e.Error);
                    return;
                }
                this.AllFinishedBuyOrders.Clear();
                foreach (var item in e.Result)
                {
                    this.AllFinishedBuyOrders.Add(new StoneDelegateBuyOrderInfoUIModel(item));
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetFinishedDelegateBuyStoneOrdersCompleted Exception", exc);
            }
        }

        void Client_GetFinishedDelegateSellStoneOrdersCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<StoneDelegateSellOrderInfo[]> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetFinishedDelegateSellStoneOrdersCompleted Server Exception", e.Error);
                    return;
                }
                this.AllFinishedSellOrders.Clear();
                foreach (var item in e.Result)
                {
                    this.AllFinishedSellOrders.Add(new StoneDelegateSellOrderInfoUIModel(item));
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetFinishedDelegateSellStoneOrdersCompleted Exception", exc);
            }
        }

        void Client_CancelDelegateSellStoneCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<int> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_CancelDelegateSellStoneCompleted server return Exception", e.Error);
                    MyMessageBox.ShowInfo("取消委托卖单操作，服务返回异常");
                    return;
                }

                if (e.Result == OperResult.RESULTCODE_TRUE)
                {
                    MyMessageBox.ShowInfo("取消委托卖单成功。");
                    AsyncGetAllNotFinishedSellOrders();
                    App.UserVMObject.AsyncGetPlayerInfo();
                }
                else
                {
                    MyMessageBox.ShowInfo("取消委托卖单失败。原因为：" + OperResult.GetMsg(e.Result));
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("取消委托卖单操作，处理异常");
                LogHelper.Instance.AddErrorLog("Client_CancelDelegateSellStoneCompleted Exception", exc);
            }
        }

        void Client_CancelDelegateBuyStoneCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<int> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_CancelDelegateBuyStoneCompleted server return Exception", e.Error);
                    MyMessageBox.ShowInfo("取消委托买单操作，服务返回异常");
                    return;
                }

                if (e.Result == OperResult.RESULTCODE_TRUE)
                {
                    MyMessageBox.ShowInfo("取消委托买单成功。");
                    AsyncGetAllNotFinishedBuyOrders();
                    App.UserVMObject.AsyncGetPlayerInfo();
                }
                else
                {
                    MyMessageBox.ShowInfo("取消委托买单失败。原因为：" + OperResult.GetMsg(e.Result));
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("取消委托买单操作，处理异常");
                LogHelper.Instance.AddErrorLog("Client_CancelDelegateBuyStoneCompleted Exception", exc);
            }
        }

        void Client_GetNotFinishedDelegateSellStoneOrdersCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<StoneDelegateSellOrderInfo[]> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetNotFinishedDelegateSellStoneOrdersCompleted Server Exception", e.Error);
                    return;
                }
                this.AllNotFinishedSellOrders.Clear();
                if (e.Result != null)
                {
                    foreach (var item in e.Result)
                    {
                        this.AllNotFinishedSellOrders.Add(new StoneDelegateSellOrderInfoUIModel(item));
                    }
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetNotFinishedDelegateSellStoneOrdersCompleted Exception", exc);
            }
        }

        void Client_GetNotFinishedDelegateBuyStoneOrdersCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<StoneDelegateBuyOrderInfo[]> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetNotFinishedDelegateBuyStoneOrdersCompleted Server Exception", e.Error);
                    return;
                }
                this.AllNotFinishedBuyOrders.Clear();
                if (e.Result != null)
                {
                    foreach (var item in e.Result)
                    {
                        this.AllNotFinishedBuyOrders.Add(new StoneDelegateBuyOrderInfoUIModel(item));
                    }
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetNotFinishedDelegateBuyStoneOrdersCompleted Exception", exc);
            }
        }

        void Client_GetTodayStoneStackInfoCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<MetaData.Game.StoneStack.TodayStoneStackTradeRecordInfo> e)
        {
            try
            {
                if (e.Error != null)
                {
                    LogHelper.Instance.AddErrorLog("Client_GetTodayStoneStackInfoCompleted Exception1", e.Error);
                }

                this.TodayStackInfo.ParentObject = e.Result;
                if (e.Result == null || e.Result.MarketState != StackMarketState.Opening || e.Result.DailyInfo.Day == null)
                {
                    this.ListTodayRealTimeTradeRecords.Clear();

                    if (MarketClosed != null)
                    {
                        MarketClosed();
                    }
                }
                else
                {
                    if (this.ListTodayRealTimeTradeRecords.Count == 0)
                    {
                        this.ListTodayRealTimeTradeRecords.Add(e.Result.DailyInfo);
                    }
                    else
                    {
                        var lastDateTime = this.ListTodayRealTimeTradeRecords[this.ListTodayRealTimeTradeRecords.Count - 1].Day.ToDateTime();
                        if (lastDateTime < e.Result.DailyInfo.Day.ToDateTime())
                        {
                            this.ListTodayRealTimeTradeRecords.Add(e.Result.DailyInfo);
                        }
                    }

                    if (MarketOpened != null)
                    {
                        MarketOpened();
                    }
                }

                if (e.Result != null && e.Result.DailyInfo.Day != null)
                {
                    if (GetTodayStackRecordInfoCompleted != null)
                    {
                        GetTodayStackRecordInfoCompleted(e.Result.DailyInfo);
                    }
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_GetTodayStoneStackInfoCompleted Exception", exc);
            }
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (GlobalData.Client != null && GlobalData.Client.IsEnable && GlobalData.IsLogined)
            {
                GlobalData.Client.GetTodayStoneStackInfo(null);
            }
        }


        public event Action MarketOpened;
        public event Action MarketClosed;
        public event Action<StoneStackDailyRecordInfo> GetTodayStackRecordInfoCompleted;
        public event Action<StoneStackDailyRecordInfo[]> GetAllStoneStackDailyRecordInfoCompleted;
    }
}
