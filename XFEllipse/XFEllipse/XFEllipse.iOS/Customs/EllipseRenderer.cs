using CoreGraphics;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFEllipse.Customs;
using XFEllipse.iOS.Customs;

[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseRenderer))]
namespace XFEllipse.iOS.Customs
{
    /// <summary>
    /// 在這裡使用了 ExportRenderer 來告知 Xamarin，我們需要由 EllipseRenderer 來顯示出 EllipseView 控制項
    /// </summary>
    public class EllipseRenderer : VisualElementRenderer<EllipseView>
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == EllipseView.ColorProperty.PropertyName)
                this.SetNeedsDisplay(); // Force a call to Draw
        }

        public override void Draw(CGRect rect)
        {
            // 這裡將會是呼叫 iOS 原生 API 
            using (var context = UIGraphics.GetCurrentContext())
            {
                var path = CGPath.EllipseFromRect(rect);
                context.AddPath(path);
                context.SetFillColor(this.Element.Color.ToCGColor());
                context.DrawPath(CGPathDrawingMode.Fill);
            }
        }
    }
}