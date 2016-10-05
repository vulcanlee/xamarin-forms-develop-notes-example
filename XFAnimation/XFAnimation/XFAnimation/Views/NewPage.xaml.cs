using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAnimation.Views
{
    public partial class NewPage : ContentPage
    {
        public NewPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            await 頁面攤開來();
            base.OnAppearing();
        }

        public async Task 頁面收起來()
        {
            this.AnchorX = 0;
            this.RotationY = 0;
            await this.RotateYTo(-180, 2000);
            this.AnchorX = 0.5;
            this.RotationY = 0;
        }
        public async Task 頁面攤開來()
        {
            this.AnchorX = 0;
            this.RotationY = -180;
            await this.RotateYTo(0, 2000);
            this.AnchorX = 0.5;
            this.RotationY = 0;
        }
    }
}
