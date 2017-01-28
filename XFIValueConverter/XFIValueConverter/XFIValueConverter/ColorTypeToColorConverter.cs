using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFIValueConverter
{
    /// <summary>
    /// 建立一個數值轉換器，接收一個字串文字，根據對應關係，會轉換成為一個顏色物件，若對應不起來，則回傳黑色
    /// </summary>
    class ColorTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //將接收到的物件，轉換成為字串
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
