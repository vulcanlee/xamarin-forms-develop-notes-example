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
using System.Linq;
using Plugin.Share;
using Plugin.ExternalMaps;

namespace XFCreative.ViewModels
{
    public class BusinessSpacePageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand RefreshDataCommand { get; set; }
        public DelegateCommand 搜尋Command { get; set; }
        public DelegateCommand 創業空間ItemSelectedCommand { get; set; }

        #region 創業空間NodeViewModel 清單
        private ObservableCollection<創業空間NodeViewModel> _創業空間Nodes = new ObservableCollection<創業空間NodeViewModel>();
        public ObservableCollection<創業空間NodeViewModel> 創業空間Nodes
        {
            get { return this._創業空間Nodes; }
            set { this.SetProperty(ref this._創業空間Nodes, value); }
        }
        #endregion

        #region 創業空間Selected
        public 創業空間NodeViewModel 創業空間Selected { get; set; }
        #endregion

        public Action 回到ListView最前面;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BusinessSpacePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            RefreshDataCommand = new DelegateCommand(RefreshData);
            搜尋Command = new DelegateCommand(搜尋);

            創業空間ItemSelectedCommand = new DelegateCommand(創業空間ItemSelected);

            _eventAggregator.GetEvent<需要篩選資料Event>().Subscribe(需要篩選資料HandleEvent);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " ...";

            await 系統初始化();
        }

        public async Task 系統初始化()
        {
            創業空間Nodes.Clear();
            var fooItems = await GlobalData.系統紀錄Repository.資料表.GetAllAsync();
            var fooIt = fooItems.FirstOrDefault();
            var foo創業空間s = GlobalData.創業空間Repository.Items.Where(x => x.縣市區域 == fooIt.篩選城市);

            foreach (var item in foo創業空間s)
            {
                var fooItem = new 創業空間NodeViewModel()
                {
                    使用坪數 = item.使用坪數,
                    創業空間名稱 = item.創業空間名稱,
                    地址 = item.地址,
                    空間主照片 = item.空間主照片.Replace("https", "http")
                };

                創業空間Nodes.Add(fooItem);
            }
        }

        private async void RefreshData()
        {
            var fooNavPara = new NavigationParameters();
            fooNavPara.Add("title", "使用者要求重新整理");
            await _navigationService.Navigate("/MainPage", fooNavPara);
        }

        private async void 搜尋()
        {
            await _navigationService.Navigate("SelectCityPage");
        }

        private async void 創業空間ItemSelected()
        {
            var foo創業空間Selected = new NavigationParameters();
            foo創業空間Selected.Add("創業空間Selected", 創業空間Selected);
            await _navigationService.Navigate("BusinessSpaceDetailPage", foo創業空間Selected);
        }

        private async void 需要篩選資料HandleEvent(string obj)
        {
            var fooPItems = await GlobalData.系統紀錄Repository.資料表.GetAllAsync();
            var fooIt = fooPItems.FirstOrDefault();
            fooIt.篩選城市 = obj;
            await GlobalData.系統紀錄Repository.資料表.UpdateAsync(fooIt);

            創業空間Nodes = new ObservableCollection<創業空間NodeViewModel>();
            var fooItems = GlobalData.創業空間Repository.Items.Where(x => x.縣市區域 == obj);
            foreach (var item in fooItems)
            {
                var fooItem = new 創業空間NodeViewModel()
                {
                    使用坪數 = item.使用坪數,
                    創業空間名稱 = item.創業空間名稱,
                    地址 = item.地址,
                    空間主照片 = item.空間主照片.Replace("https", "http")
                };

                創業空間Nodes.Add(fooItem);
            }

            回到ListView最前面?.Invoke();

            //if (回到ListView最前面 != null)
            //{
            //    回到ListView最前面();
            //}

        }

    }
}
