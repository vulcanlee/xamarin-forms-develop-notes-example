using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace XFPrismALM.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        INavigationService m_NavigationService;

        public DelegateCommand 開啟新頁面Command { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            m_NavigationService = navigationService;

            開啟新頁面Command = new DelegateCommand(開啟新頁面);
        }

        private async void 開啟新頁面()
        {
            await m_NavigationService.NavigateAsync("PrismContentPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"主頁面 進入到 OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"主頁面 進入到 OnNavigatedTo");
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
