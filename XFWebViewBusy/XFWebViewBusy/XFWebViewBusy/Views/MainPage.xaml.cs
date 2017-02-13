using Xamarin.Forms;
using XFWebViewBusy.ViewModels;

namespace XFWebViewBusy.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel fooMainPageViewModel;
        public MainPage()
        {
            InitializeComponent();

            fooMainPageViewModel = this.BindingContext as MainPageViewModel;

            webview.Navigated += (s, e) =>
            {
                fooMainPageViewModel.Isbusy = false;
            };
            webview.Navigating += (s, e) =>
            {
                fooMainPageViewModel.Isbusy = true;
            };
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            fooMainPageViewModel.Url = "";
            fooMainPageViewModel.Url = "http://mylabtw.blogspot.com/";
        }
    }
}
