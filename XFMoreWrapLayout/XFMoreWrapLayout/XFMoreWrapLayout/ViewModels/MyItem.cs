using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFMoreWrapLayout.ViewModels
{
    public class MyItem : BindableBase
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region Name
        private string _Name;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return this._Name; }
            set { this.SetProperty(ref this._Name, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        #endregion

        #region Constructor 建構式
        public MyItem()
        {

        }
        #endregion

        #region Navigation Events (頁面導航事件)
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
