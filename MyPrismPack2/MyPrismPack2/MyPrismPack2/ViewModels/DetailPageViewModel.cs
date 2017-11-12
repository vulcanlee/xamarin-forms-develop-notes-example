using MyPrismPack2.Helpers;
using MyPrismPack2.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace MyPrismPack2.ViewModels
{

    public class DetailPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SampleItem CurrentSampleItem { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SkipCommand { get; set; }

        private readonly INavigationService _navigationService;

        public DetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            DeleteCommand = new DelegateCommand(() =>
            {
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add(MainHelper.ListReturnDataKey, CurrentSampleItem.Clone());
                fooPara.Add(MainHelper.ListRemoveActionName, true);

                _navigationService.GoBackAsync(fooPara);
            });
            SaveCommand = new DelegateCommand(() =>
            {
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add(MainHelper.ListReturnDataKey, CurrentSampleItem.Clone());
                fooPara.Add(MainHelper.ListUpdateActionName, true);

                _navigationService.GoBackAsync(fooPara);
            });
            CancelCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackAsync();
            });

            SkipCommand = new DelegateCommand(() =>
            {
                int fooNavigationStackTotalPages = 0, fooCurrentPageIndex = 0;
                var fooCurrentMainPage = App.Current.MainPage;

                fooNavigationStackTotalPages = fooCurrentMainPage.Navigation.NavigationStack.Count;
                fooCurrentPageIndex = fooCurrentMainPage.Navigation.NavigationStack.Count - 1;
                Page fooSkipPage = fooCurrentMainPage.Navigation.NavigationStack[fooCurrentPageIndex - 1];
                fooCurrentMainPage.Navigation.RemovePage(fooSkipPage);
                _navigationService.GoBackAsync();
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(MainHelper.ListPassDataKey))
            {
                CurrentSampleItem = parameters[MainHelper.ListPassDataKey] as SampleItem;
            }
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }

}
