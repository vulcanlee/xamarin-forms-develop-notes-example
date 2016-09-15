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
    public class CustomButtonPageViewModel : BindableBase
    {

        #region MyData
        private ObservableCollection<PersonViewModel> myData;
        /// <summary>
        /// MyData
        /// </summary>
        public ObservableCollection<PersonViewModel> MyData
        {
            get { return this.myData; }
            set { this.SetProperty(ref this.myData, value); }
        }
        #endregion

        #region MyDataSelected
        private PersonViewModel myDataSelected;
        /// <summary>
        /// MyDataSelected
        /// </summary>
        public PersonViewModel MyDataSelected
        {
            get { return this.myDataSelected; }
            set { this.SetProperty(ref this.myDataSelected, value); }
        }
        #endregion


        public readonly IPageDialogService _dialogService;

        public DelegateCommand<PersonViewModel> 進行互動Command { get; private set; }
        public CustomButtonPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            MyData = PersonRepository.SampleViewModel();

            進行互動Command = new DelegateCommand<PersonViewModel>(進行互動);
        }

        private async void 進行互動(PersonViewModel obj)
        {
            await _dialogService.DisplayAlertAsync("請確定", $"您選取了 {obj.Name}", "確定");
        }
    }
}
