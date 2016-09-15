using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFListView.Repositories;

namespace XFListView.ViewModels
{
    public class ScrollToPageViewModel : BindableBase
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

        public DelegateCommand 捲到2ZacharyCommand { get; private set; } 
        public DelegateCommand 捲到BobCommand { get; private set; }

        public Action<PersonWithButtonViewModel> 自動捲動到;

        public ScrollToPageViewModel()
        {
            MyData = PersonRepository.SampleWithButtonViewModel();

            捲到2ZacharyCommand = new DelegateCommand(捲到2Zachary);
            捲到BobCommand = new DelegateCommand(捲到Bob);
        }

        private void 捲到Bob()
        {
            if (自動捲動到 != null)
            {
                var fooItem = MyData.FirstOrDefault(x => x.Name == "Bob");
                if (fooItem != null)
                {
                    自動捲動到(fooItem);
                }
            }
        }

        private void 捲到2Zachary()
        {
            if (自動捲動到 != null)
            {
                var fooItem = MyData.FirstOrDefault(x => x.Name == "2Zachary");
                if (fooItem != null)
                {
                    自動捲動到(fooItem);
                }
            }
        }
    }
}
