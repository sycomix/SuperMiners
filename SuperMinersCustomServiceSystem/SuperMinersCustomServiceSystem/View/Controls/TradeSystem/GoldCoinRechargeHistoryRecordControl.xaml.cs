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

namespace SuperMinersCustomServiceSystem.View.Controls.TradeSystem
{
    /// <summary>
    /// Interaction logic for GoldCoinRechargeHistoryRecordControl.xaml
    /// </summary>
    public partial class GoldCoinRechargeHistoryRecordControl : UserControl
    {
        public GoldCoinRechargeHistoryRecordControl()
        {
            InitializeComponent();
            BindUI();
        }

        private void BindUI()
        {
            if (this.txtSumGoldCoin == null)
            {
                return;
            }

            this.dgRecords.ItemsSource = App.GoldCoinTradeVMObject.ListGoldCoinRechargeRecords;
            Binding bind = new Binding("SumListGoldCoinRechargeRecords_GotGoldCoin")
            {
                Mode = BindingMode.OneWay
            };
            this.txtSumGoldCoin.SetBinding(TextBox.TextProperty, bind);

            bind = new Binding("SumListGoldCoinRechargeRecords_SpendRMB")
            {
                Mode = BindingMode.OneWay
            };
            this.txtSumRMB.SetBinding(TextBox.TextProperty, bind);

            this.DataContext = App.GoldCoinTradeVMObject;
        }

        public void SetBuyerUserName(string userName)
        {
            this.txtPlayerUserName.Text = userName;
            Search();
        }
        
        private void Search()
        {
            string playerUserName = this.txtPlayerUserName.Text.Trim();
            string orderNumber = this.txtOrderNumber.Text.Trim();
            MyDateTime beginCreateTime = this.dpStartCreateTime.ValueTime;
            MyDateTime endCreateTime = this.dpEndCreateTime.ValueTime;

            int pageIndex = (int)this.numPageIndex.Value;

            App.GoldCoinTradeVMObject.AsyncGetGoldCoinRechargeFinishedRecords(playerUserName, orderNumber, beginCreateTime, endCreateTime, GlobalData.PageItemsCount, pageIndex);
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
            if (App.GoldCoinTradeVMObject.ListGoldCoinRechargeRecords.Count > 0)
            {
                this.numPageIndex.Value = this.numPageIndex.Value + 1;
                Search();
            }
        }
    }
}
