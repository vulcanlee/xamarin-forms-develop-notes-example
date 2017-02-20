using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFButtonCommand.ViewModels
{

    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 按鈕命令綁定測試狀態
        private bool _按鈕命令綁定測試狀態;
        /// <summary>
        /// 按鈕命令綁定測試狀態
        /// </summary>
        public bool 按鈕命令綁定測試狀態
        {
            get { return this._按鈕命令綁定測試狀態; }
            set { this.SetProperty(ref this._按鈕命令綁定測試狀態, value); }
        }
        #endregion

        #region 不存在按鈕命令綁定測試狀態
        private bool _不存在按鈕命令綁定測試狀態;
        /// <summary>
        /// 不存在按鈕命令綁定測試狀態
        /// </summary>
        public bool 不存在按鈕命令綁定測試狀態
        {
            get { return this._不存在按鈕命令綁定測試狀態; }
            set { this.SetProperty(ref this._不存在按鈕命令綁定測試狀態, value); }
        }
        #endregion

        #region 沒有按鈕命令綁定測試狀態
        private bool _沒有按鈕命令綁定測試狀態;
        /// <summary>
        /// 沒有按鈕命令綁定測試狀態
        /// </summary>
        public bool 沒有按鈕命令綁定測試狀態
        {
            get { return this._沒有按鈕命令綁定測試狀態; }
            set { this.SetProperty(ref this._沒有按鈕命令綁定測試狀態, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        public DelegateCommand<MainPageViewModel> 按鈕命令綁定測試Command { get; set; }
        public DelegateCommand<MainPageViewModel> 按鈕命令綁定CanExecute測試Command { get; set; }

        public DelegateCommand 按鈕命令綁定沒有參數測試Command { get; set; }

        public DelegateCommand<string> 按鈕命令綁定文字測試Command { get; set; }


        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor 建構式
        public MainPageViewModel(INavigationService navigationService)
        {

            #region 相依性服務注入的物件

            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            按鈕命令綁定測試Command = new DelegateCommand<MainPageViewModel>((x) =>
            {

            });
            按鈕命令綁定沒有參數測試Command = new DelegateCommand(() =>
            {

            });
            按鈕命令綁定文字測試Command = new DelegateCommand<string>(x =>
            {

            });
            按鈕命令綁定CanExecute測試Command = new DelegateCommand<MainPageViewModel>(x =>
            {

            },
            x=>
            {
                return 按鈕命令綁定測試狀態;
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
            await Task.Delay(100);
            按鈕命令綁定測試狀態 = false;
            不存在按鈕命令綁定測試狀態 = false;
            沒有按鈕命令綁定測試狀態 = false;
        }
        #endregion

    }
}
