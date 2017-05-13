using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Prism.Unity;
using Microsoft.Practices.Unity;
using XFMeasureScreen.Helpers;

namespace XFMeasureScreen.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            #region 取得當時螢幕的相關尺寸
            // http://stackoverflow.com/questions/25756087/detecting-iphone-6-6-screen-sizes-in-point-values
            // 取得當時應用程式視窗的設計尺寸
            AppGlobal.DisplayScreenWidth = (double)UIScreen.MainScreen.Bounds.Size.Width;
            AppGlobal.DisplayScreenHeight = (double)UIScreen.MainScreen.Bounds.Size.Height;

            // 取得縮放比率
            AppGlobal.DisplayScaleFactor = (double)UIScreen.MainScreen.Scale;

            // 取得當時應用程式視窗的實際畫素
            AppGlobal.PhysicalDisplayScreenWidth = (double)UIScreen.MainScreen.Bounds.Size.Width* AppGlobal.DisplayScaleFactor;
            AppGlobal.PhysicalDisplayScreenHeight = (double)UIScreen.MainScreen.Bounds.Size.Height* AppGlobal.DisplayScaleFactor;
            #endregion

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
