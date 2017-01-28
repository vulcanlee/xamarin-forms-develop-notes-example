using Xamarin.Forms;
using XFPicker.ViewModels;

namespace XFPicker.Views
{
    public partial class MainPage : ContentPage
    {

        MainPageViewModel fooMainPageViewModel;
        public MainPage()
        {
            InitializeComponent();

            // 取得這個頁面所綁定的 ViewModel 物件
            fooMainPageViewModel = this.BindingContext as MainPageViewModel;

            // 透過 ViewModel 內定義的集合物件，將這些項目加入到 Picker 控制項內
            foreach (var item in fooMainPageViewModel.MyItemList)
            {
                MyPicker.Items.Add(item);
            }
        }
    }
}
