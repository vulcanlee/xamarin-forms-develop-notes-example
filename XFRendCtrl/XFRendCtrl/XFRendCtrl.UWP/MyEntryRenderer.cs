using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XFRendCtrl;
using XFRendCtrl.UWP;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace XFRendCtrl.UWP
{
    /// <summary>
    /// 這個類別，將會透過 EntryRenderer ，客製 UWP 平台下的文字輸入盒
    /// </summary>
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new SolidColorBrush(Colors.Transparent);
                Control.BorderBrush = new SolidColorBrush(Colors.Transparent);
                //TextBox textBox = Control as TextBox;
                //textBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
                //textBox.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
