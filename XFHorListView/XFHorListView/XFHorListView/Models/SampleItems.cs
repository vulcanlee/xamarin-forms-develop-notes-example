using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFHorListView.Models
{
    public class SampleItems : BindableBase
    {
        #region Title
        private string _Title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }
        #endregion


        #region Color
        private Color _Color;
        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get { return this._Color; }
            set { this.SetProperty(ref this._Color, value); }
        }
        #endregion


        #region ImageUrl
        private string _ImageUrl;
        /// <summary>
        /// ShowImage
        /// </summary>
        public string ImageUrl
        {
            get { return this._ImageUrl; }
            set { this.SetProperty(ref this._ImageUrl, value); }
        }
        #endregion

        public SampleItems()
        {

        }
    }
}
