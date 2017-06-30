using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFImgCrop.Infrastructures
{
    // http://www.goxuni.com/668633-how-to-save-an-image-to-a-device-using-xuni-and-xamarin-forms/
    public interface IPicture
    {
        void SavePictureToDisk(string filename, byte[] imageData);
        byte[] LoadPictureFromDisk(string filename);
    }
}
