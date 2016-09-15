using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFListView.Repositories;

namespace XFListView.ViewModels
{
    public class Basic1PageViewModel : BindableBase
    {
        private ObservableCollection<MyItemViewModel> myItemList;
        public ObservableCollection<MyItemViewModel> MyItemList
        {
            get { return myItemList; }
            set { SetProperty(ref myItemList, value); }
        }

        private MyItemViewModel myItemListSelected;
        public MyItemViewModel MyItemListSelected
        {
            get { return myItemListSelected; }
            set { SetProperty(ref myItemListSelected, value); }
        }

        public DelegateCommand 新增Command { get; private set; }
        public DelegateCommand 修改Command { get; private set; }
        public DelegateCommand 刪除Command { get; private set; }
        public Basic1PageViewModel()
        {
            MyItemList = MyItemRepository.SampleViewModel();

            新增Command = new DelegateCommand(新增);
            修改Command = new DelegateCommand(修改);
            刪除Command = new DelegateCommand(刪除);
        }

        private void 刪除()
        {
            var fooItem = MyItemList.FirstOrDefault(x => x.FirstName == myItemListSelected.FirstName &&
            x.LastName == myItemListSelected.LastName && x.Age == myItemListSelected.Age);
            if (fooItem != null)
            {
                MyItemList.Remove(fooItem);
            }
        }

        private void 修改()
        {
            if (myItemListSelected != null)
            {
                #region 直接修改綁定的物件 
                myItemListSelected.FirstName = "艾嬡";
                myItemListSelected.LastName = "林";
                myItemListSelected.Age = 33;
                #endregion

            }
        }

        private void 新增()
        {
            MyItemList.Add(new MyItemViewModel
            {
                FirstName = "文君",
                LastName = "簡",
                Age = 19
            });
        }
    }
}
