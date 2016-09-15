using Xamarin.Forms;
using XFListView.ViewModels;

namespace XFListView.Views
{
    public partial class PullToRefreshPage : ContentPage
    {
        public PullToRefreshPageViewModel fooScrollToPageViewModel;
        public PullToRefreshPage()
        {
            InitializeComponent();
            fooScrollToPageViewModel = this.BindingContext as PullToRefreshPageViewModel;
        }
    }
}
