using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using XFMeasureScreen.Helpers;

namespace XFMeasureScreen.Droid
{
    [Activity(Label = "XFMeasureScreen", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            #region 取得當時螢幕的相關尺寸
            // DisplayMetrics : https://developer.android.com/reference/android/util/DisplayMetrics.html
            // 使用 DisplayMetrics 類別，取得這個裝置的螢幕可用的設計畫素資訊與設計尺寸的縮放比，並且儲存到 PCL 的 App 類別靜態屬性
            //  螢幕寬度的設計畫素計算公式 Width = WidthPixels / Density
            //  螢幕高度的設計畫素計算公式 Height = HeightPixels / Density

            // 取得當時應用程式視窗的設計尺寸
            AppGlobal.DisplayScreenWidth = (double)Resources.DisplayMetrics.WidthPixels / (double)Resources.DisplayMetrics.Density;
            AppGlobal.DisplayScreenHeight = (double)Resources.DisplayMetrics.HeightPixels / (double)Resources.DisplayMetrics.Density;

            // 取得縮放比率
            AppGlobal.DisplayScaleFactor = (double)Resources.DisplayMetrics.Density;

            // 取得當時應用程式視窗的實際畫素
            AppGlobal.PhysicalDisplayScreenWidth = (double)Resources.DisplayMetrics.WidthPixels;
            AppGlobal.PhysicalDisplayScreenHeight = (double)Resources.DisplayMetrics.HeightPixels;
            #endregion

            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

