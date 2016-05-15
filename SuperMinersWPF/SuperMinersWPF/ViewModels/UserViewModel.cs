﻿using MetaData.User;
using SuperMinersWPF.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersWPF.ViewModels
{
    class UserViewModel
    {
        public event EventHandler GetPlayerInfoCompleted;

        bool isStartedListen = false;

        /// <summary>
        /// 每分钟执行一次
        /// </summary>
        private System.Timers.Timer _timerUpdateStoneOutput = new System.Timers.Timer(1000 * 60);

        public void StartListen()
        {
            if (!isStartedListen)
            {
                isStartedListen = true;
                _timerUpdateStoneOutput.Elapsed += TimerUpdateStoneOutput_Elapsed;
                _timerUpdateStoneOutput.Start();
            }
        }

        void TimerUpdateStoneOutput_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (GlobalData.IsLogined)
                {
                    DateTime startTime = GlobalData.CurrentUser.TempOutputStonesStartTime;

                    TimeSpan span = DateTime.Now - startTime;
                    if (span.TotalHours < 0)
                    {
                        return;
                    }

                    float tempOutput = (float)span.TotalHours * GlobalData.CurrentUser.MinersCount * GlobalData.GameConfig.OutputStonesPerHour;

                    if (tempOutput > GlobalData.CurrentUser.MaxTempStonesOutput)
                    {
                        tempOutput = GlobalData.CurrentUser.MaxTempStonesOutput;
                    }
                    if (tempOutput > GlobalData.CurrentUser.WorkableStonesReservers)
                    {
                        tempOutput = GlobalData.CurrentUser.WorkableStonesReservers;
                    }
                    GlobalData.CurrentUser.TempOutputStones = (int)tempOutput;
                }
            }
            catch (Exception exc)
            {
                LogHelper.Instance.AddErrorLog("TimerUpdateStoneOutput_Elapsed", exc);
            }
        }

        public void StopListen()
        {
            if (isStartedListen)
            {
                isStartedListen = false;
                _timerUpdateStoneOutput.Stop();
                _timerUpdateStoneOutput.Elapsed -= TimerUpdateStoneOutput_Elapsed;
            }
        }

        public void AsyncGetPlayerInfo()
        {
            GlobalData.Client.GetPlayerInfo();
        }

        public void AsyncGatherStones(int stones)
        {
            GlobalData.Client.GatherStones(stones);
        }

        public void AsyncChangePassword(string oldPassword, string newPassword)
        {
            GlobalData.Client.ChangePassword(oldPassword, newPassword, newPassword);
        }

        public void AsyncChangeAlipay(string alipayAccount, string alipayRealName)
        {
            GlobalData.Client.ChangeAlipay(alipayAccount, alipayRealName, new string[] { alipayAccount, alipayRealName });
        }

        public void RegisterEvent()
        {
            GlobalData.Client.GetPlayerInfoCompleted += Client_GetPlayerInfoCompleted;
            GlobalData.Client.GatherStonesCompleted += Client_GatherStonesCompleted;
            GlobalData.Client.ChangePasswordCompleted += Client_ChangePasswordCompleted;
            GlobalData.Client.ChangeAlipayCompleted += Client_ChangeAlipayCompleted;
            GlobalData.Client.OnPlayerInfoChanged += Client_OnPlayerInfoChanged;
        }

        void Client_OnPlayerInfoChanged()
        {
            GlobalData.Client.GetPlayerInfo();
        }

        void Client_ChangeAlipayCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<bool> e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Error != null || !e.Result)
            {
                MyMessageBox.ShowInfo("修改失败。");
                return;
            }

            if (e.UserState != null)
            {
                string[] states = e.UserState as string[];
                if (states != null && states.Length == 2)
                {
                    GlobalData.CurrentUser.ParentObject.SimpleInfo.Alipay = states[0];
                    GlobalData.CurrentUser.ParentObject.SimpleInfo.AlipayRealName = states[1];
                }
            }

            MyMessageBox.ShowInfo("修改成功。");
        }

        void Client_ChangePasswordCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<bool> e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Error != null || !e.Result)
            {
                MyMessageBox.ShowInfo("修改失败。");
                return;
            }

            if (e.UserState != null)
            {
                string newPassword = Convert.ToString(e.UserState);
                GlobalData.CurrentUser.ParentObject.SimpleInfo.Password = newPassword;
            }

            MyMessageBox.ShowInfo("修改成功。");
        }

        void Client_GatherStonesCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<int> e)
        {
            if (e.Result > 0)
            {
                MyMessageBox.ShowInfo("成功收取" + e.Result.ToString() + "矿石。");
            }
            AsyncGetPlayerInfo();
        }

        void Client_GetPlayerInfoCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<PlayerInfo> e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Error != null || e.Result == null)
            {
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

    }
}
