﻿using SuperMinersWPF.StringResources;
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
        public SellStonesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtAllStones.Text = GlobalData.CurrentUser.StockOfStones.ToString();
            this.txtForzenStones.Text = GlobalData.CurrentUser.FreezingStones.ToString();
            this.txtSellableStones.Text = GlobalData.CurrentUser.SellableStones.ToString();
            this.subTxtExpensePercent.Text = GlobalData.GameConfig.ExchangeExpensePercent.ToString();
            this.numSellStones.Maximum = (int)GlobalData.CurrentUser.SellableStones;
        }

        private void numSellStones_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            float allrmb = GetAllRMB();
            int expense = GetExpense(allrmb);
            this.txtExpense.Text = expense.ToString();
            this.txtGetRMB.Text = (allrmb - expense).ToString();
        }

        private float GetAllRMB()
        {
            return (int)this.numSellStones.Value * GlobalData.GameConfig.Stones_RMB; ;
        }

        private int GetExpense(float allRMB)
        {
            int expense = (int)Math.Ceiling(allRMB * GlobalData.GameConfig.ExchangeExpensePercent);
            if (expense < GlobalData.GameConfig.ExchangeExpenseMinNumber)
            {
                expense = (int)GlobalData.GameConfig.ExchangeExpenseMinNumber;
            }
            return expense;
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            float rmb = GetAllRMB();
            int expense = GetExpense(rmb);
            float getRMB = rmb - expense;
            if (getRMB <= 0)
            {
                MyMessageBox.ShowInfo("出售" + Strings.Stone + "最少手续费为：" + GlobalData.GameConfig.ExchangeExpenseMinNumber.ToString()
                    + ", 您当前出售的矿石不够支付，无法出售。");
                return;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
