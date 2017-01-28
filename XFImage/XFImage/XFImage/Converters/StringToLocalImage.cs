using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFImage.Converters
{
    /// <summary>
    /// 這個數值轉換器，將會把一個字串，轉換成為一個 Image 物件
    /// 不過，這個圖片是存在於應用程式的專屬儲存空間內，不是在專案的資源中
    /// </summary>
    class StringToLocalImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string foo1 = value as string;
            ImageSource fooImageSource=null;

            if (string.IsNullOrEmpty(foo1) == false)
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder;
                IFile file;
                folder = rootFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists).Result;
                //取得這個圖片檔案
                file = folder.GetFileAsync(foo1).Result;
                //開啟這個圖片檔案
                var fooStream = file.OpenAsync(FileAccess.Read).Result;
                Debug.WriteLine($"Length: {fooStream.Length}");

                //將這個圖片檔案的 Stream，經過 ImageSource.FromStream 轉換成為 Image 物件
                //    更多關於 ImageSource 的用法，可以參考
                //    https://developer.xamarin.com/api/type/Xamarin.Forms.ImageSource/
                fooImageSource = ImageSource.FromStream(() => fooStream);
            }
            else
            {
            }

            //fooImageSource= ImageSource.FromUri(new Uri("https://developer.xamarin.com/demo/IMG_1415.JPG?height=640"));

            return fooImageSource;
        }

        // 一般來說，您不太需要時做這個方法
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
