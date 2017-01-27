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

        private async Task 頁面消失動畫()
        {
            await 頁面收起來();
        }

        public async Task 各自動畫()
        {
            // 使用 TPL 的 Task.WhenAll，讓所有的動畫都同時運行
            await Task.WhenAll(
                button.TranslateTo(200, 0, 1000),
                button.TranslateTo(0, 100, 1000),
                button.ScaleTo(2.0, 1000),
                button.RotateTo(360, 1000));
        }
        public async Task 串接動畫()
        {
            //在這裡，每個動畫會依序逐步執行
            await button.TranslateTo(200, 0, 1000);
            await button.TranslateTo(0, 100, 1000);
            await button.ScaleTo(2.0, 1000);
            await button.RotateTo(360, 1000);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await 頁面攤開來();
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            await 頁面收起來();
        }

        /// <summary>
        /// 當頁面要隱藏起來的時候，會執行這個動畫效果
        /// </summary>
        /// <returns></returns>
        public async Task 頁面收起來()
        {
            this.AnchorX = 0;
            this.RotationY = 0;
            await this.RotateYTo(-180, 2000);
            this.AnchorX = 0.5;
            this.RotationY = 0;
        }

        /// <summary>
        /// 當頁面要顯示出來的時候，會顯示這個動畫效果
        /// </summary>
        /// <returns></returns>
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
