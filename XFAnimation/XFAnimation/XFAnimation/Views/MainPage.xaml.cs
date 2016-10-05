using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFAnimation.ViewModels;

namespace XFAnimation.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel fooMainPageViewModel;
        public MainPage()
        {
            InitializeComponent();

            fooMainPageViewModel = this.BindingContext as MainPageViewModel;
            fooMainPageViewModel.串接動畫Delegate = 串接動畫;
            fooMainPageViewModel.各自動畫Delegate = 各自動畫;
            fooMainPageViewModel.頁面消失動畫Delegate = 頁面消失動畫;
        }

        private async void 頁面消失動畫()
        {
            await 頁面收起來();
        }

        public async void 各自動畫()
        {
            await Task.WhenAll(
                button.TranslateTo(200, 0, 1000),
                button.TranslateTo(0, 100, 1000),
                button.ScaleTo(2.0, 1000),
                button.RotateTo(360, 1000));
        }
        public async void 串接動畫()
        {
            await button.TranslateTo(200, 0, 1000);
            await button.TranslateTo(0, 100, 1000);
            await button.ScaleTo(2.0, 1000);
            await button.RotateTo(360, 1000);
        }

        protected async override void OnAppearing()
        {
            await 頁面攤開來();
            base.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public async Task 頁面收起來()
        {
            this.AnchorX = 0;
            this.RotationY = 0;
            await this.RotateYTo(-180, 2000);
            this.AnchorX = 0.5;
            this.RotationY = 0;
        }
        public async Task 頁面攤開來()
        {
            this.AnchorX = 0;
            this.RotationY = -180;
            await this.RotateYTo(0, 12000);
            this.AnchorX = 0.5;
            this.RotationY = 0;
        }
    }
}
