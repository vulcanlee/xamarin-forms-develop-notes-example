using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PickerLab.ViewModels
{

    
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        #region PickerSelectedTitle
        private string pickerSelectedTitle;
        /// <summary>
        /// PickerSelectedTitle
        /// </summary>
        public string PickerSelectedTitle
        {
            get { return this.pickerSelectedTitle; }
            set { this.SetProperty(ref this.pickerSelectedTitle, value); }
        }
        #endregion

        #region PickerSelected
        private string pickerSelected;
        /// <summary>
        /// PickerSelected
        /// </summary>
        public string PickerSelected
        {
            get { return this.pickerSelected; }
            set { this.SetProperty(ref this.pickerSelected, value); }
        }
        #endregion


        #region PickerVM
        private ObservableCollection<string> pickerVM;
        /// <summary>
        /// PickerVM
        /// </summary>
        public ObservableCollection<string> PickerVM
        {
            get { return pickerVM; }
            set { SetProperty(ref pickerVM, value); }
        }
        #endregion

        public DelegateCommand<object> SelectedIndexChangedCommand { get; private set; } 

        public MainPageViewModel()
        {
            PickerVM = new ObservableCollection<string>();
            pickerVM.Add("Item1");
            pickerVM.Add("Item2");
            pickerVM.Add("Item3");
            pickerVM.Add("Item4");
            pickerVM.Add("Item5");
            pickerVM.Add("Item6");
            pickerVM.Add("Item7");

            Title = "這裡是由 SelectedItemCommand 命令觸發來設定";
            PickerSelectedTitle = "這裡是由 SelectedItem 資料綁定自動設定";
            SelectedIndexChangedCommand = new DelegateCommand<object>(SelectedIndexChanged);
        }

        private void SelectedIndexChanged(object obj)
        {
            Title = $"已經選擇 {obj}";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (parameters.ContainsKey("title"))
            //    Title = (string)parameters["title"] + " and Prism";
        }
    }
}
