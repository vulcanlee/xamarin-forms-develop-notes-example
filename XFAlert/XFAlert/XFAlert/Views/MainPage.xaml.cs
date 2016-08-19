using Xamarin.Forms;

namespace XFAlert.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnAlert.Clicked += async (s, e) =>
              {
                  await DisplayAlert("警告", "您確定要繼續執行嗎?", "確定");
                  bool 選擇結果 = await DisplayAlert("通知", "您要開始下載這個檔案嗎?", "是", "否");
                  lblXF選擇結果.Text = 選擇結果.ToString();
              };
            btnActionSheet.Clicked += async (s, e) =>
              {
                  var 選擇結果 = await DisplayActionSheet("請選擇您要分享的目的應用程式?", "取消", "Google+", "Email", "Twitter", "Facebook");
                  lblXF動作表單選擇結果.Text = 選擇結果;
              };
        }

    }
}
