using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public ObservableCollection<string> FileSourceTypes { get; set; } = new ObservableCollection<string>();
        public string FileSourceTypeSelect { get; set; }
        public bool ShowMask { get; set; } = false;
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
                ShowMask = true;
                // https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types
                // http://www.feedforall.com/mime-types.htm
                string mimeType = "text/plain";
                #region 依據所選擇的項目，設定下載來源與檔案名稱
                string filename = "";
                string url = "";
                if (FileSourceTypeSelect.ToLower() == "pdf")
                {
                    filename = "vulcan.pdf";
                    mimeType = "application/pdf";
                    url = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf";
                }
                else if (FileSourceTypeSelect.ToLower() == "image")
                {
                    filename = "vulcan.png";
                    mimeType = "image/png";
                    url = "https://pluralsight.imgix.net/paths/path-icons/csharp-e7b8fcd4ce.png";
                }
                else if (FileSourceTypeSelect.ToLower() == "mp3")
                {
                    filename = "vulcan.mp3";
                    mimeType = "audio/mpeg";
                    url = "http://video.ch9.ms/ch9/4855/ca67b144-e675-48a2-a0f2-706af9644855/DataTemplateSelector.mp3";
                }
                else if (FileSourceTypeSelect.ToLower() == "video")
                {
                    filename = "vulcan.mp4";
                    mimeType = "video/mpeg";
                    url = "http://video.ch9.ms/ch9/4855/ca67b144-e675-48a2-a0f2-706af9644855/DataTemplateSelector.mp4";
                }
                else if (FileSourceTypeSelect.ToLower() == "ppt")
                {
                    filename = "vulcan.ppt";
                    mimeType = "application/vnd.ms-powerpoint";
                    url = "http://people.csail.mit.edu/mrub/talks/small_world/Seminar07_rubinstein.ppt";
                }
                else if (FileSourceTypeSelect.ToLower() == "doc")
                {
                    filename = "vulcan.doc";
                    mimeType = "application/msword";
                    url = "http://im2.nhu.edu.tw/download.php?filename=270_2af7568a.doc&dir=personal_subject/&title=C%23-%E7%AC%AC%E4%B8%80%E7%AB%A0";
                }
                #endregion

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

                    _OpenFileByName.MakeDownloadFolder(file.Path, mimeType);
                    _OpenFileByName.OpenFile(file.Path);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                ShowMask = false;
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
            FileSourceTypes.Clear();
            FileSourceTypes.Add("PDF");
            FileSourceTypes.Add("Image");
            FileSourceTypes.Add("MP3");
            FileSourceTypes.Add("Video");
            FileSourceTypes.Add("PPT");
            FileSourceTypes.Add("Doc");

        }

    }

}
