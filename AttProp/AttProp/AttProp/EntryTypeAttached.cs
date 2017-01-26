using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AttProp
{
    /// <summary>
    /// 建立一個類別，裡面使用 BindableProperty.CreateAttached 建立一個 XAML 用的附加屬性
    /// 在 XAML 中的用法     <Entry CustomAttached:EntryTypeAttached.EntryType="Email" />
    /// </summary>
    public class EntryTypeAttached
    {
        // 可以使用程式碼片段 vlAttachedProperty 快速產生要設計的程式碼
        #region EntryType Attached Property
        /// <summary>
        /// 這個附加屬性，只能夠套用在 Entry 控制項上，會根據所指定的名稱，自動加上浮水印文字
        /// </summary>
        public static readonly BindableProperty EntryTypeProperty =
               BindableProperty.CreateAttached(
                   propertyName: "EntryType",
                   returnType: typeof(string),
                   declaringType: typeof(Entry),   
                   defaultValue: null,  // 這個附加屬性的預設值
                   defaultBindingMode: BindingMode.OneWay,  // 指定資料繫結的模式，在這裡指定為單向
                   validateValue: null,
                   propertyChanged: OnEntryTypeChanged  // 當這個附加屬性值有變動的時候，需要執行的呼叫事件
                   );

        public static void SetEntryType(BindableObject bindable, string entryType)
        {
            bindable.SetValue(EntryTypeProperty, entryType);
        }
        public static string GetEntryType(BindableObject bindable)
        {
            return (string)bindable.GetValue(EntryTypeProperty);
        }
        #endregion

        /// <summary>
        /// 當這個附加屬性值有變動的時候，需要執行的呼叫事件
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 若所附加的屬性不是 Entry，則不要有任何處理動作
            var fooEntry = bindable as Entry;
            if (fooEntry == null)
                return;

            // 取得屬性值變動前與變動後的值
            var foooldValue = (oldValue as string)?.ToLower();
            var foonewValue = (newValue as string)?.ToLower();

            if(foonewValue == null)
            {
                return;
            }

            #region 根據指定附加屬性的值，設定所綁訂到的控制項(Entry)，的 Placeholder 屬性成為預設指定的文字
            switch (foonewValue)
            {
                case "None":
                    break;
                case "email":
                    fooEntry.SetValue(Entry.PlaceholderProperty, "請輸入電子郵件");
                    fooEntry.Keyboard = Keyboard.Email;
                    fooEntry.FontSize = 20;
                    break;
                case "phone":
                    fooEntry.SetValue(Entry.PlaceholderProperty, "請輸入電話號碼");
                    fooEntry.Keyboard = Keyboard.Telephone;
                    fooEntry.FontSize = 20;
                    break;
                case "number":
                    fooEntry.SetValue(Entry.PlaceholderProperty, "請輸入數值");
                    fooEntry.Keyboard = Keyboard.Numeric;
                    fooEntry.FontSize = 20;
                    break;
                default:
                    break;
            }
            #endregion
        }
    }
}
