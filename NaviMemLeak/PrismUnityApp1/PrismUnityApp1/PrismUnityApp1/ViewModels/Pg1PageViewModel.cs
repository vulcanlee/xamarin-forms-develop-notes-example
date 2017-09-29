using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PrismUnityApp1.ViewModels
{

    public class Pg1PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public DelegateCommand GotoPage2Command { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        public Pg1PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GotoPage2Command = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("Pg2Page");
            });
            GoBackCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackAsync();
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
