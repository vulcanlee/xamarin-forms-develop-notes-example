using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XFCreative.Models;
using XFCreative.Services;

namespace XFCreative.ViewModels
{
    public class SelectCityPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        #region 所有縣市 清單
        private ObservableCollection<縣市節點ViewModel> _所有縣市 = new ObservableCollection<縣市節點ViewModel>();
        public ObservableCollection<縣市節點ViewModel> 所有縣市
        {
            get { return this._所有縣市; }
            set { this.SetProperty(ref this._所有縣市, value); }
        }
        #endregion

        public DelegateCommand 所有縣市ItemSelectedCommand { get; set; }
        public 縣市節點ViewModel 所有縣市Selected { get; set; }

        public SelectCityPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            所有縣市ItemSelectedCommand = new DelegateCommand(所有縣市ItemSelected);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await 系統初始化();
        }

        public async Task 系統初始化()
        {
            所有縣市.Clear();
            var fooItems = GlobalData.創業空間Repository.Items.Select(x => x.縣市區域).Distinct().OrderByDescending(x => x);
            foreach (var item in fooItems)
            {
                var fooItem = new 縣市節點ViewModel
                {
                     縣市 = item,
                };
                所有縣市.Add(fooItem);
            }
        }

        private void 所有縣市ItemSelected()
        {
            _eventAggregator.GetEvent<需要篩選資料Event>().Publish(所有縣市Selected.縣市);
            _navigationService.GoBack();
        }

    }
}
