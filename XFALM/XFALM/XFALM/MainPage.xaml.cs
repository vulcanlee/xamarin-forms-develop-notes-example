using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFALM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnNavi.Clicked += async (s, e) =>
              {
                  // 顯示另外一個新頁面
                  await Navigation.PushAsync(new Page1());
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
