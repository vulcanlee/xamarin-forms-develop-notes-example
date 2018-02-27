using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XFRowColor.Helpers;

namespace XFRowColor.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyItemVM> MyItemVMList { get; set; } = new ObservableCollection<MyItemVM>();
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            for (int i = 0; i < 100; i++)
            {
                var foo = new MyItemVM()
                {
                    Name = $"這是一筆紀錄，編號為 {i}",
                };
                if(i%2==0)
                {
                    foo.CellBackgroundColor = MainHelper.EvenColor;
                }
                else
                {
                    foo.CellBackgroundColor = MainHelper.OddColor;
                }
                MyItemVMList.Add(foo);
            }
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
