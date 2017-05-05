using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFListShowImg.Models;

namespace XFListShowImg.ViewModels
{

    [ImplementPropertyChanged]
    public class MainPageViewModel : INavigationAware
    {
        public MyItem SelectedMyItem { get; set; }
        public ObservableCollection<MyItem> MyItems { get; set; } = new ObservableCollection<MyItem>();

        public DelegateCommand<MyItem> TapBoxCommand { get; set; }

        public MainPageViewModel()
        {
            TapBoxCommand = new DelegateCommand<MyItem>(x =>
              {
                  if(x.ShowImage == false)
                  {
                      x.ShowImage = true;
                      x.BoxColor = Color.BlueViolet;
                  }
              });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            MyItems.Clear();

            Random rm = new Random();
            for (int i = 0; i < 20; i++)
            {
                var fooItem = new MyItem
                {

                };
                fooItem.Number = rm.Next(0, 100);
                var fooM3 = fooItem.Number % 3;
                if (fooM3 == 0)
                {
                    fooItem.ShowImage = false;
                    fooItem.ImageUrl = "http://www.isgoodstuff.com/wp-content/uploads/2016/06/xamarin-logo.jpg";
                    fooItem.BoxColor = Color.Red;
                }
                else if (fooM3 == 1)
                {
                    fooItem.ShowImage = true;
                    fooItem.ImageUrl = "http://3bo61w2s39sh2nxd9917cfju.wpengine.netdna-cdn.com/wp-content/uploads/2015/12/Prism-Logo-Graphic-900x400.jpg";
                    fooItem.BoxColor = Color.PowderBlue;
                }
                else
                {
                    fooItem.ShowImage = true;
                    fooItem.ImageUrl = "http://www.isgoodstuff.com/wp-content/uploads/2016/06/xamarin-logo.jpg";
                    fooItem.BoxColor = Color.DarkSalmon;
                }
                MyItems.Add(fooItem);
            }
        }
    }
}
