using Xamarin.Forms;
using XFCarouselView.Models;

namespace XFCarouselView.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //CarouselZoos.ItemSelected += CarouselZoos_ItemSelected;
        }

        private void CarouselZoos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var foo = e.SelectedItem as Zoo;
        }
    }
}
