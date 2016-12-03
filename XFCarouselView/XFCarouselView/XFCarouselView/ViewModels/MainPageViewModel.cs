using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFCarouselView.Models;

namespace XFCarouselView.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #region Zoos
        private ObservableCollection<Zoo> _Zoos;
        /// <summary>
        /// Zoos
        /// </summary>
        public ObservableCollection<Zoo> Zoos
        {
            get { return _Zoos; }
            set { SetProperty(ref _Zoos, value); }
        }
        #endregion

        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            _navigationService = navigationService;
            Zoos = new ObservableCollection<Zoo>
            {
                new Zoo
                {
                ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                Name = "Woodland Park Zoo"
                },
                new Zoo
                {
                ImageUrl =    "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                Name = "Cleveland Zoo"
                },
                new Zoo
                {
                ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                Name = "Phoenix Zoo"
                }
            };

            CarouselView點選Command = new DelegateCommand<SelectedItemChangedEventArgs>( x =>
            {
                var foo = x.SelectedItem as Zoo;
                //await _dialogService.DisplayAlertAsync("Infor", $"Selected {foo.Name}", "OK");

                Title = $"Selected {foo.Name}";
            });
        }

        public DelegateCommand<SelectedItemChangedEventArgs> CarouselView點選Command { get; set; }

        public DelegateCommand CarouselViewTest點選Command { get; set; }


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
