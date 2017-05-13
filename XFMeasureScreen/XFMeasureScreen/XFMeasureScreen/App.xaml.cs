using Prism.Unity;
using XFMeasureScreen.Views;

namespace XFMeasureScreen
{
    public partial class App : PrismApplication
    {
        //#region 這裡定義從原生那裏取得的螢幕尺寸與縮放比
        ///// <summary>
        ///// 這個裝置的螢幕寬度的設計畫素
        ///// </summary>
        //public static double DisplayScreenWidth = 0f;
        ///// <summary>
        ///// 這個裝置的螢幕高度的設計畫素
        ///// </summary>
        //public static double DisplayScreenHeight = 0f;
        ///// <summary>
        ///// 這個裝置的設計尺寸縮放比
        ///// </summary>
        //public static double DisplayScaleFactor = 0f;
        //#endregion

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("StartPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<MDPage>();
            Container.RegisterTypeForNavigation<StartPage>();
            Container.RegisterTypeForNavigation<StartPage>();
        }
    }
}
