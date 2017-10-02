using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using XFExit.Interfaces;
using XFExit.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AppExit))]
namespace XFExit.iOS.Services
{
    public class AppExit : IAppExit
    {
        public void Exit()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            //Thread.CurrentThread.Abort();
        }
    }
}
