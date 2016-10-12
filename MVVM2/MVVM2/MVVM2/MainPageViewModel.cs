using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM2
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region EntryText1
        private string _EntryText1;

        public string EntryText1
        {
            get
            {
                return _EntryText1;
            }
            set
            {
                if (_EntryText1 != value)
                {
                    _EntryText1 = value;
                    EntryText2 = value;
                    OnPropertyChanged("EntryText1");
                }
            }
        }
        #endregion

        #region EntryText2
        private string _EntryText2;

        public string EntryText2
        {
            get
            {
                return _EntryText2;
            }
            set
            {
                if (_EntryText2 != value)
                {
                    EntryText1 = value;
                    _EntryText2 = value;
                    OnPropertyChanged("EntryText2");
                }
            }
        }
        #endregion

        #region LabelText1
        private string _LabelText1;

        public string LabelText1
        {
            get
            {
                return _LabelText1;
            }
            set
            {
                if (_LabelText1 != value)
                {
                    _LabelText1 = value;
                    OnPropertyChanged("LabelText1");
                }
            }
        }
        #endregion

        #region Button ICommand
        public ICommand PushMeCommand { protected set; get; }
        #endregion

        public MainPageViewModel()
        {
            EntryText1 = "";
            EntryText2 = "";
            PushMeCommand = new Command(() =>
            {
                this.LabelText1 = $"您已經按下按鈕";
            });
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
