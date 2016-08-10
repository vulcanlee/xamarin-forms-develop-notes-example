using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XFCreative.Models;
using XFCreative.Services;

namespace XFCreative.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " ...";

            await 系統初始化();

            await _navigationService.Navigate("/HomePage/BusinessSpacePage");
        }

        public async Task 系統初始化()
        {
            var fooItems = await GlobalData.系統紀錄Repository.資料表.GetAllAsync();
            if (fooItems.Count == 1)
            {

            }
            else
            {
                foreach (var item in fooItems)
                {
                    await GlobalData.系統紀錄Repository.資料表.DeleteAsync(item);
                }

                await GlobalData.系統紀錄Repository.資料表.InsertAsync(new 系統紀錄
                {
                    篩選城市 = "高雄市"
                });
            }
            await GlobalData.創業空間Repository.取得最新資料();
        }
    }
}
