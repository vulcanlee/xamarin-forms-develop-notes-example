using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFEllipse.Customs
{
    public class EllipseView : View
    {
        #region BindablePropertyType BindableProperty
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create("BindablePropertyType", // 屬性名稱 
                typeof(Color), // 回傳類型 
                typeof(EllipseView), // 宣告類型 
                Color.Accent // 預設值 
                );

        public Color Color
        {
            set
            {
                SetValue(ColorProperty, value);
            }
            get
            {
                return (Color)GetValue(ColorProperty);
            }
        }
        #endregion


        //public static readonly BindableProperty ColorProperty =
        //    BindableProperty.Create<EllipseView, Color>(p => p.Color, Color.Accent);

        //public Color Color
        //{
        //    get { return (Color)GetValue(ColorProperty); }
        //    set { SetValue(ColorProperty, value); }
        //}
    }
}
