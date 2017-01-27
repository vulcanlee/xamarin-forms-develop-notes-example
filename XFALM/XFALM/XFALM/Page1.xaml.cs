using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFALM
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

            btnNavi.Clicked += async (s, e) =>
              {
                  //回到前一個頁面
                  await Navigation.PopAsync();
              };
        }

        protected override void OnAppearing()
        {
            //這個方法將會於頁面顯示的時候，會被呼叫
            Debug.WriteLine($"{this.Title} 進入到 OnAppearing");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            //這個方法將會於頁面被影藏的時候，會被呼叫
            Debug.WriteLine($"{this.Title} 進入到 OnDisappearing");
            base.OnDisappearing();
        }
    }
}
