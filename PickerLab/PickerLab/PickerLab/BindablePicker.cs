using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PickerLab
{
    // https://forums.xamarin.com/discussion/63565/xamarin-forms-picker-data-binding-using-mvvm
    // 在 Xamarin.Forms 中的 Picker 控制項，是沒有提供可綁定資料與命令功能，這對於採用 MVVM 開發方式的開發者而言，是相當的不方便(不過，在2017第二季之後，Xamarin.Forms 將會提供這項功能)。
    // 不過，在此之前，若想要使用這樣的功能，您可以使用本範例中提供的 BindablePicker 來做這樣功能，您也可以順便學習與了解，在 Xamarin.Forms 中，要如何自己客製化一個控制項，做出屬於您自己的 XAML 控制項。
    public class BindablePicker : Picker
    {
        // 您可以使用 程式碼片段 vlBindableProperty 來快速產生可綁定屬性需要用到的程式碼

        /// <summary>
        /// 建立一個可綁定屬性，可以用來指定 Picker ，其資料存在於 ViewModel 上，且要顯示資料集合來源
        /// </summary>
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource",
                    typeof(IEnumerable), typeof(BindablePicker), null, propertyChanged: OnItemsSourceChanged);

        /// <summary>
        /// 建立一個可綁定屬性，用來存取使用者選取了哪個集合資料紀錄
        /// </summary>
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem",
                    typeof(IEnumerable), typeof(BindablePicker), null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        /// <summary>
        /// 建立一個可綁定屬性，用來設定，當使用選取某筆紀錄之後，所要執行的命令
        /// </summary>
        public static readonly BindableProperty SelectedItemCommandProperty = BindableProperty.Create("SelectedItemCommand",
            typeof(ICommand), typeof(BindablePicker), null);

        public BindablePicker()
        {
            // 在這裡訂閱了 Picker 的 SelectedIndexChanged 事件，用來設定 SelectedItem 物件值與呼叫所綁定的命令
            // 若您不是使用 Lambda 方式訂閱這個事件，記得要在這個控制項消失的時候，同步取消訂閱，否則，會有 Memory Leak 的問題
            SelectedIndexChanged += (o, e) =>
            {
                if (SelectedIndex < 0 || ItemsSource == null || !ItemsSource.GetEnumerator().MoveNext())
                {
                    SelectedItem = null;
                    return;
                }

                var index = 0;
                foreach (var item in ItemsSource)
                {
                    // 找到使用者點選的 Picker 紀錄，並且指定到可綁定屬性 SelectedItemProperty
                    // SelectedItem 的 set 存取子，會呼叫 SetValue(SelectedItemProperty, value);
                    if (index == SelectedIndex)
                    {
                        SelectedItem = item;
                        break;
                    }
                    index++;
                }
            };
        }

        public ICommand SelectedItemCommand
        {
            get { return (ICommand)GetValue(SelectedItemCommandProperty); }
            set { SetValue(SelectedItemCommandProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public Object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set
            {
                if (SelectedItem != value)
                {
                    // 更新 可綁定屬性的內容
                    SetValue(SelectedItemProperty, value);
                    InternalUpdateSelectedIndex();

                    if (SelectedItemCommand != null)
                    {
                        SelectedItemCommand.Execute(value);
                    }
                }
            }
        }

        /// <summary>
        /// 建立一個可指定的事件，用來當所選擇的紀錄有變更的時候，會來呼叫這個事件
        /// </summary>
        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        /// <summary>
        /// 更新 Picker 內的 SelectedIndex 屬性值
        /// </summary>
        private void InternalUpdateSelectedIndex()
        {
            var selectedIndex = -1;
            if (ItemsSource != null)
            {
                var index = 0;
                foreach (var item in ItemsSource)
                {
                    if (item != null && item.Equals(SelectedItem))
                    {
                        selectedIndex = index;
                        break;
                    }
                    index++;
                }
            }
            SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// 當要綁定的資料集合資料有變動的時候，會來呼叫這個事件
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var boundPicker = (BindablePicker)bindable;

            if (Equals(newValue, null) && !Equals(oldValue, null))
                return;

            // 清除原有 Picker 內的所有清單紀錄
            boundPicker.Items.Clear();

            // 若新設定的集合物件不是空值，則將這些集合紀錄，逐一新增到 Picker 內
            if (!Equals(newValue, null))
            {
                foreach (var item in (IEnumerable)newValue)
                    boundPicker.Items.Add(item.ToString());
            }

            boundPicker.InternalUpdateSelectedIndex();
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var boundPicker = (BindablePicker)bindable;
            if (boundPicker.ItemSelected != null)
            {
                boundPicker.ItemSelected(boundPicker, new SelectedItemChangedEventArgs(newValue));
            }
            boundPicker.InternalUpdateSelectedIndex();
        }

    }
}
