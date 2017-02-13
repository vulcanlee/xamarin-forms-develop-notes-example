using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFWebViewBusy.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region Url
        private string _Url;
        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get { return this._Url; }
            set { this.SetProperty(ref this._Url, value); }
        }
        #endregion

        #region Isbusy
        private bool _Isbusy;
        /// <summary>
        /// Isbusy
        /// </summary>
        public bool Isbusy
        {
            get { return this._Isbusy; }
            set { this.SetProperty(ref this._Isbusy, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public MainPageViewModel()
        {

        }
        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Url = "http://mylabtw.blogspot.com/";
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        #endregion



    }
}
