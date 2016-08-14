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
