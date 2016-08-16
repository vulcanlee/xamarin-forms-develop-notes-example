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
                  await Navigation.PopAsync();
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
