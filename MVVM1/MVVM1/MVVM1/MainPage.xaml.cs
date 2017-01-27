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

            // 由於這個專案不採用 MVVM 方式開發，因此，所有的商業邏輯，將需要撰寫在每個 .xaml 頁面的 Code Behind 內
            // 這樣的開發方式，對於在以 XAML 為基礎的開發工具中，是不多見的，而且無法充分發揮 XAML 帶來的好處

            eny輸入文字1.TextChanged += (s, e) =>
            {
                // 當在 eny輸入文字1 內有任何文字異動，將會透過 TextChanged 的呼叫，及時將內容更新到 lbl輸入文字
                lbl輸入文字.Text = eny輸入文字1.Text;
            };
            eny輸入文字2.TextChanged += (s, e) =>
            {
                // 當在 eny輸入文字2 內有任何文字異動，將會透過 TextChanged 的呼叫，及時將內容更新到 eny輸入文字1
                // 在這裡，因為更新了 eny輸入文字1 內容，將回連帶同步更新到 lbl輸入文字
                eny輸入文字1.Text = eny輸入文字2.Text;
            };
            btn按鈕.Clicked += (s, e) =>
            {
                lbl按鈕文字.Text = $"您已經按下按鈕";
            };
        }
    }
}
