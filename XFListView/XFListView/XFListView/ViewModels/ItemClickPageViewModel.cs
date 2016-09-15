using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFListView.Repositories;

namespace XFListView.ViewModels
{
    public class ItemClickPageViewModel : BindableBase
    {

        private readonly INavigationService _navigationService;

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


        #region MyDataSelected
        private PersonWithButtonViewModel myDataSelected;
        /// <summary>
        /// MyDataSelected
        /// </summary>
        public PersonWithButtonViewModel MyDataSelected
        {
            get { return this.myDataSelected; }
            set { this.SetProperty(ref this.myDataSelected, value); }
        }
        #endregion

        public DelegateCommand MyDataClickedCommand { get; private set; }

        public ItemClickPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            MyData = PersonRepository.SampleWithButtonViewModel();
            MyDataClickedCommand = new DelegateCommand(MyDataClicked);
        }

        private async void MyDataClicked()
        {
            await _navigationService.NavigateAsync("Basic1Page");
            // 若沒有加入底下這行，則當回到這個頁面的時候，這筆一樣有被選取
            MyDataSelected = null;
        }
    }
}
