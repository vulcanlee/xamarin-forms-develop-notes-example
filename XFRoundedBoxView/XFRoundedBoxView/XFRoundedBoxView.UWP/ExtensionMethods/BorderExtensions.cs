using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using XFRoundedBoxView.Customs;
using Xamarin.Forms;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;

namespace XFRoundedBoxView.UWP.ExtensionMethods
{
    public static class BorderExtensions
    {
        public static void InitializeFrom(this Border nativeControl, RoundedBoxView formsControl)
        {
            if (nativeControl == null || formsControl == null)
                return;

            nativeControl.Height = formsControl.HeightRequest;
            nativeControl.Width = formsControl.WidthRequest;
            nativeControl.UpdateCornerRadius(formsControl.CornerRadius);
            nativeControl.UpdateBorderColor(formsControl.BorderColor);

            var rectangle = new Windows.UI.Xaml.Shapes.Rectangle();

            rectangle.InitializeFrom(formsControl);

            nativeControl.Child = rectangle;
        }

        public static void UpdateFrom(this Border nativeControl, RoundedBoxView formsControl,
          string propertyChanged)
        {
            if (nativeControl == null || formsControl == null)
                return;

            if (propertyChanged == RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                nativeControl.UpdateCornerRadius(formsControl.CornerRadius);

                var rect = nativeControl.Child as Windows.UI.Xaml.Shapes.Rectangle;

                if (rect != null)
                {
                    rect.UpdateCornerRadius(formsControl.CornerRadius);
                }

            }
            if (propertyChanged == VisualElement.BackgroundColorProperty.PropertyName)
            {
                var rect = nativeControl.Child as Windows.UI.Xaml.Shapes.Rectangle;

                if (rect != null)
                {
                    rect.UpdateBackgroundColor(formsControl.BackgroundColor);
                }
            }

            if (propertyChanged == RoundedBoxView.BorderColorProperty.PropertyName)
            {
                nativeControl.Background = formsControl.BorderColor.ToBrush();
            }

            if (propertyChanged == RoundedBoxView.BorderThicknessProperty.PropertyName)
            {
                var rect = nativeControl.Child as Windows.UI.Xaml.Shapes.Rectangle;

                if (rect != null)
                {
                    rect.UpdateBorderThickness(formsControl.BorderThickness, formsControl.HeightRequest, formsControl.WidthRequest);
                }
            }
        }

        private static void UpdateCornerRadius(this Border nativeControl, double cornerRadius)
        {
            var relativeBorderCornerRadius = cornerRadius * 1.25;

            nativeControl.CornerRadius = new CornerRadius(relativeBorderCornerRadius);
        }

        public static void UpdateBorderColor(this Border nativeControl, Color backgroundColor)
        {
            nativeControl.Background = backgroundColor.ToBrush();
        }
    }
}
