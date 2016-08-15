using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFLayoutOptions
{
    public partial class App : Application
    {
        static readonly StackLayout stackLayout = new StackLayout
        {
            BackgroundColor = Color.Gray,
            VerticalOptions = LayoutOptions.Start,
            Spacing = 0,
            Padding = 0,
        };

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
