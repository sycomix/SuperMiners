﻿#pragma checksum "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C5BA785E29AE86AF42F665A99840A0E"
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


namespace SuperMinersCustomServiceSystem.View.Windows {
    
    
    /// <summary>
    /// EditPlayerPasswordWindow
    /// </summary>
    public partial class EditPlayerPasswordWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtNewPassword;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txxtConfirmPassword;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
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
            System.Uri resourceLocater = new System.Uri("/SuperMinersCustomServiceSystem;component/view/windows/editplayerpasswordwindow.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
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
            
            #line 4 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
            ((SuperMinersCustomServiceSystem.View.Windows.EditPlayerPasswordWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtNewPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.txxtConfirmPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\View\Windows\EditPlayerPasswordWindow.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
