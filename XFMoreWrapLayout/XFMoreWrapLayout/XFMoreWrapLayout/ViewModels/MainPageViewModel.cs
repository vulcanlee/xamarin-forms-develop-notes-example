using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace XFMoreWrapLayout.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region Width
        private double _Width;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public double Width
        {
            get { return this._Width; }
            set
            {
                this.SetProperty(ref this._Width, value);
                RecordWidth = value - 40;
            }
        }
        #endregion

        #region Height
        private double _Height;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public double Height
        {
            get { return this._Height; }
            set { this.SetProperty(ref this._Height, value); }
        }
        #endregion

        #region RecordWidth
        private double _RecordWidht;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public double RecordWidth
        {
            get { return this._RecordWidht; }
            set { this.SetProperty(ref this._RecordWidht, value); }
        }
        #endregion

        #region MyCategories
        private ObservableCollection<MyCategory> _MyCategories = new ObservableCollection<MyCategory>();
        /// <summary>
        /// MyCategories
        /// </summary>
        public ObservableCollection<MyCategory> MyCategories
        {
            get { return _MyCategories; }
            set { SetProperty(ref _MyCategories, value); }
        }
        #endregion

        public DelegateCommand<MyCategory> 點選資料列Command { get; set; }
        public DelegateCommand<MyItem> 點選資料列項目Command { get; set; }

        public readonly IPageDialogService _dialogService;

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            _navigationService = navigationService;
            _dialogService = dialogService;
            點選資料列Command = new DelegateCommand<MyCategory>(x =>
            {
                // 這個 顯示 屬性，將會綁定到 IsVisible ，控制這個控制項是否要顯示在螢幕上
                x.顯示 = !x.顯示;
            });

            點選資料列項目Command = new DelegateCommand<MyItem>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"You click ${x.Name}", "OK");
            });

            try
            {
                Init();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

        }

        public void Init()
        {
            //MyCategories.Clear();
            var fooMyCategory = new MyCategory
            {
                CategoryName = "Category1",
                顯示 = false,
            };
            fooMyCategory.MyItems.Add(new MyItem { Name = "1 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "m1 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "tem1 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "Item1 4" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem1 5" });
            MyCategories.Add(fooMyCategory);


            fooMyCategory = new MyCategory
            {
                CategoryName = "Category3",
                顯示 = false,
            };
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem3 1" });
            MyCategories.Add(fooMyCategory);

            fooMyCategory = new MyCategory
            {
                CategoryName = "Category2",
                顯示 = false,
            };
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem2 3" });
            MyCategories.Add(fooMyCategory);

            fooMyCategory = new MyCategory
            {
                CategoryName = "Category4",
                顯示 = false,
            };
            fooMyCategory.MyItems.Add(new MyItem { Name = "C4 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4CItem 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4CI 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4CIt 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4CItem4 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "4 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4CItem4CItem4 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem4 2" });
            MyCategories.Add(fooMyCategory);

            fooMyCategory = new MyCategory
            {
                CategoryName = "Category5",
                顯示 = false,
            };
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 1" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 2" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 3" });
            fooMyCategory.MyItems.Add(new MyItem { Name = "CItem5 1" });
            MyCategories.Add(fooMyCategory);
        }
    }
}
