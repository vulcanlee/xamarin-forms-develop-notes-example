using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XFCreative.ViewModels;

namespace XFCreative.Views
{
    public partial class BusinessSpacePage : ContentPage
    {
        BusinessSpacePageViewModel BusinessSpacePageViewModel;
        public BusinessSpacePage()
        {
            InitializeComponent();

            BusinessSpacePageViewModel = this.BindingContext as BusinessSpacePageViewModel;

            BusinessSpacePageViewModel.回到ListView最前面 = 回到ListView最前面Delegate;
        }

        private void 回到ListView最前面Delegate()
        {
            if (BusinessSpacePageViewModel.創業空間Nodes.Count > 0)
            {
                var fooItem = BusinessSpacePageViewModel.創業空間Nodes[0];
                listview創業空間.ScrollTo(fooItem, ScrollToPosition.Center, false);
            }
        }
    }
}
