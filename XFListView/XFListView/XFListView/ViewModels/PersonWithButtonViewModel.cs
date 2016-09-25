using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFListView.ViewModels
{
    public class PersonWithButtonViewModel : BindableBase 
    {
        #region Name
        private string name;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }
        #endregion

        #region Birthday
        private DateTime birthday;
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.SetProperty(ref this.birthday, value); }
        }
        #endregion

        #region FavoriteColor
        private Color favoriteColor;
        /// <summary>
        /// FavoriteColor
        /// </summary>
        public Color FavoriteColor
        {
            get { return this.favoriteColor; }
            set { this.SetProperty(ref this.favoriteColor, value); }
        }
        #endregion

        public readonly IPageDialogService _dialogService;

        public DelegateCommand<PersonWithButtonViewModel> 進行互動Command { get; private set; }
        public DelegateCommand<PersonWithButtonViewModel> 立即產生Command { get; private set; }
        public DelegateCommand<PersonWithButtonViewModel> 刪除Command { get; private set; }

        public PersonWithButtonViewModel()
        {
            #region 使用 Prism 的容器 IUnityContainer，解析 IPageDialogService 物件
            // 在這裡不使用建構式注入，是因為，PersonRepository.SampleWithButtonViewModel() 要產生的清單物件，不是透過 Unity 所建立的
            // 所以，手動進行物件解析，取得實作的物件
            var fooApp = App.Current as App;
            IUnityContainer fooIUnityContainer = fooApp.Container;
            _dialogService = fooApp.Container.Resolve<IPageDialogService>();
            #endregion

            進行互動Command = new DelegateCommand<PersonWithButtonViewModel>(進行互動);
            立即產生Command = new DelegateCommand<PersonWithButtonViewModel>(立即產生);
            刪除Command = new DelegateCommand<PersonWithButtonViewModel>(刪除);
        }

        private async void 進行互動(PersonWithButtonViewModel obj)
        {
            await _dialogService.DisplayAlertAsync("請確定", $"您選取了 {obj.Name}", "確定");
        }

        private async void 刪除(PersonWithButtonViewModel obj)
        {
            await _dialogService.DisplayAlertAsync("請確定", $"準備刪除 {obj.Name}", "確定");
        }

        private async void 立即產生(PersonWithButtonViewModel obj)
        {
            await _dialogService.DisplayAlertAsync("請確定", $"立即執行 {obj.Name}", "確定");
        }

    }
}
