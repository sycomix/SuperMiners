﻿using System;
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
    /// Interaction logic for RouletteRoundRecordListControl.xaml
    /// </summary>
    public partial class RouletteRoundRecordListControl : UserControl
    {
        public RouletteRoundRecordListControl()
        {
            InitializeComponent();

            this.dgRecords.ItemsSource = App.GameRouletteVMObject.ListRoundRecords;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            App.GameRouletteVMObject.AsyncGetAllRouletteRoundInfo();
        }
    }
}