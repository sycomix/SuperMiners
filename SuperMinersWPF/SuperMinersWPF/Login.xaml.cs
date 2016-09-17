﻿using MetaData.SystemConfig;
using MetaData.User;
using SuperMinersWPF.Models;
using SuperMinersWPF.StringResources;
using SuperMinersWPF.Utility;
using SuperMinersWPF.Wcf.Channel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperMinersWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private SynchronizationContext _syn;
        private bool isHidden = false;
        Window1 winMain = null;

        public Login()
        {
            InitializeComponent();

            this.Title = Strings.Title + System.Configuration.ConfigurationManager.AppSettings["softwareversion"];

            isHidden = false;

            LogHelper.Instance.Init();
            this._syn = SynchronizationContext.Current;
            GlobalData.Client.SetContext(this._syn);
            App.UserVMObject.GetPlayerInfoCompleted += UserVMObject_GetPlayerInfoCompleted;
            GlobalData.Client.LoginCompleted += Client_LoginCompleted;
            App.MessageVMObject.GetSystemConfigCompleted += MessageVMObject_GetSystemConfigCompleted;
            this.txtUserName.Focus();
        }

        void MessageVMObject_GetSystemConfigCompleted(bool obj)
        {
            if (obj)
            {
                App.UserVMObject.AsyncGetPlayerInfo();
            }
            else
            {
                App.BusyToken.CloseBusyWindow();
                GlobalData.Client.Logout();
            }
        }

        void UserVMObject_GetPlayerInfoCompleted(object sender, EventArgs e)
        {
            App.BusyToken.CloseBusyWindow();
            GlobalData.Client.HandleCallback();
            if (!isHidden)
            {
                isHidden = true;
                winMain = new Window1();
                winMain.Closed += winMain_Closed;
                this.Visibility = System.Windows.Visibility.Hidden;
                winMain.Show();
                //GlobalData.Client.GetPlayerInfo();
            }
        }

        void Client_LoginCompleted(object sender, Wcf.Clients.WebInvokeEventArgs<string> e)
        {
            if (e.Cancelled)
            {
                App.BusyToken.CloseBusyWindow();
                return;
            }

            if (e.Error != null)
            {
                App.BusyToken.CloseBusyWindow();
                LogHelper.Instance.AddErrorLog("服务器连接失败。", e.Error);
                MyMessageBox.ShowInfo("服务器连接失败。");
                return;
            }

            if (string.IsNullOrEmpty(e.Result))
            {
                App.BusyToken.CloseBusyWindow();
                MyMessageBox.ShowInfo("用户名不存在，或密码不正确。");
                return;
            }

            if (e.Result == "LOCKED")
            {
                App.BusyToken.CloseBusyWindow();
                MyMessageBox.ShowInfo("您的账户已经被管理员禁用，请联系管理员。");
                return;
            }
            if (e.Result == "ISLOGGED")
            {
                App.BusyToken.CloseBusyWindow();
                MyMessageBox.ShowInfo("您的账户正在其它客户端登录，我们已将对方退出，请重新登录。");
                return;
            }
            if (e.Result == "TESTUSERLOGFAILED")
            {
                App.BusyToken.CloseBusyWindow();
                MyMessageBox.ShowInfo("您当前登录账户为测试玩家，要求同一账户只能在一台电脑登录，且一台电脑只能登录一个账户。");
                return;
            }

            this._syn.Post(o =>
            {
                this.txtUserName.Text = "";
                this.txtPassword.Password = "";
            }, null);

            GlobalData.InitToken(e.Result);

            //e.Continue = true;

            App.MessageVMObject.AsyncGetSystemConfig();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginAync();
        }

        private void LoginAync()
        {
            if (!CryptEncoder.Ready)
            {
                //MyMessageBox.ShowInfo("正在初始化，请等待...");
                return;
            }

            if (this.txtUserName.Text.Length == 0)
            {
                MyMessageBox.ShowInfo("请输入用户名");
                return;
            }

            if (this.txtPassword.Password.Length == 0)
            {
                MyMessageBox.ShowInfo("请输入密码");
                return;
            }

            GlobalData.InitToken(null);

#if DEBUG
            GlobalData.Client.Init(GlobalData.DebugServer);
#else
            string serverUri = System.Configuration.ConfigurationManager.AppSettings["ServerUri"];
            if (string.IsNullOrEmpty(serverUri))
            {
                MyMessageBox.ShowInfo("找不到服务器Uri地址，请联系系统管理员，或者安装最新版本。");
                return;
            }

            GlobalData.Client.Init(serverUri);
#endif
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Password;
            string mac = GetMac();

            App.BusyToken.ShowBusyWindow("正在加载...");
            GlobalData.Client.Login(userName, password, CryptEncoder.Key, mac);
        }

        private string GetMac()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象

            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet3Megabit || adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up && adapter.Speed > 0)
                    {
                        // 格式化显示MAC地址               
                        PhysicalAddress pa = adapter.GetPhysicalAddress();//获取适配器的媒体访问（MAC）地址
                        byte[] bytes = pa.GetAddressBytes();//返回当前实例的地址
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            sb.Append(bytes[i].ToString("X2"));//以十六进制格式化
                            if (i != bytes.Length - 1)
                            {
                                sb.Append("-");
                            }
                        }

                        return sb.ToString();
                    }
                }
            }

            return null;
        }

        void winMain_Closed(object sender, EventArgs e)
        {
            if (winMain != null && winMain.IsBackToLogin)
            {
                this.isHidden = false;
                this.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.Close();
                Environment.Exit(0);
                
            }
        }

        private void hlinkForgetPassword_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            //Process.Start(new ProcessStartInfo(e.Uri.ToString()));
            //e.Handled = true;
        }

        private void hlinkRegister_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MyWebPage.ShowMyWebPage("Register.aspx");
            e.Handled = true;
        }

        private void hlinkHomePage_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MyWebPage.ShowMyWebPage("");
            e.Handled = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void panelTopBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
