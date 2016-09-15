using Prism.Unity;
using XFListView.Views;

namespace XFListView
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("xf:///NaviPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<BasicPage>();
            Container.RegisterTypeForNavigation<Basic1Page>();
            Container.RegisterTypeForNavigation<RowHeightPage>();
            Container.RegisterTypeForNavigation<CustomButtonPage>();
            Container.RegisterTypeForNavigation<CustomButton1Page>();
            Container.RegisterTypeForNavigation<HeaderFooterPage>();
            Container.RegisterTypeForNavigation<ScrollToPage>();
            Container.RegisterTypeForNavigation<PullToRefreshPage>();
            Container.RegisterTypeForNavigation<ItemClickPage>();
        }
    }
}
