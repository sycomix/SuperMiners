﻿using Microsoft.Win32;
using SuperMinersCustomServiceSystem.Model;
using SuperMinersCustomServiceSystem.Uility;
using SuperMinersCustomServiceSystem.View.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMinersCustomServiceSystem.View.Controls
{
    /// <summary>
    /// Interaction logic for PlayerManagerControl.xaml
    /// </summary>
    public partial class PlayerManagerControl : UserControl
    {
        public PlayerManagerControl()
        {
            InitializeComponent();
            BindUI();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.PlayerVMObject == null || GlobalData.CurrentAdmin == null)
            {
                return;
            }

            App.PlayerVMObject.AsyncGetListPlayers();

            //if (GlobalData.CurrentAdmin.GroupType != MetaData.User.AdminGroupType.CEO)
            //{
            //    this.btnDeletePlayer.IsEnabled = false;
            //    this.btnEditPlayerInfo.IsEnabled = false;
            //    this.btnLockPlayer.IsEnabled = false;
            //    this.btnSetPlayerAsAgent.IsEnabled = false;
            //    this.btnUnLockPlayer.IsEnabled = false;
            //}
        }

        private void BindUI()
        {
            Binding bind = new Binding()
            {
                Source = App.PlayerVMObject
            };

            this.panelPlayersManager.SetBinding(GroupBox.DataContextProperty, bind);

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.txtUserName.Text = "";
            this.txtAlipayAccount.Text = "";
            this.txtReferrerUserName.Text = "";
            this.cmbLocked.SelectedIndex = 0;
            this.cmbOnline.SelectedIndex = 0;
            App.PlayerVMObject.AsyncGetListPlayers();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            App.PlayerVMObject.SearchPlayers(this.txtUserName.Text.Trim(), cmbUserGroup.SelectedIndex - 1, this.txtAlipayAccount.Text.Trim(), this.txtReferrerUserName.Text.Trim(), this.txtInvitationCode.Text.Trim(), this.cmbLocked.SelectedIndex, this.cmbOnline.SelectedIndex, this.txtLoginIP.Text.Trim(), this.txtLoginMac.Text.Trim());
        }

        private void btnEditPlayerInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;

                    EditPlayerWindow win = new EditPlayerWindow(player);
                    win.ShowDialog();
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    InputActionPasswordWindow win = new InputActionPasswordWindow();
                    if (win.ShowDialog() == true)
                    {
                        string ActionPassword = win.ActionPassword;
                        PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;

                        if (MessageBox.Show("删除玩家【" + player.UserName + "】？该操作不可恢复，请确认？", "请确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                        {
                            App.PlayerVMObject.AsyncDeletePlayerInfos(new string[] { player.UserName }, ActionPassword);
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void btnCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDig = new SaveFileDialog();
            saveDig.Filter = "CSV文件(*.csv)|.csv";
            if (saveDig.ShowDialog() == true)
            {
                string fileName = saveDig.FileName;

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("用户名,昵称,支付宝账户,支付宝真实姓名,注册时间,注册IP,推荐人,邀请码,上一次登录时间,上一次收取矿石时间,是否被锁定,锁定时间,是否在线,当前登录IP,贡献值,灵币,金币,矿石储量,累计总产出,矿石量,矿工数,钻石量");
                foreach (var item in App.PlayerVMObject.ListFilteredPlayers)
                {
                    #region
                    builder.Append(item.UserName);
                    builder.Append(",");
                    builder.Append(item.NickName);
                    builder.Append(",");
                    builder.Append(item.Alipay);
                    builder.Append(",");
                    builder.Append(item.AlipayRealName);
                    builder.Append(",");
                    builder.Append(item.RegisterTime);
                    builder.Append(",");
                    builder.Append(item.RegisterIP);
                    builder.Append(",");
                    builder.Append(item.ReferrerUserName);
                    builder.Append(",");
                    builder.Append(item.InvitationCode);
                    builder.Append(",");
                    builder.Append(item.LastLoginTime);
                    builder.Append(",");
                    builder.Append(item.LastGatherStoneTime);
                    builder.Append(",");
                    builder.Append(item.IsLocked);
                    builder.Append(",");
                    builder.Append(item.LockedTime);
                    builder.Append(",");
                    builder.Append(item.Online);
                    builder.Append(",");
                    builder.Append(item.LastLoginIP);
                    builder.Append(",");
                    builder.Append(item.Exp);
                    builder.Append(",");
                    builder.Append(item.RMB);
                    builder.Append(",");
                    builder.Append(item.GoldCoin);
                    builder.Append(",");
                    builder.Append(item.StonesReserves);
                    builder.Append(",");
                    builder.Append(item.TotalProducedStonesCount);
                    builder.Append(",");
                    builder.Append(item.StockOfStones);
                    builder.Append(",");
                    builder.Append(item.MinersCount);
                    builder.Append(",");
                    builder.Append(item.StockOfDiamonds);
                    builder.AppendLine();
                    #endregion
                }

                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(stream, UTF8Encoding.UTF8);
                    writer.Write(builder.ToString());
                    writer.Dispose();
                }

                MyMessageBox.ShowInfo("保存CSV文件成功");
            }
        }

        private void btnLockPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player.IsLocked)
                    {
                        MyMessageBox.ShowInfo("该玩家已经被锁定");
                        return;
                    }
                    InputActionPasswordWindow win = new InputActionPasswordWindow();
                    if (win.ShowDialog() == true)
                    {
                        string ActionPassword = win.ActionPassword;
                        if (MessageBox.Show("请确认要锁定玩家【" + player.UserName + "】", "请确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                        {
                            App.PlayerVMObject.AsyncLockPlayerInfos(player.UserName, ActionPassword);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("锁定玩家异常。" + exc.Message);
            }
        }

        private void btnUnLockPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (!player.IsLocked)
                    {
                        MyMessageBox.ShowInfo("该玩家没有被锁定");
                        return;
                    }
                    InputActionPasswordWindow win = new InputActionPasswordWindow();
                    if (win.ShowDialog() == true)
                    {
                        string ActionPassword = win.ActionPassword;

                        if (MessageBox.Show("请确认要解锁玩家【" + player.UserName + "】", "请确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                        {
                            App.PlayerVMObject.AsyncUnLockPlayerInfos(player.UserName, ActionPassword);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("解锁玩家异常。" + exc.Message);
            }
        }

        private void btnSetPlayerAsAgent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (MessageBox.Show("请确认要将玩家【" + player.UserName + "】设置为代理？", "请确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        InputActionPasswordWindow win = new InputActionPasswordWindow();
                        if (win.ShowDialog() == true)
                        {
                            //string ActionPassword = win.ActionPassword;

                            EditAgentInfoWindow winEdit = new EditAgentInfoWindow(player.UserID, player.UserName);
                            winEdit.ShowDialog();
                            if (winEdit.ISOK)
                            {
                                App.PlayerVMObject.AsyncGetListPlayers();
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MyMessageBox.ShowInfo("解锁玩家异常。" + exc.Message);
            }
        }

        private void btnViewPlayerExpRecords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;

                    ViewPlayerExpChangedRecordsWindow win = new ViewPlayerExpChangedRecordsWindow(player.UserID);
                    win.ShowDialog();
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void btnViewPlayerLoginLogs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;

                    ViewPlayerLoginLogsWindow win = new ViewPlayerLoginLogsWindow(player.UserID);
                    win.ShowDialog();
                }
            }
            catch (Exception exc)
            {

            }
        }

        void PlayerListContextMenu_ViewBuyMineRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (this.ViewPlayerBuyMineRecords != null)
                        {
                            this.ViewPlayerBuyMineRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void PlayerListContextMenu_ViewRechargeGoldCoinRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (this.ViewPlayerBuyGoldCoinRecords != null)
                        {
                            this.ViewPlayerBuyGoldCoinRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void PlayerListContextMenu_ViewBuyMinerRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (ViewPlayerBuyMinerRecords != null)
                        {
                            this.ViewPlayerBuyMinerRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void PlayerListContextMenu_ViewSellStoneRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (ViewPlayerSellStoneOrderRecords != null)
                        {
                            ViewPlayerSellStoneOrderRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void PlayerListContextMenu_ViewLockStoneRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (ViewPlayerLockedStoneOrderRecords != null)
                        {
                            ViewPlayerLockedStoneOrderRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void PlayerListContextMenu_ViewBuyStoneRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (ViewPlayerBuyStoneOrderRecords != null)
                        {
                            ViewPlayerBuyStoneOrderRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void PlayerListContextMenu_ViewAlipayPayRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (ViewPlayerAlipayRechargeRecords != null)
                        {
                            ViewPlayerAlipayRechargeRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void PlayerListContextMenu_ViewRMBWithdrawRecordItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridPlayerInfos.SelectedItem is PlayerInfoUIModel)
                {
                    PlayerInfoUIModel player = this.datagridPlayerInfos.SelectedItem as PlayerInfoUIModel;
                    if (player != null)
                    {
                        if (ViewPlayerRMBWithdrawRecords != null)
                        {
                            ViewPlayerRMBWithdrawRecords(player.UserName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        public event Action<string> ViewPlayerSellStoneOrderRecords;
        public event Action<string> ViewPlayerLockedStoneOrderRecords;
        public event Action<string> ViewPlayerBuyStoneOrderRecords;
        public event Action<string> ViewPlayerBuyMinerRecords;
        public event Action<string> ViewPlayerBuyMineRecords;
        public event Action<string> ViewPlayerBuyGoldCoinRecords;
        public event Action<string> ViewPlayerAlipayRechargeRecords;
        public event Action<string> ViewPlayerRMBWithdrawRecords;
    }
}
