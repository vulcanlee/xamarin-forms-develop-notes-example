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
using Xamarin.Forms;
using XFSplash.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using XFSplash.Renderers;

[assembly: ExportRenderer(typeof(FontAwesomeLabel), typeof(FontAwesomeLabelRenderer))]
namespace XFSplash.Droid.Renderers
{
    class FontAwesomeLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = Control;
            Typeface font;
            try
            {
                font = Typeface.CreateFromAsset(Forms.Context.Assets, "fontawesome.ttf");
                label.Typeface = font;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TTF file not found. Make sure the Android project contains it at 'fontawesome.ttf'.");
            }

        }
    }
}