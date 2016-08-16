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
                 await Navigation.PushAsync(new Page1());
              };
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine($"{this.Title} 進入到 OnAppearing");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine($"{this.Title} 進入到 OnDisappearing");
            base.OnDisappearing();
        }
    }
}
