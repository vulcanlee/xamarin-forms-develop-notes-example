using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindProp
{
    public class DoggyEntry : Entry
    {
        // https://developer.xamarin.com/guides/xamarin-forms/xaml/bindable-properties/

        #region EntryType BindableProperty
        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.Create("EntryType", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(DoggyEntry), // 宣告類型 
                "None", // 預設值 
                propertyChanged: OnEntryTypeChanged);

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
            var fooEntry = bindable as DoggyEntry;
            var foooldValue = (oldValue as string).ToLower();
            var foonewValue = (newValue as string).ToLower();

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
        }

        public DoggyEntry()
        {

        }

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
    }
}
