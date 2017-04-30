using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFCorelPicker.Models;

namespace XFCorelPicker.ViewModels
{



    [ImplementPropertyChanged]
    public class MyTaskVM 
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 基本型別與類別的 Property
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        #endregion

        #region 集合類別的 Property

        #endregion

        #endregion

        #region Field 欄位

        #endregion

        #region Constructor 建構式
        public MyTaskVM()
        {

            #region 相依性服務注入的物件

            #endregion

            #region 頁面中綁定的命令

            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        #endregion

    }
}
