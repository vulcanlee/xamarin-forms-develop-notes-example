using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XFSDCard.Infrastructure;

namespace XFSDCard.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region 要寫入檔案的內容
        private string _要寫入檔案的內容;
        /// <summary>
        /// 要寫入檔案的內容
        /// </summary>
        public string 要寫入檔案的內容
        {
            get { return this._要寫入檔案的內容; }
            set { this.SetProperty(ref this._要寫入檔案的內容, value); }
        }
        #endregion

        #region 操作結果
        private string _操作結果;
        /// <summary>
        /// 操作結果
        /// </summary>
        public string 操作結果
        {
            get { return this._操作結果; }
            set { this.SetProperty(ref this._操作結果, value); }
        }
        #endregion

        public DelegateCommand WriteCommand { get; set; }
        public DelegateCommand ReadCommand { get; set; }
        public DelegateCommand CleanCommand { get; set; }

        public string filename { get; set; } = "MyFile.txt";
        public string directory { get; set; } = "DoggyDirectory";

        IExternalStorage _ExternalStorage;
        public MainPageViewModel(IExternalStorage externalStorage)
        {
            _ExternalStorage = externalStorage;

            WriteCommand = new DelegateCommand(() =>
            {
                _ExternalStorage.Write(directory, filename, 要寫入檔案的內容);
                操作結果 = "資料已經寫入";
            });
            ReadCommand = new DelegateCommand(() =>
            {
                操作結果 = _ExternalStorage.Read(directory, filename);
            });
            CleanCommand = new DelegateCommand(() =>
            {
                操作結果 = "";
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
