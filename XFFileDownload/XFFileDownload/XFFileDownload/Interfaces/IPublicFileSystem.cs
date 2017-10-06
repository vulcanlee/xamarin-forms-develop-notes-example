using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFileDownload.Interfaces
{
    /// <summary>
    /// 提供各種非應用程式沙箱內的資料夾
    /// </summary>
    public interface IPublicFileSystem
    {
        IFolder PublicDownloadFolder { get; }
        IFolder PublicPictureFolder { get; }
        IFolder PublicMovieFolder { get; }
        IFolder PublicDCIMFolder { get; }
    }
}
