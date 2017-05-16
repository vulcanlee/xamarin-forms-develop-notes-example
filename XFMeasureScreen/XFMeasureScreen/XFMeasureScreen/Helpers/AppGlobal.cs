using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMeasureScreen.Helpers
{
    public static class AppGlobal
    {
        #region 這裡定義從原生那裏取得的螢幕尺寸與縮放比
        /// <summary>
        /// 這個裝置的螢幕寬度的設計畫素
        /// </summary>
        public static double DisplayScreenWidth = 0f;
        /// <summary>
        /// 這個裝置的螢幕高度的設計畫素
        /// </summary>
        public static double DisplayScreenHeight = 0f;
        /// <summary>
        /// 這個裝置的設計尺寸縮放比
        /// </summary>
        public static double DisplayScaleFactor = 0f;
        /// <summary>
        /// 這個裝置的螢幕寬度的實際畫素
        /// </summary>
        public static double PhysicalDisplayScreenWidth = 0f;
        /// <summary>
        /// 這個裝置的螢幕高度的實際畫素
        /// </summary>
        public static double PhysicalDisplayScreenHeight = 0f;
        #endregion

    }
}
