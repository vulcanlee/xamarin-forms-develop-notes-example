using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            eny輸入文字1.TextChanged += (s, e) =>
            {
                lbl輸入文字.Text = eny輸入文字1.Text;
            };
            eny輸入文字2.TextChanged += (s, e) =>
            {
                eny輸入文字1.Text = eny輸入文字2.Text;
            };
            btn按鈕.Clicked += (s, e) =>
            {
                lbl按鈕文字.Text = $"您已經按下按鈕";
            };
        }
    }
}
