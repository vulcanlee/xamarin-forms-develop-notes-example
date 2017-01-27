using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAttBehavior
{
    /// <summary>
    /// 這個類別，說明了如何製作出一個 Attached Behaviors，
    /// Xamarin.Forms 內的 Behaviors ，讓您可以將一些功能加入到 Xamarin.Forms所提供的控制項中，但是卻不需要繼承原有控制項類別，做出一個客製化控制項；另外，
    /// Behaviors 可以讓您原先在 Code Behind 內的處理邏輯，隱藏起來，透過 XAML 語法，進而啟用這些功能
    /// 
    /// 關於 Attached Behaviors 可以參考 https://developer.xamarin.com/guides/xamarin-forms/behaviors/attached/
    /// </summary>
    public class EmptyHighlightBehavior
    {
        // 產生一個附加屬性，用來定義是否要啟用空字串檢查與提示行為
        //您可以使用程式碼片段 vlAttachedProperty 自動產生相關定義程式碼
        public static readonly BindableProperty EmptyHighlightProperty =
             BindableProperty.CreateAttached(
                 "EmptyHighlight",  // .NET Property 名稱
                 typeof(bool),  // 這個附加屬性的型別
                 typeof(EmptyHighlightBehavior),  // BindableProperty 宣告的型別
                 false, // 這個附加屬性的預設值
                 propertyChanged: OnAttachBehaviorChanged // 當這個附加屬性值有變動的時候，需要執行的呼叫事件
                 );

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(EmptyHighlightProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(EmptyHighlightProperty, value);
        }

        /// <summary>
        /// 當這個附加屬性的值有異動的時候，就會呼叫這個方法
        /// </summary>
        /// <param name="view"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            // 若這個檢視不是 Entry 類別，則不需要做任何處理動作
            // 因為，這個附加屬性，是要做些 Entry 的客製化處理
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                //若這個附加屬性值為 True，則需要隨時知道這個 Entry 的文字輸入內容，以便做出適當的處理
                //在這裡，將會訂閱 TextChanged 事件
                RefreshBackgroundColor(entry);
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                //若這個附加屬性為 false (預設值)，則會解除 TextChanged 的事件綁定
                //這個動作非常的重要，一定要處理
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
