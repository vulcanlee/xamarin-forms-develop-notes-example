using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using XFEllipse.Customs;
using XFEllipse.Droid.Customs;
using Xamarin.Forms;
using Android.Graphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseRenderer))]
namespace XFEllipse.Droid.Customs
{
    /// <summary>
    /// 在這裡使用了 ExportRenderer 來告知 Xamarin，我們需要由 EllipseRenderer 來顯示出 EllipseView 控制項
    /// </summary>
    public class EllipseRenderer : VisualElementRenderer<EllipseView>
    {
        public EllipseRenderer()
        {
            this.SetWillNotDraw(false);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == EllipseView.ColorProperty.PropertyName)
                this.Invalidate(); // Force a call to OnDraw
        }

        protected override void OnDraw(Canvas canvas)
        {
            // 這裡將會是呼叫 Android 原生 API 
            var element = this.Element;
            var rect = new Rect();
            this.GetDrawingRect(rect);

            var paint = new Paint()
            {
                Color = element.Color.ToAndroid(),
                AntiAlias = true
            };

            canvas.DrawOval(new RectF(rect), paint);
        }
    }
}