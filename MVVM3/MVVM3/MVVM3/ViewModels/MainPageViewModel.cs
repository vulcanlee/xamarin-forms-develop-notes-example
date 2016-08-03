using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM3.ViewModels
{
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
                SetProperty(ref _EntryText1, value);
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
                EntryText1 = value;
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


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
