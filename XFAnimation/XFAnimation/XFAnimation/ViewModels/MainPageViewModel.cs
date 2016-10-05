using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFAnimation.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand 下一頁Command { get; private set; }
        public DelegateCommand 各自動畫Command { get; private set; }
        public DelegateCommand 串接動畫Command { get; private set; }

        private readonly INavigationService _navigationService;

        public Action 各自動畫Delegate;
        public Action 串接動畫Delegate;
        public Action 頁面消失動畫Delegate;
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            下一頁Command = new DelegateCommand(下一頁);
            各自動畫Command = new DelegateCommand(各自動畫);
            串接動畫Command = new DelegateCommand(串接動畫);
        }

        private void 串接動畫()
        {
            串接動畫Delegate();
        }

        private void 各自動畫()
        {
            各自動畫Delegate();
        }

        private async void 下一頁()
        {
            頁面消失動畫Delegate();
            await Task.Delay(1000);
            await _navigationService.NavigateAsync("NewPage", null, null, false);
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
