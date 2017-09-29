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
    public partial class Pg2Page : ContentPage
    {
        public int Index { get; set; }
        ~Pg2Page()
        {
            Debug.WriteLine($"----------------- Release Pg2Page [{Index}]");
        }

        public Pg2Page()
        {
            InitializeComponent();

            Index = GlobalMember.Pg2Count;
            GlobalMember.Pg2Count++;
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}