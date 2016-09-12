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
                file = folder.GetFileAsync(foo1).Result;
                var fooStream = file.OpenAsync(FileAccess.Read).Result;
                Debug.WriteLine($"Length: {fooStream.Length}");

                fooImageSource = ImageSource.FromStream(() => fooStream);
            }
            else
            {
            }

            //fooImageSource= ImageSource.FromUri(new Uri("https://developer.xamarin.com/demo/IMG_1415.JPG?height=640"));

            return fooImageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
