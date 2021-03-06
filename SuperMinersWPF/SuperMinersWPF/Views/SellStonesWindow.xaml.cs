﻿using MetaData;
using SuperMinersWPF.StringResources;
using SuperMinersWPF.Utility;
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
using System.Windows.Shapes;

namespace SuperMinersWPF.Views
{
    /// <summary>
    /// Interaction logic for SellStonesWindow.xaml
    /// </summary>
    public partial class SellStonesWindow : Window
    {
        private System.Threading.SynchronizationContext _syn;

        public SellStonesWindow()
        {
            InitializeComponent();
            this._syn = System.Threading.SynchronizationContext.Current;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtAllStones.Text = GlobalData.CurrentUser.StockOfStones.ToString();
            this.txtForzenStones.Text = GlobalData.CurrentUser.FreezingStones.ToString();
            this.txtSellableStones.Text = GlobalData.CurrentUser.SellableStones.ToString();
            this.subTxtExpensePercent.Text = GlobalData.GameConfig.ExchangeExpensePercent.ToString();
            this.numSellStones.Maximum = (int)GlobalData.CurrentUser.SellableStones;
            this.subTxtMinExpense.Text = GlobalData.GameConfig.ExchangeExpenseMinNumber.ToString();

            GlobalData.Client.SellStoneCompleted += Client_SellStoneCompleted;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalData.Client.SellStoneCompleted -= Client_SellStoneCompleted;
        }

        void Client_SellStoneCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<int> e)
        {
            App.BusyToken.CloseBusyWindow();
            if (e.Cancelled)
            {
                return;
            }

            if (e.Error != null)
            {
                MyMessageBox.ShowInfo("挂单出售矿石失败。");
                return;
            }
            if (e.Result != OperResult.RESULTCODE_TRUE)
            {
                MyMessageBox.ShowInfo("挂单出售矿石失败。原因为：" + OperResult.GetMsg(e.Result));
                return;
            }

            MyMessageBox.ShowInfo("挂单出售矿石成功。");
            App.UserVMObject.AsyncGetPlayerInfo();
            App.StoneOrderVMObject.AsyncGetAllNotFinishedSellOrders();

            this._syn.Post((o) =>
            {
                this.Close();
            }, null);
        }

        private void numSellStones_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.txtExpense == null)
            {
                return;
            }
            decimal allrmb = GetAllRMB();
            decimal expense = GetExpense(allrmb);
            this.txtExpense.Text = expense.ToString();
            this.txtGetRMB.Text = (allrmb - expense).ToString("0.00");
        }

        private decimal GetAllRMB()
        {
            return (int)this.numSellStones.Value / GlobalData.GameConfig.Stones_RMB;
        }

        private decimal GetExpense(decimal allRMB)
        {
            decimal expense = allRMB * GlobalData.GameConfig.ExchangeExpensePercent / 100;
            if (expense < GlobalData.GameConfig.ExchangeExpenseMinNumber)
            {
                expense = GlobalData.GameConfig.ExchangeExpenseMinNumber;
            }
            return expense;
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            int sellStoneCount = (int)this.numSellStones.Value;
            if (sellStoneCount < 1000)
            {
                MyMessageBox.ShowInfo("每次至少要出售1000块矿石");
                return;
            }

            decimal rmb = GetAllRMB();
            decimal expense = GetExpense(rmb);
            decimal getRMB = rmb - expense;
            if (getRMB <= 0)
            {
                MyMessageBox.ShowInfo("出售" + Strings.Stone + "最少手续费为：" + GlobalData.GameConfig.ExchangeExpenseMinNumber.ToString()
                    + ", 您当前出售的矿石不够支付，无法出售。");
                return;
            }

            App.BusyToken.ShowBusyWindow("正在提交服务器...");
            GlobalData.Client.SellStone(sellStoneCount, null);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
