using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMoreWrapLayout
{
    /// <summary>
    /// 這個自訂控制項將會由每個平台的 Renderer 來產生出具有圓角效果的矩形
    /// </summary>
    public class RoundedBoxView : BoxView
    {
        // 指定圓角的半徑
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(double), typeof(RoundedBoxView), default(double),
                propertyChanged: (b, s, e) => { });

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// 指定圓角矩形的線條寬度
        /// </summary>
        public static readonly BindableProperty BorderThicknessProperty =
            BindableProperty.Create("BorderThickness", typeof(int), typeof(RoundedBoxView), default(int),
                propertyChanged: (b, s, e) => { });

        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        /// <summary>
        /// 指定線條顏色
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(RoundedBoxView), Color.White,
                propertyChanged: OnBorderColorChanged);

        private static void OnBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var fooEntry = bindable as RoundedBoxView;
        }

        /// <summary>
        /// Border Color of circle image
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }
    }
}
