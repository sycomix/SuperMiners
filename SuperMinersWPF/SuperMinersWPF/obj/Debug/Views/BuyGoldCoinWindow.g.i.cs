﻿#pragma checksum "..\..\..\Views\BuyGoldCoinWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1D21DA57D0FACD63F2158AC9F8D72EED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SuperMinersWPF.MyControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SuperMinersWPF.Views {
    
    
    /// <summary>
    /// BuyGoldCoinWindow
    /// </summary>
    public partial class BuyGoldCoinWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRMB;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtRMB_GoldCoin;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SuperMinersWPF.MyControl.NumericTextBox numRechargeRMB;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPayUnit;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPayType;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGainGoldCoin;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtError;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\BuyGoldCoinWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SuperMinersWPF;component/views/buygoldcoinwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\BuyGoldCoinWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\Views\BuyGoldCoinWindow.xaml"
            ((SuperMinersWPF.Views.BuyGoldCoinWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\Views\BuyGoldCoinWindow.xaml"
            ((SuperMinersWPF.Views.BuyGoldCoinWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRMB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtRMB_GoldCoin = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.numRechargeRMB = ((SuperMinersWPF.MyControl.NumericTextBox)(target));
            return;
            case 5:
            this.txtPayUnit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.cmbPayType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\Views\BuyGoldCoinWindow.xaml"
            this.cmbPayType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbPayType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtGainGoldCoin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Views\BuyGoldCoinWindow.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Views\BuyGoldCoinWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

