using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFMoreWrapLayout;
using XFMoreWrapLayout.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace XFMoreWrapLayout.iOS
{
    /// <summary>
    ///   Source From : https://gist.github.com/rudyryk/8cbe067a1363b45351f6
    /// </summary>
    [Foundation.Preserve(AllMembers = true)]
    public class RoundedBoxViewRenderer : Xamarin.Forms.Platform.iOS.BoxRenderer
    {
        /// <summary>
        ///   Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        private RoundedBoxView _formControl
        {
            get { return Element as RoundedBoxView; }
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            this.InitializeFrom(_formControl);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            this.UpdateFrom(_formControl, e.PropertyName);
        }
    }
}