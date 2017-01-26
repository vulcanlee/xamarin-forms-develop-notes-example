using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DynaStat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnDynamic.Clicked += (s, e) =>
              {
                  DisplayAlert("", "按下這個按鈕，將會動態變更，使用 DynamicResource 的 Xaml 內容，使用 StaticResource 的則不受到影響", "OK");
                  this.Resources["backgroundColor"] = Color.White;
                  this.Resources["textColor"] = Color.Black;
                  this.Resources["fontSize"] = 30;
                  btnDynamic.Text = $"變更動態資源 " + this.Resources.Count.ToString();
              };
            btnGlobalDynamic.Clicked += (s, e) =>
              {
                  //底下提供兩種方式，讓您可以來變更全域資源項目的動態資源值
                  DisplayAlert("", "按下這個按鈕，將會動態變更在應用程式內的資源項目，使用 DynamicResource 的 Xaml 內容，使用 StaticResource 的則不受到影響", "OK");
                  DisplayAlert("", "可以使用 this.Resources 與 App.Current.Resources 來執行", "OK");
                  this.Resources["GlobalbackgroundColor"] = Color.White;
                  this.Resources["GlobaltextColor"] = Color.Black;
                  this.Resources["GlobalfontSize"] = 30;

                  //App.Current.Resources["GlobalbackgroundColor"] = Color.White;
                  //App.Current.Resources["GlobaltextColor"] = Color.Black;
                  //App.Current.Resources["GlobalfontSize"] = 30;
                  btnGlobalDynamic.Text = $"變更全域動態資源 "+ App.Current.Resources.Count.ToString();
              };
            btnStatic.Clicked += (s, e) =>
              {
                  DisplayAlert("", "按下這個按鈕，將會修改 .NET 靜態屬性的值，可是，不會立即顯示出變更後的效果，必須重現建立該頁面，才會看的出來", "OK");
                  PubStat.文字顏色 = Color.Blue;
                  PubStat.背景顏色 = Color.Pink;
                  PubStat.文字尺寸 = 30;
              };
            btnReset.Clicked += (s, e) =>
              {
                  DisplayAlert("", "按下這個按鈕，將會重新產生這個頁面物件，因此，大部分的樣式內容，將會被覆蓋掉(因為，頁面重新建立了)，唯獨使用 x:Static 方式參考 .NET 靜態屬性的 XAML 屬性，不會有變動到", "OK");
                  App.Current.MainPage = new MainPage();
              };
        }
    }
}
