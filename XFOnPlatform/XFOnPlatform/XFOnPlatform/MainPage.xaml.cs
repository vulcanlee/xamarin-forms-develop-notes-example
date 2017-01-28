using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFOnPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //若要在 C# 中，根據不同作業系統，來處理相關事務，可以使用這個靜態方法 Device.OnPlatform
            Device.OnPlatform(
                    Android: () =>
                    {
                        lblMessage.Text = "我在 Android 系統下";
                    },
                    iOS: () =>
                    {
                        lblMessage.Text = "我在 iOS 系統下";
                    },
                    WinPhone: () =>
                    {
                        lblMessage.Text = "我在 Windows 系統下";
                    });
        }
    }
}
