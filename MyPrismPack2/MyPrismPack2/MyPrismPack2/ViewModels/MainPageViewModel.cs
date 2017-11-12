using MyPrismPack2.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyPrismPack2.ViewModels
{
    public class MainPageViewModel : INavigationAware, INotifyPropertyChanged
    {
        public DelegateCommand ShowListCommand { get; set; }

        private readonly INavigationService _navigationService;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowListCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("ListPage");
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
