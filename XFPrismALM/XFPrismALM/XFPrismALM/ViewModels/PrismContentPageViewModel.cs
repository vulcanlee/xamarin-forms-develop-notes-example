using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace XFPrismALM.ViewModels
{
    public class PrismContentPageViewModel : BindableBase, INavigationAware
    {
        INavigationService m_NavigationService;
        public DelegateCommand 回到主頁面Command { get; set; }

        public PrismContentPageViewModel(INavigationService navigationService)
        {
            m_NavigationService = navigationService;

            回到主頁面Command = new DelegateCommand(回到主頁面);
        }

        private async void 回到主頁面()
        {
            await m_NavigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"Page1頁面 進入到 OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"Page1頁面 進入到 OnNavigatedTo");
        }
    }
}
