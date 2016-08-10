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

namespace XFCreative.ViewModels
{
    public class HomePageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public HomePageViewModel(INavigationService navigationService)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " ...";

            await 系統初始化();
        }

        public async Task 系統初始化()
        {
        }

    }
}
