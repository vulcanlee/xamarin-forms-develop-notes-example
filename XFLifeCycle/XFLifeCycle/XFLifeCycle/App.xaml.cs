using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFLifeCycle
{
    // 這個專案練習將會練習 Xamarin.Forms 的應用程式生命週期
    // 您需要執行這個專案，觀察 Visual Studio 內的輸出視窗，觀察輸出內容
    // 請試著將應用程式切換為背景模式，並且再度切換成為前景
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XFLifeCycle.MainPage();
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("我正在啟動應用程式 OnStart");
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("我準備要去睡覺了 OnSleep");
        }

        /// <summary>
        /// Application developers override this method to perform actions when the app resumes from a sleeping state.
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("我睡醒了 OnResume");
        }
    }
}
