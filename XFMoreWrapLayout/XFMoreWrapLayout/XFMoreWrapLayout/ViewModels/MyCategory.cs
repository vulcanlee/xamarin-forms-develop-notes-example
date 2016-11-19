using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XFMoreWrapLayout.ViewModels
{
    public class MyCategory : BindableBase
    {

        #region CategoryName
        private string _CategoryName;
        /// <summary>
        /// CategoryName
        /// </summary>
        public string CategoryName
        {
            get { return this._CategoryName; }
            set { this.SetProperty(ref this._CategoryName, value); }
        }
        #endregion

        #region 顯示
        private bool _顯示 = false;
        /// <summary>
        /// 顯示
        /// </summary>
        public bool 顯示
        {
            get { return this._顯示; }
            set
            {
                this.SetProperty(ref this._顯示, value);
                if (value == true)
                {
                    Arrow = "V";
                }
                else
                {
                    Arrow = ">";
                }
            }
        }


        #region Arrow
        private string _Arrow = ">";
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string Arrow
        {
            get { return this._Arrow; }
            set { this.SetProperty(ref this._Arrow, value); }
        }
        #endregion

        #endregion


        #region MyItems
        private ObservableCollection<MyItem> _MyItems = new ObservableCollection<MyItem>();
        /// <summary>
        /// MyItems
        /// </summary>
        public ObservableCollection<MyItem> MyItems
        {
            get { return _MyItems; }
            set { SetProperty(ref _MyItems, value); }
        }
        #endregion

        public MyCategory()
        {

        }
    }
}
