using Xamarin.Forms;
using XFListView.ViewModels;

namespace XFListView.Views
{
    public partial class ScrollToPage : ContentPage
    {
        public ScrollToPageViewModel fooScrollToPageViewModel;
        public ScrollToPage()
        {
            InitializeComponent();

            fooScrollToPageViewModel = this.BindingContext as ScrollToPageViewModel;
            fooScrollToPageViewModel.自動捲動到 = this.自動捲動到;
        }

        public void 自動捲動到(PersonWithButtonViewModel personWithButtonViewModel)
        {
            listview.ScrollTo(personWithButtonViewModel, ScrollToPosition.Start, true);
        }
    }
}
