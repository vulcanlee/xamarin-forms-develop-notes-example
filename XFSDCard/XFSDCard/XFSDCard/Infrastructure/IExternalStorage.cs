using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFSDCard.Infrastructure
{
    /// <summary>
    /// 這個介面可以支援針對 Android 平台下，讀寫記憶卡內的檔案
    /// </summary>
    public interface IExternalStorage
    {
        /// <summary>
        /// 從記憶卡內，寫入資料到檔案
        /// </summary>
        /// <param name="path">傳入要寫入的路徑與檔案名稱</param>
        /// <returns></returns>
        bool Write(string path, string filename, string content);
        /// <summary>
        /// 從記憶卡內，讀取檔案內容
        /// </summary>
        /// <param name="path">傳入要讀取的路徑與檔案名稱</param>
        /// <returns></returns>
        string Read(string path, string filename);
    }
}
