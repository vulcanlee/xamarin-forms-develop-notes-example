using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleListView
{
    /// <summary>
    /// 這個 ViewModel 將會用於展示如何將集合物件，綁訂到 ListView 上
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// 定義 ListView 需要用到的紀錄集合
        /// </summary>
        public ObservableCollection<someDataClass> MyItemList { get; set; }

        public ViewModel()
        {
            // 當 ViewModel 物件被建立的同時，也會將集合物件進行資料初始化
            MyItemList = new ObservableCollection<someDataClass>()
            {
                new someDataClass { sometext="sometext1", othertext="othertext1" },
                new someDataClass { sometext="sometext2", othertext="othertext2" },
                new someDataClass { sometext="sometext3", othertext="othertext3" },
                new someDataClass { sometext="sometext4", othertext="othertext4" },
            };
        }
    }

    /// <summary>
    /// 集合記錄內的每筆紀錄資料內容
    /// </summary>
    public class someDataClass
    {
        public string sometext { get; set; }
        public string othertext { get; set; }
    }
}
