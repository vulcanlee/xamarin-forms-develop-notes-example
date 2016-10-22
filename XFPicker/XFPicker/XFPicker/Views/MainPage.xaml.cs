using Xamarin.Forms;
using XFPicker.ViewModels;

namespace XFPicker.Views
{
    public partial class MainPage : ContentPage
    {

        MainPageViewModel fooMainPageViewModel;
        public MainPage()
        {
            InitializeComponent();

            fooMainPageViewModel = this.BindingContext as MainPageViewModel;

            foreach (var item in fooMainPageViewModel.MyItemList)
            {
                MyPicker.Items.Add(item);
            }
        }
    }
}
