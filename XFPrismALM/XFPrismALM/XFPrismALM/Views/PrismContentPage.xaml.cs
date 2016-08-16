using System.Diagnostics;
using Xamarin.Forms;

namespace XFPrismALM.Views
{
    public partial class PrismContentPage : ContentPage
    {
        public PrismContentPage()
        {
            InitializeComponent();
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
