﻿#pragma checksum "..\..\..\..\View\Controls\NoticeManageControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "73AAAF98B57CB1F660FC36C8CD348798"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace SuperMinersCustomServiceSystem.View.Controls {
    
    
    /// <summary>
    /// NoticeManageControl
    /// </summary>
    public partial class NoticeManageControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridNotices;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectAllNotices;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnclearAllNotices;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteNotices;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateNotices;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateNotices;
        
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
            System.Uri resourceLocater = new System.Uri("/SuperMinersCustomServiceSystem;component/view/controls/noticemanagecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 6 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            ((SuperMinersCustomServiceSystem.View.Controls.NoticeManageControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datagridNotices = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnSelectAllNotices = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            this.btnSelectAllNotices.Click += new System.Windows.RoutedEventHandler(this.btnSelectAllNotices_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnclearAllNotices = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            this.btnclearAllNotices.Click += new System.Windows.RoutedEventHandler(this.btnclearAllNotices_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDeleteNotices = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            this.btnDeleteNotices.Click += new System.Windows.RoutedEventHandler(this.btnDeleteNotices_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnUpdateNotices = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            this.btnUpdateNotices.Click += new System.Windows.RoutedEventHandler(this.btnUpdateNotices_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCreateNotices = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\View\Controls\NoticeManageControl.xaml"
            this.btnCreateNotices.Click += new System.Windows.RoutedEventHandler(this.btnCreateNotices_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

