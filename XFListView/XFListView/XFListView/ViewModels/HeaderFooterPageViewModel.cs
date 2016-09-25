using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFListView.Repositories;

namespace XFListView.ViewModels
{
    public class HeaderFooterPageViewModel : BindableBase 
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

        public HeaderFooterPageViewModel()
        {
            myData = PersonRepository.SampleWithButtonViewModel();
        }

    }
}
