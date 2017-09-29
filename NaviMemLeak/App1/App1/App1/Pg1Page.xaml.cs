using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg1Page : ContentPage
    {
        public int Index { get; set; }
        ~ Pg1Page()
        {
            Debug.WriteLine($"----------------- Release Pg1Page [{Index}]");
        }
        public Pg1Page()
        {
            InitializeComponent();

            Index = GlobalMember.Pg1Count;
            GlobalMember.Pg1Count++;
        }

        private void GotoPage2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pg2Page());
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}