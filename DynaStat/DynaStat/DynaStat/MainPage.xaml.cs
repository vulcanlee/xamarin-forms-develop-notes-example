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
                  this.Resources["backgroundColor"] = Color.White;
                  this.Resources["textColor"] = Color.Black;
                  this.Resources["fontSize"] = 30;
                  btnDynamic.Text = $"變更動態資源 " + this.Resources.Count.ToString();
              };
            btnGlobalDynamic.Clicked += (s, e) =>
              {
                  App.Current.Resources["GlobalbackgroundColor"] = Color.White;
                  App.Current.Resources["GlobaltextColor"] = Color.Black;
                  App.Current.Resources["GlobalfontSize"] = 30;
                  btnGlobalDynamic.Text = $"變更全域動態資源 "+ App.Current.Resources.Count.ToString();
              };
            btnStatic.Clicked += (s, e) =>
              {
                  PubStat.文字顏色 = Color.Blue;
                  PubStat.背景顏色 = Color.Pink;
                  PubStat.文字尺寸 = 30;
              };
            btnReset.Clicked += (s, e) =>
              {
                  App.Current.MainPage = new MainPage();
              };
        }
    }
}
