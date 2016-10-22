using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AttProp
{
    public class EntryTypeAttached
    {
        #region EntryType Attached Property
        public static readonly BindableProperty EntryTypeProperty =
               BindableProperty.CreateAttached(
                   propertyName: "EntryType",
                   returnType: typeof(string),
                   declaringType: typeof(Entry),
                   defaultValue: null,
                   defaultBindingMode: BindingMode.OneWay,
                   validateValue: null,
                   propertyChanged: OnEntryTypeChanged);

        public static void SetEntryType(BindableObject bindable, string entryType)
        {
            bindable.SetValue(EntryTypeProperty, entryType);
        }
        public static string GetEntryType(BindableObject bindable)
        {
            return (string)bindable.GetValue(EntryTypeProperty);
        }
        #endregion

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var fooEntry = bindable as Entry;
            if (fooEntry == null)
                return;

            var foooldValue = (oldValue as string)?.ToLower();
            var foonewValue = (newValue as string)?.ToLower();
            if(foonewValue == null)
            {
                return;
            }
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
        }

        // Helper methods for attached bindable property. 
    }
}
