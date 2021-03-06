﻿using MetaData;
using SuperMinersCustomServiceSystem.Model;
using SuperMinersWPF.Models;
using SuperMinersWPF.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersWPF.ViewModels
{
    public class GameRouletteViewModel
    {
        private ObservableCollection<RouletteAwardItemUIModel> _listAwardItems = new ObservableCollection<RouletteAwardItemUIModel>();

        public ObservableCollection<RouletteAwardItemUIModel> ListAwardItems
        {
            get { return _listAwardItems; }
            set { _listAwardItems = value; }
        }

        private ObservableCollection<string> _listActiveWinAwardInfos = new ObservableCollection<string>();

        public ObservableCollection<string> ListActiveWinAwardInfos
        {
            get { return _listActiveWinAwardInfos; }
            set { _listActiveWinAwardInfos = value; }
        }

        private ObservableCollection<RouletteWinnerRecordUIModel> _listMyWinAwardRecords = new ObservableCollection<RouletteWinnerRecordUIModel>();

        public ObservableCollection<RouletteWinnerRecordUIModel> ListMyWinAwardRecords
        {
            get { return _listMyWinAwardRecords; }
            set { _listMyWinAwardRecords = value; }
        }

        public GameRouletteViewModel()
        {
            GlobalData.Client.GetAwardItemsCompleted += Client_GetAwardItemsCompleted;
            GlobalData.Client.GetAllWinAwardRecordsCompleted += Client_GetAllWinAwardRecordsCompleted;
            GlobalData.Client.OnGameRouletteWinNotify += Client_OnGameRouletteWinNotify;
            GlobalData.Client.OnGameRouletteWinRealAwardPaySucceed += Client_OnGameRouletteWinRealAwardPaySucceed;
        }

        void Client_OnGameRouletteWinRealAwardPaySucceed(MetaData.Game.Roulette.RouletteWinnerRecord obj)
        {
            try
            {
                if (obj == null)
                {
                    LogHelper.Instance.AddErrorLog("幸运大转盘中奖支付，服务器回调返回空对象.", null);
                }
                MyMessageBox.ShowInfo("您在幸运大转盘中摇中的[" + obj.AwardItem.AwardName + "]大奖，平台已经成功支付，敬请查收");
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("幸运大转盘中奖支付，服务器回调返回后处理异常.", exc);
            }
        }

        void Client_OnGameRouletteWinNotify(string obj)
        {
            try
            {
                if (obj != null)
                {
                    if (this.ListActiveWinAwardInfos.Count > 10)
                    {
                        this.ListActiveWinAwardInfos.RemoveAt(this.ListActiveWinAwardInfos.Count - 1);
                    }
                    this.ListActiveWinAwardInfos.Insert(0, obj);
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("Client_OnGameRouletteWinNotify Exceptioin.", exc);
            }
        }

        void Client_GetAllWinAwardRecordsCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<MetaData.Game.Roulette.RouletteWinnerRecord[]> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    MyMessageBox.ShowInfo("查询幸运大转盘中奖记录，服务器返回异常。异常信息：" + e.Error.Message);
                    return;
                }

                string userState = e.UserState as string;
                if (string.IsNullOrEmpty(userState))
                {
                    this.ListActiveWinAwardInfos.Clear();
                    if (e.Result != null)
                    {
                        foreach (var item in e.Result)
                        {
                            this.ListActiveWinAwardInfos.Add(item.ToString());
                        }
                    }
                }
                else
                {
                    this.ListMyWinAwardRecords.Clear();
                    if (e.Result != null)
                    {
                        foreach (var item in e.Result)
                        {
                            this.ListMyWinAwardRecords.Add(new RouletteWinnerRecordUIModel(item));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("查询幸运大转盘中奖记录，返回后处理异常。异常信息：" + exc.Message);
            }
        }

        void Client_GetAwardItemsCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<MetaData.Game.Roulette.RouletteAwardItem[]> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Error != null)
                {
                    MyMessageBox.ShowInfo("查询幸运大转盘奖项，服务器返回异常。异常信息：" + e.Error.Message);
                    return;
                }

                this.ListAwardItems.Clear();
                if (e.Result != null)
                {
                    foreach (var item in e.Result)
                    {
                        this.ListAwardItems.Add(new RouletteAwardItemUIModel(item));
                    }
                }

                if (AwardItemsListChanged != null)
                {
                    AwardItemsListChanged();
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("查询幸运大转盘奖项，返回后处理异常。异常信息：" + exc.Message);
            }
        }

        public void AsyncGetAllAwardItems()
        {
            if (GlobalData.Client.IsEnable)
            {
                App.BusyToken.ShowBusyWindow("正在加载数据...");
                GlobalData.Client.GetAwardItems(null);
            }
        }

        public void AsyncGetAllAwardRecord(int RouletteAwardItemID, MyDateTime BeginWinTime, MyDateTime EndWinTime, int IsGot, int IsPay, int pageItemCount, int pageIndex)
        {
            if (GlobalData.Client.IsEnable)
            {
                App.BusyToken.ShowBusyWindow("正在加载数据...");
                GlobalData.Client.GetAllWinAwardRecords("", RouletteAwardItemID, BeginWinTime, EndWinTime, IsGot, IsPay, pageItemCount, pageIndex, "");
            }
        }

        public void AsyncGetMyselfAwardRecord(int RouletteAwardItemID, MyDateTime BeginWinTime, MyDateTime EndWinTime, int IsGot, int IsPay, int pageItemCount, int pageIndex)
        {
            if (GlobalData.Client.IsEnable)
            {
                App.BusyToken.ShowBusyWindow("正在加载数据...");
                GlobalData.Client.GetAllWinAwardRecords(GlobalData.CurrentUser.UserName, RouletteAwardItemID, BeginWinTime, EndWinTime, IsGot, IsPay, pageItemCount, pageIndex, GlobalData.CurrentUser.UserName);
            }
        }

        public event Action AwardItemsListChanged;
    }
}
