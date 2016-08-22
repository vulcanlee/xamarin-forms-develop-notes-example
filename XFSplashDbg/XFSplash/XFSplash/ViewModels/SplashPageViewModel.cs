using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFSplash.ViewModels
{
    public class SplashPageViewModel : BindableBase, INavigationAware
    {
        #region Field
        INavigationService _navigationService;
        #endregion

        #region ViewModel Property

        #region 處理訊息
        private string _處理訊息 = "系統執行中...";

        public string 處理訊息
        {
            get { return _處理訊息; }
            set { SetProperty(ref _處理訊息, value); }
        }
        #endregion

        #region 處理進度百分比
        private double _處理進度百分比 = 0;

        public double 處理進度百分比
        {
            get { return _處理進度百分比; }
            set { SetProperty(ref _處理進度百分比, value); }
        }
        #endregion

        #region 版本資訊
        private string _版本資訊 = "版本:1.2.4";

        public string 版本資訊
        {
            get { return _版本資訊; }
            set { SetProperty(ref _版本資訊, value); }
        }

        #endregion

        #endregion

        public SplashPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await 系統初始化();
        }

        private async Task 系統初始化()
        {
            double fooPer = 0.0;
            await Task.Delay(800);
            for (int i = 0; i < 101; i++)
            {
                fooPer = i / 100.0;
                處理進度百分比 = fooPer;
                if (i < 40)
                {
                    處理訊息 = "讀取本機資源中，請稍後";
                    await Task.Delay(170);
                }
                else if (i < 90)
                {
                    處理訊息 = "更新網路上最新資源";
                    await Task.Delay(30);
                }
                else
                {
                    處理訊息 = "即將完成";
                    await Task.Delay(120);
                }
            }

            處理訊息 = "導航到首頁頁面";
            await _navigationService.NavigateAsync("MainPage?title=恭喜您，已經完成 Splash 練習");
        }
    }
}
