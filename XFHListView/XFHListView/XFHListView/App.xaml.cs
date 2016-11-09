using Prism.Unity;
using XFHListView.Views;

namespace XFHListView
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("SimpleGalleryPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SimpleSamplePage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<SimpleGalleryPage>();
        }
    }
}
