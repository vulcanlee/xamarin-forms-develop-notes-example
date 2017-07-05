using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfInstAPK.Infrastructures
{
    public interface IAPK
    {
        void InstallAPK();

        void GenApkFile(Stream downloadStream);
    }
}
