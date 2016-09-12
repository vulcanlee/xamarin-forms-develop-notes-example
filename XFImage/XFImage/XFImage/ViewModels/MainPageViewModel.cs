using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFImage.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        INavigationService NavigationService;
        public DelegateCommand 圖片大小與填滿Command { get; private set; } 
        public DelegateCommand 圖片資源Command { get; private set; } 
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            圖片大小與填滿Command = new DelegateCommand(圖片大小與填滿);
            圖片資源Command = new DelegateCommand(圖片資源);
        }

        private async void 圖片資源()
        {
          await  NavigationService.NavigateAsync("IndependentImagePage");
        }

        private async void 圖片大小與填滿()
        {
            await NavigationService.NavigateAsync("AspectPage");
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
