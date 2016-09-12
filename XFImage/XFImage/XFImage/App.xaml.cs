using Prism.Unity;
using XFImage.Views;

namespace XFImage
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync(new System.Uri("http://vulcan.com/NaviPage/IndependentImagePage", System.UriKind.Absolute));
            //NavigationService.NavigateAsync("XF://vulcan/NaviPage/AspectPage");
            NavigationService.NavigateAsync("XF://vulcan/NaviPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<IndependentImagePage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<AspectPage>();
        }
    }
}
