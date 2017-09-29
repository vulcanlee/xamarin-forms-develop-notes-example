using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PrismUnityApp1.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public DelegateCommand GotoPage1Command { get; set; }
        public DelegateCommand GCCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GotoPage1Command = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("Pg1Page");
            });
            ResetCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("xf:///NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            });
            GCCommand = new DelegateCommand(() =>
            {
                GC.Collect();
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
