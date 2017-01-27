using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM3.ViewModels
{
    /// <summary>
    /// 在這裡，直接使用 Prism 提供的類別 BindableBase，幫助我們處理相關 IPNC 的工作
    /// </summary>
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        //private string _title;
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        #region EntryText1
        private string _EntryText1;

        public string EntryText1
        {
            get
            {
                return _EntryText1;
            }
            set
            {
                // SetProperty 是 Prism 所提供的一個方法，讓您不再需要使用 字串 來定義要更新的屬性名稱，並且自動幫您判斷是否要執行更新事件
                SetProperty(ref _EntryText1, value);
                if (EntryText1 != EntryText2)
                {
                    EntryText2 = value;
                }
            }
        }
        #endregion

        #region EntryText2
        private string _EntryText2;

        public string EntryText2
        {
            get
            {
                return _EntryText2;
            }
            set
            {
                SetProperty(ref _EntryText2, value);
                if (EntryText1 != EntryText2)
                {
                    EntryText1 = value;
                }
            }
        }
        #endregion

        #region LabelText1
        private string _LabelText1;

        public string LabelText1
        {
            get
            {
                return _LabelText1;
            }
            set
            {
                SetProperty(ref _LabelText1, value);
            }
        }
        #endregion

        #region Button ICommand
        public DelegateCommand PushMeCommand { protected set; get; }
        #endregion

        public MainPageViewModel()
        {
            PushMeCommand = new DelegateCommand(() =>
            {
                this.LabelText1 = $"您已經按下按鈕";
            });
        }

        #region 這是 Prism 提供另外一個相當好用的方法，用來處理當進入頁面或者來開頁面的時候，需要做哪些事情。要使用這樣功能，您需要實作出 INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
        #endregion
    }
}
