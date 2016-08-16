using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFLifeCycle
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XFLifeCycle.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
        }
    }
}
