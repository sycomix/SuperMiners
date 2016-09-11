﻿using MetaData.User;
using SuperMinersWPF.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMinersWPF.ViewModels
{
    class UserViewModel
    {
        public event EventHandler GetPlayerInfoCompleted;

        bool isStartedListen = false;
        bool isSuspendListen = false;

        /// <summary>
        /// 每分钟执行一次
        /// </summary>
        private System.Timers.Timer _timerUpdateStoneOutput = new System.Timers.Timer(1000);

        public void StartListen()
        {
            if (!isStartedListen)
            {
                isStartedListen = true;

                Thread thrListenStoneOutput = new Thread(TimerUpdateStoneOutput_Elapsed);
                thrListenStoneOutput.Name = "thrListenStoneOutput";
                thrListenStoneOutput.IsBackground = true;
                thrListenStoneOutput.Start();
            }
        }

        const int COUNTDOWN = 59;

        int _countdown = COUNTDOWN;

        public void SuspendListen()
        {
            isSuspendListen = true;
        }

        public void ResumeListen()
        {
            _countdown = COUNTDOWN;
            isSuspendListen = false;
        }

        void TimerUpdateStoneOutput_Elapsed()
        {
            while (isStartedListen)
            {
                if (!isSuspendListen)
                {
                    try
                    {
                        if (GlobalData.IsLogined)
                        {
                            GlobalData.CurrentUser.OutputCountdown = this._countdown--;
                            if (this._countdown < 0)
                            {
                                ComputeOutput();
                                this._countdown = COUNTDOWN;
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        LogHelper.Instance.AddErrorLog("TimerUpdateStoneOutput_Elapsed", exc);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        private void ComputeOutput()
        {
            DateTime startTime = GlobalData.CurrentUser.TempOutputStonesStartTime;

            TimeSpan span = DateTime.Now - startTime;
            if (span.TotalHours < 0)
            {
                return;
            }

            decimal tempOutput = (decimal)span.TotalHours * GlobalData.CurrentUser.MinersCount * GlobalData.GameConfig.OutputStonesPerHour;

            if (tempOutput > GlobalData.CurrentUser.MaxTempStonesOutput)
            {
                tempOutput = GlobalData.CurrentUser.MaxTempStonesOutput;
            }
            if (tempOutput > GlobalData.CurrentUser.WorkableStonesReservers)
            {
                tempOutput = GlobalData.CurrentUser.WorkableStonesReservers;
            }
            GlobalData.CurrentUser.TempOutputStones = tempOutput;
        }

        public void StopListen()
        {
            if (isStartedListen)
            {
                isStartedListen = false;
            }
        }

        public void AsyncGetPlayerInfo()
        {
            App.BusyToken.ShowBusyWindow("正在加载玩家信息...");
            GlobalData.Client.GetPlayerInfo();
        }

        /// <summary>
        /// -1表示清空临时产出
        /// </summary>
        /// <param name="stones"></param>
        public void AsyncGatherStones(decimal stones)
        {
            if (stones == 0)
            {
                App.BusyToken.ShowBusyWindow("正在提交服务器...");
            }
            else
            {
                App.BusyToken.ShowBusyWindow("正在收取矿石...");
            }
            GlobalData.Client.GatherStones(stones);
        }

        public void RegisterEvent()
        {
            GlobalData.Client.GetPlayerInfoCompleted += Client_GetPlayerInfoCompleted;
            GlobalData.Client.GatherStonesCompleted += Client_GatherStonesCompleted;
            GlobalData.Client.OnPlayerInfoChanged += Client_OnPlayerInfoChanged;
        }

        void Client_OnPlayerInfoChanged()
        {
            AsyncGetPlayerInfo();
        }

        void Client_GatherStonesCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<int> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Result > 0)
                {
                    MyMessageBox.ShowInfo("成功收取" + e.Result.ToString() + "矿石。");
                }
                AsyncGetPlayerInfo();
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("服务器连接失败。");
                LogHelper.Instance.AddErrorLog("服务器连接失败。", exc);
            }
        }

        void Client_GetPlayerInfoCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<PlayerInfo> e)
        {
            try
            {
                App.BusyToken.CloseBusyWindow();
                if (e.Cancelled)
                {
                    return;
                }

                if (e.Error != null || e.Result == null)
                {
                    App.BusyToken.CloseAllBusyWindow();
                    MyMessageBox.ShowInfo("获取用户信息失败。");
                    GlobalData.Client.Logout();
                    return;
                }

                GlobalData.InitUser(e.Result);

                if (GetPlayerInfoCompleted != null)
                {
                    GetPlayerInfoCompleted(null, null);
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("服务器连接失败。");
                LogHelper.Instance.AddErrorLog("服务器连接失败。", exc);
            }
        }

    }
}
