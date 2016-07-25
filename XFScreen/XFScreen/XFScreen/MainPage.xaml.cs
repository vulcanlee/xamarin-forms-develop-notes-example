using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace XFScreen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            UpdateInfo();
        }

        public void UpdateInfo()
        {
            var device = Resolver.Resolve<IDevice>();
            var display = device.Display;

            labelPixel.Text = $"寬X高 {display.Width} X {display.Height}";

            labelDPIPixel.Text = $"寬X高 {display.Xdpi} X {display.Ydpi}";

            labelInch.Text = $"寬X高 {display.ScreenWidthInches()} X {display.ScreenHeightInches()}";

            labelXDPI.Text = $"寬X高 {display.Scale}";

            labelDiagonal.Text = $"{display.ScreenSizeInches()}";
        }
    }
}
