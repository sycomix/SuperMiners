﻿using SuperMinersCustomServiceSystem.Model;
using SuperMinersCustomServiceSystem.View;
using System;
using System.Collections.Generic;
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

namespace SuperMinersCustomServiceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Threading.SynchronizationContext _syn;
        public bool IsBackToLogin = false;

        public MainWindow()
        {
            InitializeComponent();

            //if (GlobalData.ServerType == ServerType.Server1)
            //{
            //    this.Title += "迅灵矿场管理系统 " + System.Configuration.ConfigurationManager.AppSettings["softwareversion"] + "    迅灵一区" + "  --" + GlobalData.CurrentAdmin.UserName;
            //    this.tvL1TransferManager.Visibility = System.Windows.Visibility.Visible;
            //    this.tvL2_TS_RemoteService.Visibility = System.Windows.Visibility.Collapsed;
            //}
            //else
            //{
                this.Title += "迅灵矿场管理系统 " + System.Configuration.ConfigurationManager.AppSettings["softwareversion"] + "    迅灵二区" + "  --" + GlobalData.CurrentAdmin.UserName;
                //this.tvL1TransferManager.Visibility = System.Windows.Visibility.Collapsed;
                this.tvL2_TS_RemoteService.Visibility = System.Windows.Visibility.Visible;
            //}
            //this.Title += "内测版   --" + GlobalData.CurrentAdmin.UserName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._syn = System.Threading.SynchronizationContext.Current;

            GlobalData.Client.OnKickoutByUser += Client_OnKickoutByUser;

            this.tvL1WithdrawManager.IsSelected = true;

            this.controlPlayerManager.ViewPlayerAlipayRechargeRecords += controlPlayerManager_ViewPlayerAlipayRechargeRecords;
            this.controlPlayerManager.ViewPlayerBuyGoldCoinRecords += controlPlayerManager_ViewPlayerBuyGoldCoinRecords;
            this.controlPlayerManager.ViewPlayerBuyMineRecords += controlPlayerManager_ViewPlayerBuyMineRecords;
            this.controlPlayerManager.ViewPlayerBuyMinerRecords += controlPlayerManager_ViewPlayerBuyMinerRecords;
            this.controlPlayerManager.ViewPlayerBuyStoneOrderRecords += controlPlayerManager_ViewPlayerBuyStoneOrderRecords;
            this.controlPlayerManager.ViewPlayerLockedStoneOrderRecords += controlPlayerManager_ViewPlayerLockedStoneOrderRecords;
            this.controlPlayerManager.ViewPlayerSellStoneOrderRecords += controlPlayerManager_ViewPlayerSellStoneOrderRecords;
            this.controlPlayerManager.ViewPlayerRMBWithdrawRecords += controlPlayerManager_ViewPlayerRMBWithdrawRecords;
            this.controlPlayerManager.ViewPlayerRemoteServiceBuyRecords += controlPlayerManager_ViewPlayerRemoteServiceBuyRecords;
            this.controlPlayerManager.ViewPlayerRemoteServiceHandleRecords += controlPlayerManager_ViewPlayerRemoteServiceHandleRecords;

            this.controlRouletteCurrentAwardItem.RegisterEvents();
        }

        void controlPlayerManager_ViewPlayerRemoteServiceHandleRecords(string obj)
        {
            this.HideAllControls();
            this.controlUserHandleRemoteServiceRecordsControl.Visibility = System.Windows.Visibility.Visible;
            this.controlUserHandleRemoteServiceRecordsControl.SetUserName(obj);
            this.tvL2_TS_RemoteService_HandleRecord.IsSelected = true;
            this.tvL2_TS_RemoteService_HandleRecord.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerRemoteServiceBuyRecords(string obj)
        {
            this.HideAllControls();
            this.controlUserBuyRemoteServiceRecordsControl.Visibility = System.Windows.Visibility.Visible;
            this.controlUserBuyRemoteServiceRecordsControl.SetUserName(obj);
            this.tvL2_TS_RemoteService_BuyRecord.IsSelected = true;
            this.tvL2_TS_RemoteService_BuyRecord.IsExpanded = true;
        }

        private void btnRefreshTotalInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        void controlPlayerManager_ViewPlayerRMBWithdrawRecords(string obj)
        {
            this.HideAllControls();
            this.controlWithdrawRMBHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlWithdrawRMBHistory.SetUserName(obj);
            this.tvL2_TS_WithdrawRMB_History.IsSelected = true;
            this.tvL2_TS_WithdrawRMB_History.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerSellStoneOrderRecords(string obj)
        {
            this.HideAllControls();
            this.controlStoneDelegateSellTrade.Visibility = System.Windows.Visibility.Visible;
            this.controlStoneDelegateSellTrade.SetSellerUserName(obj);
            this.tvL2_TS_Stone_SellHistory.IsSelected = true;
            this.tvL2_TS_Stone_SellHistory.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerLockedStoneOrderRecords(string obj)
        {
            this.HideAllControls();
            this.controlNotFinishStoneTradeRecord.Visibility = System.Windows.Visibility.Visible;
            this.controlNotFinishStoneTradeRecord.SetBuyerUserName(obj);
            this.tvL2_TS_Stone_SellHistory.IsSelected = true;
            this.tvL2_TS_Stone_SellHistory.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerBuyStoneOrderRecords(string obj)
        {
            this.HideAllControls();
            this.controlStoneDelegateBuyTrade.Visibility = System.Windows.Visibility.Visible;
            this.controlStoneDelegateBuyTrade.SetBuyerUserName(obj);
            this.tvL2_TS_Stone_BuyHistory.IsSelected = true;
            this.tvL2_TS_Stone_BuyHistory.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerBuyMinerRecords(string obj)
        {
            this.HideAllControls();
            this.controlMinerTradeHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlMinerTradeHistory.SetBuyerUserName(obj);
            this.tvL2_TS_Miner_History.IsSelected = true;
            this.tvL2_TS_Miner_History.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerBuyMineRecords(string obj)
        {
            this.HideAllControls();
            this.controlMineTradeHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlMineTradeHistory.SetBuyerUserName(obj);
            this.tvL2_TS_Mine_History.IsSelected = true;
            this.tvL2_TS_Mine_History.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerBuyGoldCoinRecords(string obj)
        {
            this.HideAllControls();
            this.controlGoldCoinRechargeHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlGoldCoinRechargeHistory.SetBuyerUserName(obj);
            this.tvL2_TS_GoldCoin_History.IsSelected = true;
            this.tvL2_TS_GoldCoin_History.IsExpanded = true;
        }

        void controlPlayerManager_ViewPlayerAlipayRechargeRecords(string obj)
        {
            this.HideAllControls();
            this.controlAlipayRecordHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlAlipayRecordHistory.SetBuyerUserName(obj);
            this.tvL2_TS_Alipay_HistoryRecord.IsSelected = true;
            this.tvL2_TS_Alipay_HistoryRecord.IsExpanded = true;
        }

        void Client_OnKickoutByUser()
        {
            this._syn.Post(s =>
            {
                MessageBox.Show("您的账户在其它电脑登录，如非本人操作，请及时修改密码。");
                this.IsBackToLogin = true;
                this.Close();
            }, null);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.controlRouletteCurrentAwardItem.RemoveEvents();
            GlobalData.Client.LogoutAdmin();
        }

        private void HideAllControls()
        {
            this.controlGoldCoinRechargeActive.Visibility = System.Windows.Visibility.Collapsed;
            this.controlGoldCoinRechargeHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlMinerTradeActive.Visibility = System.Windows.Visibility.Collapsed;
            this.controlMinerTradeHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlMineTradeActive.Visibility = System.Windows.Visibility.Collapsed;
            this.controlMineTradeHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlNoticeManager.Visibility = System.Windows.Visibility.Collapsed;
            this.controlPlayerManager.Visibility = System.Windows.Visibility.Collapsed;
            this.controlStoneTradeActive.Visibility = System.Windows.Visibility.Collapsed;
            this.controlStoneBuyTradeHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlStoneSellTradeHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlNotFinishStoneTradeRecord.Visibility = System.Windows.Visibility.Collapsed;
            this.controlWithdrawRMBActive.Visibility = System.Windows.Visibility.Collapsed;
            this.controlWithdrawRMBHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlStoneTradeShowImage.Visibility = System.Windows.Visibility.Collapsed;
            this.controlAlipayRecordHistory.Visibility = System.Windows.Visibility.Collapsed;
            this.controlAlipayExceptionRecords.Visibility = System.Windows.Visibility.Collapsed;
            this.controlNoticeManage.Visibility = System.Windows.Visibility.Collapsed;
            this.controlRouletteActiveWinRealAwardRecords.Visibility = System.Windows.Visibility.Collapsed;
            this.controlRouletteWinAwardHistoryRecords.Visibility = System.Windows.Visibility.Collapsed;
            this.controlRouletteRouletteAwardItemListControl.Visibility = System.Windows.Visibility.Collapsed;
            this.controlRouletteCurrentAwardItem.Visibility = System.Windows.Visibility.Collapsed;
            this.controlRouletteRoundList.Visibility = System.Windows.Visibility.Collapsed;
            this.controlDeletedPlayerManage.Visibility = System.Windows.Visibility.Collapsed;
            this.controlTransferServerManage.Visibility = System.Windows.Visibility.Collapsed;
            this.controlStoneDelegateBuyTrade.Visibility = System.Windows.Visibility.Collapsed;
            this.controlStoneDelegateSellTrade.Visibility = System.Windows.Visibility.Collapsed;
            this.controlUserBuyRemoteServiceRecordsControl.Visibility = System.Windows.Visibility.Collapsed;
            this.controlUserHandleRemoteServiceRecordsControl.Visibility = System.Windows.Visibility.Collapsed;
            this.controlVirtualShoppingBuyRecordControl.Visibility = System.Windows.Visibility.Collapsed;
            this.controlVirtualShoppingItemControl.Visibility = System.Windows.Visibility.Collapsed;
            this.controlDiamondShoppingItemListControl.Visibility = System.Windows.Visibility.Collapsed;
            this.controlFactoryDailyProfit.Visibility = System.Windows.Visibility.Collapsed;
            this.controlPlayerFactoryAccountListControl.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void tvL1PlayerManager_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlPlayerManager.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Miner_Active_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlMinerTradeActive.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Miner_History_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlMinerTradeHistory.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Mine_Active_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlMineTradeActive.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Mine_History_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlMineTradeHistory.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Stone_Active_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlStoneTradeActive.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Stone_BuyHistory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            //this.controlStoneBuyTradeHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlStoneDelegateBuyTrade.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Stone_SellHistory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            //this.controlStoneSellTradeHistory.Visibility = System.Windows.Visibility.Visible;
            this.controlStoneDelegateSellTrade.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_GoldCoin_Active_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlGoldCoinRechargeActive.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_GoldCoin_History_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlGoldCoinRechargeHistory.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_WithdrawRMB_History_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlWithdrawRMBHistory.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_WithdrawRMB_ShowImage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlStoneTradeShowImage.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Alipay_ExceptionRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlAlipayExceptionRecords.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Alipay_HistoryRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlAlipayRecordHistory.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_Stone_NotFinished_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlNotFinishStoneTradeRecord.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL1WithdrawManager_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlWithdrawRMBActive.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2NoticeManage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlNoticeManage.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_FS_Roulette_Active_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetCurrentAwardItems();
            App.GameRouletteVMObject.AsyncGetNotPayWinAwardRecords();
            HideAllControls();
            this.controlRouletteActiveWinRealAwardRecords.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_FS_Roulette_HistoryRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetAllAwardItems();
            App.GameRouletteVMObject.AsyncGetCurrentAwardItems();
            HideAllControls();
            this.controlRouletteWinAwardHistoryRecords.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_FS_Roulette_AllAwardItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetAllAwardItems();
            HideAllControls();
            this.controlRouletteRouletteAwardItemListControl.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_FS_Roulette_CurrentAwardItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetAllAwardItems();
            App.GameRouletteVMObject.AsyncGetCurrentAwardItems();
            HideAllControls();
            this.controlRouletteCurrentAwardItem.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_FS_Roulette_RoundList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetAllRouletteRoundInfo();
            HideAllControls();
            this.controlRouletteRoundList.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL1DeletedPlayerManager_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlDeletedPlayerManage.Visibility = System.Windows.Visibility.Visible;
            this.controlDeletedPlayerManage.RefreshDB();
        }

        private void tvL1TransferManager_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlTransferServerManage.Visibility = System.Windows.Visibility.Visible;
            this.controlTransferServerManage.RefreshDB();
        }

        private void tvL2_TS_RemoteService_BuyRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlUserBuyRemoteServiceRecordsControl.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_RemoteService_HandleRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlUserHandleRemoteServiceRecordsControl.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_VirtualShopping_Items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            App.ShoppingVMObject.AsyncGetAllVirtualShoppingItems();
            this.controlVirtualShoppingItemControl.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_VirtualShopping_BuyRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            this.controlVirtualShoppingBuyRecordControl.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_TS_DiamondShopping_BuyRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void tvL2_TS_DiamondShopping_Items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            App.ShoppingVMObject.AsyncGetDiamondShoppingItems(MetaData.Shopping.DiamondsShoppingItemType.LiveThing);
            this.controlDiamondShoppingItemListControl.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_StoneFactory_SetYesterdayProfit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            App.StoneFactoryVMObject.AsyncGetStoneFactorySystemDailyProfitList(GlobalData.PageItemsCount, 1);
            this.controlFactoryDailyProfit.Visibility = System.Windows.Visibility.Visible;
        }

        private void tvL2_StoneFactory_AllFactoryAccount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideAllControls();
            App.StoneFactoryVMObject.AsyncGetAllPlayerStoneFactoryAccountInfos();
            this.controlPlayerFactoryAccountListControl.Visibility = System.Windows.Visibility.Visible;
        }

    }
}
