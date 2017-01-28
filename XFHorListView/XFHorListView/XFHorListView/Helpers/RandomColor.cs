using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFHorListView.Helpers
{
    /// <summary>
    /// 這個支援類別，將提供動態顏色的物件
    /// </summary>
    public static class RandomColor
    {
        static readonly Random random = new Random();

        static RandomColor()
        {
            colors = "#D32F2F, #B71C1C, #C2185B, #880E4F, #7B1FA2, #4A148C, #512DA8, #311B92, #303F9F, #1A237E, #1976D2, #0D47A1, #0288D1, #01579B, #0097A7, #006064, #00796B, #004D40, #388E3C, #1B5E20, #689F38, #33691E, #AFB42B, #827717, #FBC02D, #F57F17, #FFA000, #FF6F00, #F57C00, #E65100, #E64A19, #BF360C, #5D4037, #3E2723, #616161, #212121, #455A64, #263238"
                .Split(new string[] { ",", " " },
                    StringSplitOptions.RemoveEmptyEntries);
        }

        static readonly string[] colors;

        /// <summary>
        /// 隨機產生一個顏色物件
        /// </summary>
        public static Xamarin.Forms.Color PickColor
        {
            get
            {
                // 使用 FromHex 靜態方法，可以根據文字內容，產生一個 Xamarin.Forms 中會用到的 Color 物件
                return Xamarin.Forms.Color.FromHex(colors[random.Next(colors.Length)]);
            }
        }
    }
}
