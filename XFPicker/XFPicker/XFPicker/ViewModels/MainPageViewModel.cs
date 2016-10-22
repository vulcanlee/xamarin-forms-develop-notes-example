using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XFPicker.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public List<string> MyItemList;

        public MainPageViewModel()
        {
            MyItemList = new List<string>();
            MyItemList.Add("ItemA");
            MyItemList.Add("ItemB");
            MyItemList.Add("ItemC");
            MyItemList.Add("ItemD");
            MyItemList.Add("ItemE");
            MyItemList.Add("ItemF");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
