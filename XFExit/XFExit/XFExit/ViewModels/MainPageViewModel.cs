using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFExit.Interfaces;

namespace XFExit.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public DelegateCommand CloseAppCommand { get; set; }
        IAppExit _AppExit;
        public MainPageViewModel(INavigationService navigationService, IAppExit appExit)
        {
            _navigationService = navigationService;
            _AppExit = appExit;
            CloseAppCommand = new DelegateCommand(() =>
            {
                _AppExit.Exit();
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
