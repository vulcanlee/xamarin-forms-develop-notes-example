using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XFScan.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            // 產生掃描條碼頁面物件
            var scanPage = new ZXingScannerPage();
            scanPage.Title = "請掃描條碼";
            scanPage.OnScanResult += (result) => {
                // 停止掃描
                scanPage.IsScanning = false;

                // 顯示掃描結果
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            // 導航到掃描條碼頁面
            await Navigation.PushAsync(scanPage);
        }
    }
}
