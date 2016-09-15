using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Net.Http;
using PCLStorage;
using Xamarin.Forms;

namespace XFImage.ViewModels
{
    public class IndependentImagePageViewModel : BindableBase, INavigationAware
    {
        private string pclImage;
        public string PCLImage
        {
            get { return pclImage; }
            set { SetProperty(ref pclImage, value); }
        }

        private string localImage1;
        public string LocalImage1
        {
            get { return localImage1; }
            set { SetProperty(ref localImage1, value); }
        }

        private string localImage2;
        public string LocalImage2
        {
            get { return localImage2; }
            set { SetProperty(ref localImage2, value); }
        }

        private string _下載背景顏色;
        public string 下載背景顏色
        {
            get { return _下載背景顏色; }
            set { SetProperty(ref _下載背景顏色, value); }
        }

        private ImageSource myImageSource;
        public ImageSource MyImageSource
        {
            get { return myImageSource; }
            set { SetProperty(ref myImageSource, value); }
        }

        public DelegateCommand 下載圖片Command { get; private set; }
        public IndependentImagePageViewModel()
        {
            下載圖片Command = new DelegateCommand(下載圖片);

            LocalImage1 = "platformImage.jpg";
            下載背景顏色 = "White";
        }

        private async void 下載圖片()
        {
            下載背景顏色 = "Red";

            #region 從網路下載後，先儲存到本機檔案系統內，接著再讀出來，進行圖片資料綁定
            HttpClient client = new HttpClient();
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyLocalImage.jpg", CreationCollisionOption.ReplaceExisting);
            using (var fooTargetStream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                using (var fooSourceString = await client.GetStreamAsync("https://developer.xamarin.com/demo/IMG_3256.JPG?width=640"))
                {
                    await fooSourceString.CopyToAsync(fooTargetStream);
                }
            }

            file = await folder.GetFileAsync("MyLocalImage.jpg");
            var fooTargetReadStream = await file.OpenAsync(FileAccess.Read);
            MyImageSource = ImageSource.FromStream(() => fooTargetReadStream);
            #endregion

            #region 直接從網路下載後，就進行圖片資料綁定
            //HttpClient client = new HttpClient();
            //var fooSourceString = await client.GetStreamAsync("https://developer.xamarin.com/demo/IMG_3256.JPG?width=640");
            //MyImageSource = ImageSource.FromStream(() => fooSourceString);
            #endregion

            下載背景顏色 = "Green";
            LocalImage2 = "MyLocalImage.jpg";

            PCLImage = "";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
