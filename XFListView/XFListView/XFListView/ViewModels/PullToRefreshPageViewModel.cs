using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using XFListView.Repositories;

namespace XFListView.ViewModels
{
    public class PullToRefreshPageViewModel : BindableBase
    {
        #region MyData
        private ObservableCollection<PersonWithButtonViewModel> myData;
        /// <summary>
        /// MyData
        /// </summary>
        public ObservableCollection<PersonWithButtonViewModel> MyData
        {
            get { return this.myData; }
            set { this.SetProperty(ref this.myData, value); }
        }
        #endregion


        #region IsBusy 
        private bool isBusy;
        /// <summary>
        /// IsBusy 
        /// </summary>
        public bool IsBusy 
        {
            get { return this.isBusy; }
            set { this.SetProperty(ref this.isBusy, value); }
        }
        #endregion


        public DelegateCommand 更新資料Command { get; private set; } 

        public PullToRefreshPageViewModel()
        {
            MyData = PersonRepository.SampleWithButtonViewModel();
            更新資料Command = new DelegateCommand(更新資料);
        }

        private async void 更新資料()
        {
            await 從網路取得最新資料();
            IsBusy = false;
        }

        public async Task 從網路取得最新資料()
        {
            await Task.Delay(3000);
            var fooMyData = PersonRepository.SampleWithButtonViewModel();
            foreach (var item in fooMyData)
            {
                MyData.Add(item);
            }
        }

    }
}
