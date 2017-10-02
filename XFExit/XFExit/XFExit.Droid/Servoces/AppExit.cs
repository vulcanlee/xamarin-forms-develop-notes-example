using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFExit.Droid.Servoces;
using XFExit.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AppExit))]
namespace XFExit.Droid.Servoces
{
    class AppExit : IAppExit
    {
        public void Exit()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}