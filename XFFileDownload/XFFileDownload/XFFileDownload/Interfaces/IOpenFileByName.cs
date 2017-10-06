using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFileDownload.Interfaces
{
    /// <summary>
    /// 指定完整檔案路徑名稱，使用手機內預設安裝 App 開以這個檔案內容
    /// </summary>
    public interface IOpenFileByName
    {
        /// <summary>
        /// 使用本機 App 開啟檔案
        /// </summary>
        /// <param name="fullFileName"></param>
        void OpenFile(string fullFileName);
    }
}
