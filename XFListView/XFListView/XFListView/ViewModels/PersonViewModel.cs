using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFListView.ViewModels
{
    public class PersonViewModel : BindableBase
    {
        #region Name
        private string name;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }
        #endregion


        #region Birthday
        private DateTime birthday;
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.SetProperty(ref this.birthday, value); }
        }
        #endregion

        #region FavoriteColor
        private Color favoriteColor;
        /// <summary>
        /// FavoriteColor
        /// </summary>
        public Color FavoriteColor
        {
            get { return this.favoriteColor; }
            set { this.SetProperty(ref this.favoriteColor, value); }
        }
        #endregion


        public PersonViewModel()
        {

        }
    }
}
