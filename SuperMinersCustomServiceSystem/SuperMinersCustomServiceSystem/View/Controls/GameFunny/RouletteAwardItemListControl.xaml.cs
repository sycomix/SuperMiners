﻿using SuperMinersCustomServiceSystem.Model;
using SuperMinersCustomServiceSystem.Uility;
using SuperMinersCustomServiceSystem.View.Windows;
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

namespace SuperMinersCustomServiceSystem.View.Controls.GameFunny
{
    /// <summary>
    /// Interaction logic for RouletteAwardItemListControl.xaml
    /// </summary>
    public partial class RouletteAwardItemListControl : UserControl
    {
        public RouletteAwardItemListControl()
        {
            InitializeComponent();
            this.dgRecords.ItemsSource = App.GameRouletteVMObject.ListRouletteAwardItems;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetAwardItems();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            RouletteAwardItemUIModel awarditem = btn.DataContext as RouletteAwardItemUIModel;
            if (awarditem != null)
            {
                EditRouletteAwardItemWindow win = new EditRouletteAwardItemWindow(awarditem);
                win.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (App.GameRouletteVMObject.ListRouletteAwardItems.Count == 12)
            {
                MyMessageBox.ShowInfo("最多只能添加12个奖项");
                return;
            }

            EditRouletteAwardItemWindow win = new EditRouletteAwardItemWindow(App.GameRouletteVMObject.ListRouletteAwardItems.Count);
            win.ShowDialog();
        }

        private void btnSaveAllAwardItems_Click(object sender, RoutedEventArgs e)
        {
            App.GameRouletteVMObject.AsyncSaveAllAwardItem();
        }
    }
}