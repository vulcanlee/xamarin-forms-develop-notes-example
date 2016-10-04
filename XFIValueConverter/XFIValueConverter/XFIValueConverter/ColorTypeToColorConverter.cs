using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFIValueConverter
{
    class ColorTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var foo = value as string;
            if (foo == "1")
            {
                return Color.Red;
            }
            else if (foo == "2")
            {
                return Color.Blue;
            }
            else if (foo == "3")
            {
                return Color.Green;
            }
            else
            {
                return Color.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
