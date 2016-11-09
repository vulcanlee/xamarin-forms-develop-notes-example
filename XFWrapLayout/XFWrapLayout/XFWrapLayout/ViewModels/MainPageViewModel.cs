using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XFWrapLayout.ViewModels
{
    public class Person
    {
        public string Name { get; set; }
    }
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region MyItems
        private ObservableCollection<Person> _MyItems;
        /// <summary>
        /// MyItems
        /// </summary>
        public ObservableCollection<Person> MyItems
        {
            get { return _MyItems; }
            set { SetProperty(ref _MyItems, value); }
        }
        #endregion


        public MainPageViewModel()
        {
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
            MyItems = new ObservableCollection<Person>();
            MyItems.Add(new Person { Name = "1" });
            MyItems.Add(new Person { Name = "2" });
            MyItems.Add(new Person { Name = "3" });
            MyItems.Add(new Person { Name = "4" });
            MyItems.Add(new Person { Name = "5" });
            MyItems.Add(new Person { Name = "11" });
            MyItems.Add(new Person { Name = "12" });
            MyItems.Add(new Person { Name = "13" });
            MyItems.Add(new Person { Name = "14" });
            MyItems.Add(new Person { Name = "15" });
            MyItems.Add(new Person { Name = "21" });
            MyItems.Add(new Person { Name = "22" });
            MyItems.Add(new Person { Name = "23" });
            MyItems.Add(new Person { Name = "24" });
            MyItems.Add(new Person { Name = "25" });
            MyItems.Add(new Person { Name = "31" });
            MyItems.Add(new Person { Name = "32" });
            MyItems.Add(new Person { Name = "33" });
            MyItems.Add(new Person { Name = "34" });
            MyItems.Add(new Person { Name = "35" });
        }
    }
}
