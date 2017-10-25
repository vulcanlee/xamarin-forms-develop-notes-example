using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XFListViewLazy.Models;
using XFListViewLazy.Repositories;

namespace XFListViewLazy.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<MyModel> MyDatas { get; set; } = new ObservableCollection<MyModel>();
        public MyModel SelectedMyData { get; set; }

        private readonly INavigationService _navigationService;
        public MyRepository _myRepository { get; set; }

        public DelegateCommand<MyModel> ItemAppearingCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _myRepository = MyRepository.GetInstance();

            ItemAppearingCommand = new DelegateCommand<MyModel>((x) =>
            {
                var fooLast = MyDatas.Last();
                if (x.ID == fooLast.ID)
                {
                    Reload(fooLast.ID+1);
                }
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
            Reload(0);
        }

        public void Reload(int last)
        {
            var foo = _myRepository.GetNext(last);
            foreach (var item in foo)
            {
                MyDatas.Add(item);
            }
        }

    }

}
