using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFAlert.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public IPageDialogService _dialogService { get; set; }
        public DelegateCommand PrismAlertCommand { get; set; }
        public DelegateCommand PrismActionSheetCommand { get; set; }

        #region PrismAlert輸出結果
        private string _PrismAlert輸出結果;
        public string PrismAlert輸出結果
        {
            get { return _PrismAlert輸出結果; }
            set { SetProperty(ref _PrismAlert輸出結果, value); }
        }
        #endregion

        #region PrismActionSheet輸出結果
        private string _PrismActionSheet輸出結果;
        public string PrismActionSheet輸出結果
        {
            get { return _PrismActionSheet輸出結果; }
            set { SetProperty(ref _PrismActionSheet輸出結果, value); }
        }
        #endregion

        public MainPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;

            PrismAlertCommand = new DelegateCommand(PrismAlert);
            PrismActionSheetCommand = new DelegateCommand(PrismActionSheet);

            PrismAlert輸出結果 = "Prism 選擇結果";
            PrismActionSheet輸出結果 = "Prism 動作表單 選擇結果";
        }

        private async void PrismAlert()
        {
            await _dialogService.DisplayAlertAsync("警告", "您確定要繼續執行嗎?", "確定");
            bool 選擇結果 =await _dialogService.DisplayAlertAsync("通知", "您要開始下載這個檔案嗎?", "是", "否");
            PrismAlert輸出結果 = 選擇結果.ToString();
        }

        private async void PrismActionSheet()
        {
            var 選擇結果 = await _dialogService.DisplayActionSheetAsync("請選擇您要分享的目的應用程式?", "取消", "Google+", "Email", "Twitter", "Facebook");
            PrismActionSheet輸出結果 = 選擇結果;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
