﻿using MetaData;
using SuperMinersCustomServiceSystem.Model;
using SuperMinersWPF.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMinersWPF.Views
{
    /// <summary>
    /// Interaction logic for StonesMarketUserControl.xaml
    /// </summary>
    public partial class StonesMarketUserControl : UserControl
    {
        private System.Threading.SynchronizationContext _syn;

        public StonesMarketUserControl()
        {
            InitializeComponent();
        }
    }
}
