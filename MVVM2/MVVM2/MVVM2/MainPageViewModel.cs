using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM2
{
    /// <summary>
    /// 每個 ViewModel 都需要實作 INotifyPropertyChanged，並且控制何時要 PropertyChangedEventHandler 這個事件
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region 在這裡定義了三個屬性(Property)與一個 ICommand 命令物件，這些屬性都可以在 XAML 中，透過 Binding 延伸標記來綁定
        #region EntryText1
        private string _EntryText1;

        public string EntryText1
        {
            get
            {
                return _EntryText1;
            }
            set
            {
                // 為何在這裡需要先判斷，現在這個屬性值與舊的屬性值是否相同?
                if (_EntryText1 != value)
                {
                    // 這裡將會更新這個在 ViewModel 內的屬性對應的欄位物件值
                    _EntryText1 = value;
                    // 這裡將會同步變更 EntryText2 的屬性，也就是說，只要 EntryText1 變動之後，EntryText2也會跟著一起變動
                    // 若這兩個屬性都有綁定到 XAML 上，則 XAML 上的控制項內容，也都會同步進行更新
                    EntryText2 = value;

                    // 執行需要更新的事件，您需要傳遞參數，指明是哪個屬性要更新它的內容
                    OnPropertyChanged("EntryText1");
                }
            }
        }
        #endregion

        #region EntryText2
        private string _EntryText2;

        public string EntryText2
        {
            get
            {
                return _EntryText2;
            }
            set
            {
                if (_EntryText2 != value)
                {
                    // 底下這兩行若交換的話，會有甚麼結果呢?
                    EntryText1 = value;
                    _EntryText2 = value;
                    OnPropertyChanged("EntryText2");
                }
            }
        }
        #endregion

        #region LabelText1
        private string _LabelText1;

        public string LabelText1
        {
            get
            {
                return _LabelText1;
            }
            set
            {
                if (_LabelText1 != value)
                {
                    _LabelText1 = value;
                    OnPropertyChanged("LabelText1");
                }
            }
        }
        #endregion

        #region Button ICommand
        public ICommand PushMeCommand { protected set; get; }
        #endregion
        #endregion

        public MainPageViewModel()
        {
            #region 在這裡，進行 ViewModel 內的 Property 的資料初始化
            EntryText1 = "";
            EntryText2 = "";

            // 定義一個 ICommand 命令，用來處理，當使用者有與螢幕操作互動的時候，所要執行的相關程式碼，在這裡，當使用按下按鈕時候，將會變更 ViewModel 內的 LabelText1 屬性
            PushMeCommand = new Command(() =>
            {
                this.LabelText1 = $"您已經按下按鈕";
            });
            #endregion
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // 若 PropertyChanged 有被綁定，則將會執行這個事件，以進行頁面控制項的內容更新
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
