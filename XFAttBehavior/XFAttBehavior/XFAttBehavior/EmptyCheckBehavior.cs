using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAttBehavior
{
    public class EmptyHighlightBehavior
    {
        // 產生一個附加屬性，用來定義是否要啟用空字串檢查與提示行為
        public static readonly BindableProperty EmptyHighlightProperty =
             BindableProperty.CreateAttached(
                 "EmptyHighlight",
                 typeof(bool),
                 typeof(EmptyHighlightBehavior),
                 false,
                 propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(EmptyHighlightProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(EmptyHighlightProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            // 若這個檢視不是 Entry 類別，則不需要做任何處理動作
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                RefreshBackgroundColor(entry);
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            RefreshBackgroundColor(sender);
        }

        // 根據現在 Entry 檢視的 Text 屬性值，判斷是否要提示背景顏色，告知該欄位尚未輸入任何值
        static void RefreshBackgroundColor(object sender)
        {
            if (string.IsNullOrEmpty(((Entry)sender).Text))
            {
                ((Entry)sender).BackgroundColor = Color.Red;
            }
            else
            {
                if (((Entry)sender).Text.Length >= 6)
                {
                    ((Entry)sender).BackgroundColor = Color.Default;
                    ((Entry)sender).TextColor = Color.Default;
                }
                else
                {
                    ((Entry)sender).BackgroundColor = Color.Default;
                    ((Entry)sender).TextColor = Color.Red;
                }
            }
        }
    }
}
