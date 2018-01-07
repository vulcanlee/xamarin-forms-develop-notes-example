using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;

namespace XFPopup.Views
{
    public partial class NewPage1Page : PopupPage
    {
        public NewPage1Page()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private async void OnLogin(object sender, EventArgs e)
        {
            //var loadingPage = new LoadingPopupPage();
            //await Navigation.PushPopupAsync(loadingPage);
            //await Task.Delay(2000);
            //await Navigation.RemovePopupPageAsync(loadingPage);
            //await Navigation.PushPopupAsync(new LoginSuccessPopupPage());
        }

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();

            return false;
        }

        private async void CloseAllPopup()
        {
            await Navigation.PopAllPopupAsync();
        }

    }
}
