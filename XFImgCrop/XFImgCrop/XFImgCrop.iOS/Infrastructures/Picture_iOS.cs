using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(XFImgCrop.iOS.Infrastructures.Picture_iOS))]
namespace XFImgCrop.iOS.Infrastructures
{
    public class Picture_iOS : XFImgCrop.Infrastructures.IPicture
    {
        public byte[] LoadPictureFromDisk(string filename)
        {
            byte[] fooResult = new byte[10];

            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = System.IO.Path.Combine(documentsDirectory, filename);

            try
            {
                fooResult = System.IO.File.ReadAllBytes(filePath);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

            return fooResult;
        }

        public void SavePictureToDisk(string filename, byte[] imageData)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = System.IO.Path.Combine(documentsDirectory, filename);

            try
            {
                System.IO.File.WriteAllBytes(filePath, imageData);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }
    }
}
