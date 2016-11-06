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
    public class HorizontalListView : ScrollView
    {
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
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), // 屬性名稱 
                typeof(IList),  // 回傳類型
                typeof(HorizontalListView),  // 宣告類型
                default(IList), // 預設值 
                BindingMode.TwoWay,  // 預設資料繫結模式
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    ((HorizontalListView)bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
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

        void ItemsSourceChanging()
        {
            if (ItemsSource == null)
                return;
        }

        void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            if (ItemsSource == null)
                return;

            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                notifyCollection.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                    {
                        foreach (var newItem in args.NewItems)
                        {

                            var view = (View)ItemTemplate.CreateContent();
                            var bindableObject = view as BindableObject;
                            if (bindableObject != null)
                                bindableObject.BindingContext = newItem;
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
