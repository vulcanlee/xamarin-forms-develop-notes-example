using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFListView.Models;
using XFListView.ViewModels;

namespace XFListView.Repositories
{
    public class MyItemRepository
    {
        public static ObservableCollection<MyItem> Sample()
        {
            var fooItems = new ObservableCollection<MyItem> {
                new MyItem() { FirstName = "Willa", LastName = "Cather", Age = 20 },
                new MyItem() { FirstName = "Isak", LastName = "Dinesen", Age = 22 },
                new MyItem() { FirstName = "Victor", LastName = "Hugo", Age = 27 },
                new MyItem() { FirstName = "Jules", LastName = "Verne", Age = 18 },
                new MyItem() { FirstName = "偉圻", LastName = "蔡", Age = 20 },
                new MyItem() { FirstName = "奕中", LastName = "游", Age = 20 },
                new MyItem() { FirstName = "子超", LastName = "趙", Age = 20 },
                new MyItem() { FirstName = "蓉蓁", LastName = "陳", Age = 20 },
            };
            return fooItems;
        }
        public static ObservableCollection<MyItemViewModel> SampleViewModel()
        {
            var fooItems = new ObservableCollection<MyItemViewModel> {
                new MyItemViewModel() { FirstName = "Willa", LastName = "Cather", Age = 20 },
                new MyItemViewModel() { FirstName = "Isak", LastName = "Dinesen", Age = 22 },
                new MyItemViewModel() { FirstName = "Victor", LastName = "Hugo", Age = 27 },
                new MyItemViewModel() { FirstName = "Jules", LastName = "Verne", Age = 18 },
                new MyItemViewModel() { FirstName = "偉圻", LastName = "蔡", Age = 20 },
                new MyItemViewModel() { FirstName = "奕中", LastName = "游", Age = 20 },
                new MyItemViewModel() { FirstName = "子超", LastName = "趙", Age = 20 },
                new MyItemViewModel() { FirstName = "蓉蓁", LastName = "陳", Age = 20 },
            };
            return fooItems;
        }
        public static ObservableCollection<MyItemViewModel> SampleLongViewModel()
        {
            var fooItems = new ObservableCollection<MyItemViewModel> {
                new MyItemViewModel() { FirstName = "本教學課程說明如何使用 Azure 行動應用程式後端，將雲端型後端服務新增到 Xamarin.Forms 行動應用程式。您將同時建立新的行動應用程式後端，以及在 Azure 中儲存應用程式資料的簡單「Todo list」Xamarin.Forms 應用程式。" },
                new MyItemViewModel() { FirstName = "若要完成此教學課程，您需要下列項目：" },
                new MyItemViewModel() { FirstName = "您在這裡有幾個選擇。您可以將方案下載到 Mac 並在 Xamarin Studio 中開啟，或者您也可以下載方案到 Windows 電腦並使用已加入網路的 Mac 在 Visual Studio 開啟，以便建置 iOS 應用程式。如果您需要更詳細的 Xamarin 設定案例指示，請參閱設定和安裝 Visual Studio 和 Xamarin。" },
                new MyItemViewModel() { FirstName = "以滑鼠右鍵按一下 iOS 專案，然後按一下 [設為起始專案]。" },
                new MyItemViewModel() { FirstName = "在應用程式中，輸入有意義的文字 (例如「了解 Xamarin (Learn Xamarin)」)，然後按一下 + 按鈕。" },
            };
            return fooItems;
        }
    }
}
