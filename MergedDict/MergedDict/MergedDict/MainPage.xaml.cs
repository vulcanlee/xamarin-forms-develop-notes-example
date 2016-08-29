using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MergedDict
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.btn.Clicked += (s, e) =>
              {
                  Navigation.PushAsync(new Main2Page());
              };
        }
    }
}
