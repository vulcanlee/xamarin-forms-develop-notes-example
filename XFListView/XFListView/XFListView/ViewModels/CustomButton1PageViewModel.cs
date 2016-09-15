using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using XFListView.Repositories;
using Prism.Services;

namespace XFListView.ViewModels
{
    public class CustomButton1PageViewModel : BindableBase
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


        public readonly IPageDialogService _dialogService;

        public DelegateCommand<PersonViewModel> 進行互動Command { get; private set; }
        public CustomButton1PageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            MyData = PersonRepository.SampleWithButtonViewModel();

            進行互動Command = new DelegateCommand<PersonViewModel>(進行互動);
        }

        private async void 進行互動(PersonViewModel obj)
        {
            await _dialogService.DisplayAlertAsync("請確定", $"您選取了 {obj.Name}", "確定");
        }
    }
}
