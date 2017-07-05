using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SelfInstAPK.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;

namespace SelfInstAPK.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        //public string FullFilename { get; set; }

        public DelegateCommand DownloadCommand { get; set; }
        public DelegateCommand InstallCommand { get; set; }
        IAPK _APK;

        public MainPageViewModel(IAPK apk)
        {
            _APK = apk;
            DownloadCommand = new DelegateCommand(async () =>
            {
                //IFolder rootFolder = FileSystem.Current.LocalStorage;
                //IFolder folder = await rootFolder.CreateFolderAsync("apk", CreationCollisionOption.OpenIfExists);
                //IFile file = await folder.CreateFileAsync("new.apk", CreationCollisionOption.ReplaceExisting);


                //FullFilename = file.Path;

                HttpClientHandler handle = new HttpClientHandler();
                HttpClient client = new HttpClient(handle);
                Title = "正在下載中";
                using (var fooStream = await client.GetStreamAsync("https://github.com/vulcanlee/test/raw/master/com.vulcanlab.task.apk"))
                {
                    _APK.GenApkFile(fooStream);

                    //using (var fooFileStream = await file.OpenAsync(FileAccess.ReadAndWrite))
                    //{
                    //    await fooStream.CopyToAsync(fooFileStream);
                    //}
                }

                Title = "已經下載完成";
            });
            InstallCommand = new DelegateCommand(() =>
            {
                _APK.InstallAPK();
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
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
