﻿#pragma checksum "..\..\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1E29E5DF90BC73294F45F6D836CC1B87"
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


namespace SuperMinersWPF {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink hlinkRegister;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink hlinkForgetPassword;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink hlinkHomePage;
        
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
            System.Uri resourceLocater = new System.Uri("/SuperMinersWPF;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
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
            
            #line 5 "..\..\Login.xaml"
            ((SuperMinersWPF.Login)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.panelTopBorder_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Login.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.hlinkRegister = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 39 "..\..\Login.xaml"
            this.hlinkRegister.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.hlinkRegister_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.hlinkForgetPassword = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 44 "..\..\Login.xaml"
            this.hlinkForgetPassword.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.hlinkForgetPassword_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Login.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.hlinkHomePage = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 48 "..\..\Login.xaml"
            this.hlinkHomePage.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.hlinkHomePage_RequestNavigate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

