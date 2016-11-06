using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFHListView.Models;

namespace XFHListView.ViewModels
{
    public class SimpleSamplePageViewModel : BindableBase
    {
        #region MyDatas
        private ObservableCollection<SampleItems1> _MyDatas;
        /// <summary>
        /// MyDatas
        /// </summary>
        public ObservableCollection<SampleItems1> MyDatas
        {
            get { return _MyDatas; }
            set { SetProperty(ref _MyDatas, value); }
        }
        #endregion

        #region 使用者點選項目
        private SampleItems1 _使用者點選項目;
        /// <summary>
        /// 使用者點選項目
        /// </summary>
        public SampleItems1 使用者點選項目
        {
            get { return this._使用者點選項目; }
            set { this.SetProperty(ref this._使用者點選項目, value); }
        }
        #endregion

        public DelegateCommand 使用者點選Command { get; set; }

        public readonly IPageDialogService _dialogService;
        public SimpleSamplePageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            Init();

            使用者點選Command = new DelegateCommand(() =>
              {
                  _dialogService.DisplayAlertAsync("訊息", $"你選取的是 {使用者點選項目.Title}", "OK");
              });
        }

        public void Init()
        {
            MyDatas = new ObservableCollection<SampleItems1>();

            var howMany = new Random().Next(100, 500);

            for (int i = 0; i < howMany; i++)
            {
                MyDatas.Add(new SampleItems1() { Title = string.Format("項目 {0}", i) });
            }
        }
    }
}
