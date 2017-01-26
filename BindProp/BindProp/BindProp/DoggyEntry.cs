using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindProp
{
    /// <summary>
    /// 繼承原有控制項，並在新的控制項中，加入一個新的可綁定屬性，使得新的控制項可以具有另外一種表現能力
    /// 在 XAML 中使用的範例 <CustomControl:DoggyEntry EntryType="Email" />
    /// </summary>
    public class DoggyEntry : Entry
    {
        // 關於可綁定屬性，可以參考底下文章
        // https://developer.xamarin.com/guides/xamarin-forms/xaml/bindable-properties/

        // 使用程式碼片段 vlBindableProperty 可以快速產生可綁定屬性的定義樣板程式碼
        #region EntryType BindableProperty

        // 使用 BindableProperty.Create 來產生一個可綁定屬性
        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.Create("EntryType", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(DoggyEntry), // 宣告類型 
                "None", // 預設值 
                propertyChanged: OnEntryTypeChanged  // 當這個屬性有異動的時候，需要執行的事件
                ); 

        public string EntryType
        {
            set
            {
                SetValue(EntryTypeProperty, value);
            }
            get
            {
                return (string)GetValue(EntryTypeProperty);
            }
        }
        #endregion

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 取得現在控制項的物件
            var fooEntry = bindable as DoggyEntry;

            // 取得該可綁定屬性，變更前的值
            var foooldValue = (oldValue as string).ToLower();
            // 取得該可綁定屬性，變更後的值
            var foonewValue = (newValue as string).ToLower();

            #region 根據可綁定屬性設定的值內容，進行相關客製化的處理動作
            switch (foonewValue)
            {
                case "None":
                    break;
                case "email":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入電子郵件");
                    fooEntry.Keyboard = Keyboard.Email;
                    fooEntry.FontSize = 20;
                    break;
                case "phone":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入電話號碼");
                    fooEntry.Keyboard = Keyboard.Telephone;
                    fooEntry.FontSize = 20;
                    break;
                case "number":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入數值");
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
