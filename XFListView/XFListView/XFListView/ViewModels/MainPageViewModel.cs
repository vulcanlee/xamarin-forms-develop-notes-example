using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFListView.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        private readonly INavigationService _navigationService;

        public DelegateCommand ListView基本應用不可修改紀錄Command { get; private set; }
        public DelegateCommand ListView基本應用可修改紀錄Command { get; private set; }
        public DelegateCommand 可變紀錄列高Command { get; private set; }
        public DelegateCommand 固定紀錄列高Command { get; private set; }
        public DelegateCommand 客製化資料列與資料按鈕Command { get; private set; }
        public DelegateCommand 客製化資料列與資料按鈕會失效Command { get; private set; }
        public DelegateCommand 頁首頁尾自動捲動互動功能表Command { get; private set; }
        public DelegateCommand 自動捲動到指定紀錄Command { get; private set; }
        public DelegateCommand 下拉更新Command { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ListView基本應用不可修改紀錄Command = new DelegateCommand(ListView基本應用不可修改紀錄);
            ListView基本應用可修改紀錄Command = new DelegateCommand(ListView基本應用可修改紀錄);
            可變紀錄列高Command = new DelegateCommand(可變紀錄列高);
            固定紀錄列高Command = new DelegateCommand(固定紀錄列高);
            客製化資料列與資料按鈕Command = new DelegateCommand(客製化資料列與資料按鈕);
            客製化資料列與資料按鈕會失效Command = new DelegateCommand(客製化資料列與資料按鈕會失效);
            頁首頁尾自動捲動互動功能表Command = new DelegateCommand(頁首頁尾自動捲動互動功能表);
            自動捲動到指定紀錄Command = new DelegateCommand(自動捲動到指定紀錄);
            下拉更新Command = new DelegateCommand(下拉更新);
    }

        private async void 下拉更新()
        {
            await _navigationService.NavigateAsync("PullToRefreshPage");
        }

        private async void 自動捲動到指定紀錄()
        {
            await _navigationService.NavigateAsync("ScrollToPage");
        }

        private async void 頁首頁尾自動捲動互動功能表()
        {
            await _navigationService.NavigateAsync("HeaderFooterPage");
        }

        private async void 客製化資料列與資料按鈕會失效()
        {
            await _navigationService.NavigateAsync("CustomButtonPage");
        }

        private async void 客製化資料列與資料按鈕()
        {
            await _navigationService.NavigateAsync("CustomButton1Page");
        }

        private async void 固定紀錄列高()
        {
            // 使用 Query String 的方式來傳送參數
            await _navigationService.NavigateAsync("RowHeightPage?UseUneven=false");
        }

        private async void 可變紀錄列高()
        {
            // 使用 NavigationParameters 物件來傳送參數
            var fooPara = new NavigationParameters();
            fooPara.Add("UseUneven", true);
            await _navigationService.NavigateAsync("RowHeightPage", fooPara);
        }

        private async void ListView基本應用可修改紀錄()
        {
            await _navigationService.NavigateAsync("Basic1Page");
        }

        private async void ListView基本應用不可修改紀錄()
        {
            await _navigationService.NavigateAsync("BasicPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
