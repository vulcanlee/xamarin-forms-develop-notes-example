using MyPrismPack2.Helpers;
using MyPrismPack2.Models;
using MyPrismPack2.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MyPrismPack2.ViewModels
{

    public class ListPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SampleItem> MySampleList { get; set; } = new ObservableCollection<SampleItem>();
        public SampleItem MySampleListSelectedItem { get; set; }
        public bool NeedRefresh { get; set; } = true;

        public DelegateCommand MySampleListItemSelectedCommand { get; set; }

        private readonly INavigationService _navigationService;

        public ListPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MySampleListItemSelectedCommand = new DelegateCommand(() =>
            {
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add(MainHelper.ListPassDataKey, MySampleListSelectedItem.Clone());
                _navigationService.NavigateAsync("DetailPage", fooPara);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (NeedRefresh == false)
            {
                var fooItem = parameters[MainHelper.ListReturnDataKey] as SampleItem;
                if (fooItem != null)
                {
                    if (parameters.ContainsKey(MainHelper.ListRemoveActionName))
                    {
                        var fooDeletedItem = MySampleList.FirstOrDefault(x => x.Id == fooItem.Id);
                        MySampleList.Remove(fooDeletedItem);
                    }
                    else if (parameters.ContainsKey(MainHelper.ListUpdateActionName))
                    {
                        var fooUpdatedItem = MySampleList.FirstOrDefault(x => x.Id == fooItem.Id);
                        fooUpdatedItem.Title = fooItem.Title;
                        fooUpdatedItem.Cost = fooItem.Cost;
                        fooUpdatedItem.DateDetail = fooItem.DateDetail;
                        fooUpdatedItem.ShowDate = fooItem.ShowDate;
                    }
                }
            }
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (NeedRefresh)
            {
                Refresh();
                NeedRefresh = !NeedRefresh;
            }

            if (parameters.ContainsKey(MainHelper.DeepAutoLinkPageActionName))
            {
                var fooPage = parameters[MainHelper.DeepAutoLinkPageActionName] as string;
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add(MainHelper.ListPassDataKey, MySampleList[0].Clone());
                _navigationService.NavigateAsync(fooPage, fooPara);
            }
        }

        public void Refresh()
        {
            MySampleList.Clear();

            MyRepository fooRepo = new MyRepository();
            var fooList = fooRepo.GetSampleList();
            foreach (var item in fooList)
            {
                var fooItem = new SampleItem()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Cost = item.Cost,
                    DateDetail = item.DateDetail,
                    ShowDate = item.ShowDate
                };
                
                MySampleList.Add(fooItem);
            }
        }
    }

}
