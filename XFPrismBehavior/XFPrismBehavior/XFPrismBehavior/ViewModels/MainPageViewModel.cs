using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPrismBehavior.ViewModels
{

    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 基本型別與類別的 Property

        #region 請按下我1
        private string _請按下我1;
        /// <summary>
        /// 請按下我1
        /// </summary>
        public string 請按下我1
        {
            get { return this._請按下我1; }
            set { this.SetProperty(ref this._請按下我1, value); }
        }
        #endregion

        #region 請按下我2
        private string _請按下我2;
        /// <summary>
        /// 請按下我2
        /// </summary>
        public string 請按下我2
        {
            get { return this._請按下我2; }
            set { this.SetProperty(ref this._請按下我2, value); }
        }
        #endregion

        #endregion

        #region 集合類別的 Property

        #endregion

        #endregion

        #region Field 欄位

        #region ViewModel 內使用到的欄位
        #endregion

        #region 命令物件欄位

        public DelegateCommand<string> 請按下我Command { get; set; }

        #endregion

        #region 注入物件欄位
        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        #endregion

        #endregion

        #region Constructor 建構式
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            #region 相依性服務注入的物件

            _dialogService = dialogService;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            請按下我Command = new DelegateCommand<string>(async x =>
            {
                await _dialogService.DisplayAlertAsync("資訊", $"你按下的按鈕是: {x}", "確定");
            });
            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await ViewModelInit();
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        /// <summary>
        /// ViewModel 資料初始化
        /// </summary>
        /// <returns></returns>
        private async Task ViewModelInit()
        {
            請按下我1 = "請按下我1";
            請按下我2 = "請按下我2";
            await Task.Delay(100);
        }
        #endregion

    }
}
