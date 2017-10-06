using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using XFFileDownload.Interfaces;

namespace XFFileDownload.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public DelegateCommand DownloadCommand { get; set; }
        IPublicFileSystem _PublicFileSystem;
        IOpenFileByName _OpenFileByName;
        public MainPageViewModel(INavigationService navigationService,
            IPublicFileSystem publicFileSystem, IOpenFileByName openFileByName)
        {
            _navigationService = navigationService;
            // 注入各平台的非應用程式專屬的沙箱資料夾
            _PublicFileSystem = publicFileSystem;
            // 使用手機內安裝的App，開啟指定的檔案
            _OpenFileByName = openFileByName;

            DownloadCommand = new DelegateCommand(async () =>
            {
                //var filename = "vulcan.pdf";
                //var url = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf";
                var filename = "vulcan.png";
                var url = "https://pluralsight.imgix.net/paths/path-icons/csharp-e7b8fcd4ce.png";

                // 取得要存放該檔案的資料夾
                // FileSystem 為 PCLStorage 提供的應用程式沙箱的相關資料夾
                IFolder rootFolder = _PublicFileSystem.PublicDownloadFolder;
                try
                {
                    // 建立這個檔案
                    IFile file = await rootFolder.CreateFileAsync(filename,
                        CreationCollisionOption.OpenIfExists);
                    // 取得這個檔案的 Stream 物件
                    using (var fooFileStream = await file.OpenAsync(FileAccess.ReadAndWrite))
                    {
                        using (HttpClientHandler handle = new HttpClientHandler())
                        {
                            // 建立 HttpClient 物件
                            using (HttpClient client = new HttpClient(handle))
                            {
                                // 取得指定 URL 的 Stream
                                using (var fooStream = await client.GetStreamAsync(url))
                                {
                                    // 將網路的檔案 Stream 複製到本機檔案上
                                    fooStream.CopyTo(fooFileStream);
                                }
                            }
                        }
                    }

                    _OpenFileByName.OpenFile(file.Path);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }

}
