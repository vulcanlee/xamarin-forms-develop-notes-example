using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XFCorelPicker.CustomControls
{
    [Preserve(AllMembers = true)]
    // https://forums.xamarin.com/discussion/63565/xamarin-forms-picker-data-binding-using-mvvm
    public class BindablePicker : Picker
    {
        public static void Init()
        {

        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource",
                    typeof(IEnumerable), typeof(BindablePicker), null,
                    //propertyChanged: OnItemsSourceChanged);
                    propertyChanged: (bindable, oldvalue, newvalue) => ((BindablePicker)bindable).OnItemsSourceChanged(bindable, oldvalue, newvalue));

        //propertyChanged: (bindable, oldvalue, newvalue) => ((WrapView)bindable).ItemsSource_OnPropertyChanged(bindable, oldvalue, newvalue));


        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem",
                    typeof(IEnumerable), typeof(BindablePicker), null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        public static readonly BindableProperty SelectedItemCommandProperty = BindableProperty.Create("SelectedItemCommand",
            typeof(ICommand), typeof(BindablePicker), null);

        public BindablePicker()
        {
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
            get
            {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public Object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set
            {
                if (SelectedItem != value)
                {
                    SetValue(SelectedItemProperty, value);
                    InternalUpdateSelectedIndex();

                    if (SelectedItemCommand != null)
                    {
                        SelectedItemCommand.Execute(value);
                    }
                }
            }
        }

        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

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

        public BindablePicker KeepBindablePicker = null;
        private void OnItemsSourceChanged(BindableObject bindable, object oldval, object newval)
        {
            var boundPicker = (BindablePicker)bindable;
            KeepBindablePicker = boundPicker;
            var oldvalue = oldval as IEnumerable;
            var newvalue = newval as IEnumerable;


            if (oldvalue != null)
            {
                var observableCollection = oldvalue as INotifyCollectionChanged;

                // Unsubscribe from CollectionChanged on the old collection
                if (observableCollection != null)
                    observableCollection.CollectionChanged -= OnCollectionChanged;
            }

            if (newvalue != null)
            {
                var observableCollection = newvalue as INotifyCollectionChanged;

                // Subscribe to CollectionChanged on the new collection 
                //and fire the CollectionChanged event to handle the items in the new collection
                if (observableCollection != null)
                    observableCollection.CollectionChanged += OnCollectionChanged;
            }

            boundPicker.InternalUpdateSelectedIndex();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (KeepBindablePicker == null)
            {
                return;
            }

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in args.NewItems)
                    {
                        KeepBindablePicker.Items.Add(item as string);
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in args.OldItems)
                    {
                        KeepBindablePicker.Items.Remove(item as string);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    KeepBindablePicker.Items[args.NewStartingIndex] = args.NewItems[0] as string;
                    break;
                case NotifyCollectionChangedAction.Reset:
                    KeepBindablePicker.Items.Clear();
                    break;
                default:
                    break;
            }
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
