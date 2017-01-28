using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFLayoutOptions
{
    // 這個專案，將練習 LayoutOptions 的六個列舉值的特性
    // LayoutOptions 其實是由兩個屬性所組成
    // Alignment : 表示要對其容器的哪個地方
    // Expansion : 表示是否要使用容器內所有可用空間
    // 當 StackLayout 設定為 Start / Center / End，不管是否有 AndExpand，將不會佔據容器的其他可用空間，
    // 因為，StackLayout 將會累計所有容器內控制項的所佔據空間，作為 StackLayout 自己的空間，因此，容器，StackLayout，不會有多餘其他的額外空間
    //
    // 若 StackLayout 設定為 Fill or FillAndExpand，則表示，StackLayout 將會填滿擁有它的容器（也就是 ContentPage = 整個螢幕空間)，
    // 而若 StackLayout 的裡面控制項有設定 AndExpand 這個屬性，則表示，這些控制項，將會平均分配多出來的空間
    public partial class App : Application
    {
        // 建立一個 StackLayout 控制項與其預設屬性值
        static readonly StackLayout stackLayout = new StackLayout
        {
            BackgroundColor = Color.Gray,
            VerticalOptions = LayoutOptions.Start,
            Spacing = 0,
            Padding = 0,
        };

        /// <summary>
        /// 建立這個應用程式的頁面
        /// 裡面有六個按鈕，每個按鈕都會設定為不同的 LayoutOptions列舉值
        /// 按下這個按鈕，將會變更六個按鈕的容器，也就是 StackLayout，他的 LayoutOptions 設定
        /// 我們需要觀察不同的 StackLayout 的 LayoutOptions 設定值，會有甚麼變化
        /// </summary>
        /// <returns></returns>
        public static Page GetMainPage()
        {
            AddButton("Start", LayoutOptions.Start);
            AddButton("Center", LayoutOptions.Center);
            AddButton("End", LayoutOptions.End);
            AddButton("Fill", LayoutOptions.Fill);
            AddButton("StartAndExpand", LayoutOptions.StartAndExpand);
            AddButton("CenterAndExpand", LayoutOptions.CenterAndExpand);
            AddButton("EndAndExpand", LayoutOptions.EndAndExpand);
            AddButton("FillAndExpand", LayoutOptions.FillAndExpand);

            return new NavigationPage(new ContentPage
            {
                Content = stackLayout,
            });
        }

        static void AddButton(string text, LayoutOptions verticalOptions)
        {
            stackLayout.Children.Add(new Button
            {
                Text = text,
                BackgroundColor = Color.White,
                VerticalOptions = verticalOptions,
                HeightRequest = 35,
                Command = new Command(() => {
                    // 按下這個按鈕，將會設定 StackLayout 的 VerticalOptions 值
                    stackLayout.VerticalOptions = verticalOptions;
                    (stackLayout.ParentView as Page).Title = "StackLayout: " + text;
                }),
            });
            stackLayout.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Yellow,
            });
        }
        public App()
        {
            InitializeComponent();

            MainPage = GetMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
