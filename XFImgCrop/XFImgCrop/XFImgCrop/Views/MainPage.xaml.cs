using System.Threading.Tasks;
using Xamarin.Forms;
using XFImgCrop.CustomControls;
using XFImgCrop.ViewModels;

namespace XFImgCrop.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel MainPageViewModel;

        public MainPage()
        {
            InitializeComponent();

            MainPageViewModel = this.BindingContext as MainPageViewModel;
            MainPageViewModel.NavigationImageCropping = TakePicture;
        }

        public async Task TakePicture(byte[] imageAsByte)
        {
            await Navigation.PushModalAsync(new CropView(imageAsByte, MainPageViewModel.Refresh));
        }
    }
}
