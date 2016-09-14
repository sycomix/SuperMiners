﻿using MetaData;
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

namespace SuperMinersWPF.Views.Controls
{
    /// <summary>
    /// Interaction logic for GoldCoinRechargeHistoryRecordControl.xaml
    /// </summary>
    public partial class GoldCoinRechargeHistoryRecordControl : UserControl
    {
        public GoldCoinRechargeHistoryRecordControl()
        {
            InitializeComponent();
            this.dgRecords.ItemsSource = App.TradeHistoryVMObject.ListGoldCoinRechargeRecords;
        }

        private void Search()
        {
            string playerUserName = GlobalData.CurrentUser.UserName;
            string orderNumber = this.txtOrderNumber.Text.Trim();
            MyDateTime beginCreateTime = this.dpStartCreateTime.ValueTime;
            MyDateTime endCreateTime = this.dpEndCreateTime.ValueTime;
            endCreateTime.Hour = 23;
            endCreateTime.Minute = 59;
            endCreateTime.Second = 59;

            int pageIndex = (int)this.numPageIndex.Value;

            App.TradeHistoryVMObject.AsyncGetGoldCoinRechargeFinishedRecords(playerUserName, orderNumber, beginCreateTime, endCreateTime, GlobalData.PageItemsCount, pageIndex);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (this.numPageIndex.Value > 1)
            {
                this.numPageIndex.Value = this.numPageIndex.Value - 1;
                Search();
            }
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (App.TradeHistoryVMObject.ListGoldCoinRechargeRecords.Count > 0)
            {
                this.numPageIndex.Value = this.numPageIndex.Value + 1;
                Search();
            }
        }
    }
}
