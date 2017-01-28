using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFImage.Services
{
    // 更多關於 XAML 擴充標記功能，您可以參考
    //https://developer.xamarin.com/api/type/Xamarin.Forms.Xaml.IMarkupExtension/

    /// <summary>
    /// 這裡，產生一個擴充延伸標記，您可以 XAML 中，直接使用這個擴充延伸標記，就可以回傳一個 ImageSource 物件
    /// </summary>
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null) return null;
            // ImageSource.FromResource 將會從組件 Assembley 內的資源 Resource，讀取出來之後，轉換成為 Image 物件
            // 這裡的組件，指的是核心PCL專案組件
            //    更多關於 ImageSource 的用法，可以參考
            //    https://developer.xamarin.com/api/type/Xamarin.Forms.ImageSource/
            return ImageSource.FromResource(Source);
        }
    }
}
