using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XFCreative.Models;
using XFCreative.Services;

namespace XFCreative.ViewModels
{
    public class WebView更多資訊PageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private 網頁資料NodeViewModel _網頁資料NodeViewModel;
        public 網頁資料NodeViewModel 網頁資料NodeViewModel
        {
            get { return _網頁資料NodeViewModel; }
            set { SetProperty(ref _網頁資料NodeViewModel, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public WebView更多資訊PageViewModel(INavigationService navigationService)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("網頁資料NodeViewModel"))
            {
                網頁資料NodeViewModel = parameters["網頁資料NodeViewModel"] as 網頁資料NodeViewModel;
            }
        }
    }
}
