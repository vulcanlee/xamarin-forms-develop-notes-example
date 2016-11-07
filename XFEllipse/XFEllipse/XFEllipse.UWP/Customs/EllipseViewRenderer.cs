using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XFEllipse.Customs;
using XFEllipse.UWP.Customs;

[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseViewRenderer))]
namespace XFEllipse.UWP.Customs
{
    public class EllipseViewRenderer : ViewRenderer<EllipseView, Ellipse>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<EllipseView> e)
        {
            base.OnElementChanged(e);

            var ellipse = new Ellipse();
            ellipse.DataContext = this.Element;
            //ellipse.SetBinding(Ellipse.FillProperty,
            //    new Binding("Color") { Converter = new ColorConverter() });

            this.SetNativeControl(ellipse);
        }
    }
}
