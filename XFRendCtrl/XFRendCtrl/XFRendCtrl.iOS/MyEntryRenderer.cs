using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFRendCtrl;
using XFRendCtrl.iOS;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace XFRendCtrl.iOS
{
    /// <summary>
    /// 這個類別，將會透過 EntryRenderer ，客製 iOS 平台下的文字輸入盒
    /// </summary>
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void
        OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}
