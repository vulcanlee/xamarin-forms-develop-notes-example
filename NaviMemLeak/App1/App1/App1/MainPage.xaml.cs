using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GotoPage1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pg1Page());
        }

        private void NeedGC_Clicked(object sender, EventArgs e)
        {
            GC.Collect();           
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            ((Application)App.Current).MainPage = new NavigationPage(new App1.MainPage());

        }
    }
}
