using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFHorListView.Controls
{
    /// <summary>
    /// 自行客製一個能夠水平捲動的 ListView 控制項，這個類別程式碼，源自於
    /// https://github.com/rasmuschristensen/XamarinFormsImageGallery
    /// 
    /// 這個新控制項，繼承於 ScrollView，裡面內建一個 StackLayout，您可以動態加入您想要的紀錄項目與透過 XAML 定義出想要出現的樣貌
    /// </summary>
    public class HorizontalListView : ScrollView
    {
        /// <summary>
        /// 這個控制項，將會持有所有的每筆紀錄控制項內容
        /// </summary>
        readonly StackLayout _imageStack;

        public HorizontalListView()
        {
            this.Orientation = ScrollOrientation.Horizontal;

            _imageStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            this.Content = _imageStack;
        }

        public IList<View> Children
        {
            get
            {
                return _imageStack.Children;
            }
        }

        // http://dotnetbyexample.blogspot.tw/2016/03/xamarin-form-21-upgradesome-surprises.html
        //在這裡定義一個可綁定屬性，讓開發者透過資料綁定的方式，可以指定要顯示的集合資料物件，
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), // 屬性名稱 
                typeof(IList),  // 回傳類型
                typeof(HorizontalListView),  // 宣告類型
                default(IList), // 預設值 
                BindingMode.TwoWay,  // 預設資料繫結模式
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    // 在這裡將會處理當這個可綁定屬性變更前的相關處理邏輯
                    ((HorizontalListView)bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    // 在這裡將會處理當這個可綁定屬性變更後的相關處理邏輯
                    ((HorizontalListView)bindableObject).ItemsSourceChanged(bindableObject, oldValue as IList, newValue as IList);
                }
       );

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {

                SetValue(ItemsSourceProperty, value);
            }
        }

        /// <summary>
        /// 在處理 ItemsSourceProperty 異動之前，要做的事情
        /// </summary>
        void ItemsSourceChanging()
        {
            if (ItemsSource == null)
                return;
        }

        /// <summary>
        /// 這裡將會處理，當 ItemsSourceProperty 異動之後，所要做的事情
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            if (ItemsSource == null)
                return;

            // 有關 INotifyCollectionChanged 這個類別，請參考
            // https://msdn.microsoft.com/zh-tw/library/system.collections.specialized.inotifycollectionchanged(v=vs.110).aspx
            // 透過 INotifyCollectionChanged 介面，可以得知集合物件中，紀錄的加入、移除、修改的異動狀態
            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                // 訂閱 發生於集合變更時 的事件 CollectionChanged
                notifyCollection.CollectionChanged += (sender, args) =>
                {
                    //這個引數，args.Action ，這個 NotifyCollectionChangedAction 列舉，您可以參考
                    //https://msdn.microsoft.com/zh-tw/library/system.collections.specialized.notifycollectionchangedaction(v=vs.110).aspx
                    if (args.NewItems != null)
                    {
                        //將指定於 ItemsSource 的集合物件，每筆紀錄，逐一建立相關 View 的物件
                        foreach (var newItem in args.NewItems)
                        {
                            // 依據 ItemTemplate 定義的內容，產生這個物件
                            var view = (View)ItemTemplate.CreateContent();
                            var bindableObject = view as BindableObject;
                            if (bindableObject != null)
                            {
                                //將每筆紀錄的 View 控制項，設定期要用的綁定物件來源
                                bindableObject.BindingContext = newItem;
                            }
                            _imageStack.Children.Add(view);
                        }
                    }
                    if (args.OldItems != null)
                    {
                        // not supported
                        _imageStack.Children.RemoveAt(args.OldStartingIndex);
                    }
                };
            }

        }

        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

    }
}
