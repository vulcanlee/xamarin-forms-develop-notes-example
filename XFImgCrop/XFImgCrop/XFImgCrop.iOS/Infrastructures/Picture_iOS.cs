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




            //var chartImage = new UIImage(NSData.FromArray(imageData));
            //chartImage.SaveToPhotosAlbum((image, error) =>
            //{
            //    //you can retrieve the saved UI Image as well if needed using
            //    //var i = image as UIImage;
            //    if (error != null)
            //    {
            //        Console.WriteLine(error.ToString());
            //    }
            //});
        }

        // public async void SavePictureToDisk(ImageSource imgSrc, int Id)
        // {
        //     var renderer = new StreamImagesourceHandler();
        //     var photo = await renderer.LoadImageAsync(imgSrc);
        //     var documentsDirectory = Environment.GetFolderPath
        //         (Environment.SpecialFolder.Personal);
        //     string jpgFilename = System.IO.Path.Combine(
        //documentsDirectory, Id.ToString() + ".jpg");
        //     NSData imgData = photo.AsJPEG();
        //     NSError err = null;
        //     if (imgData.Save(jpgFilename, false, out err))
        //     {
        //         Console.WriteLine("saved as " + jpgFilename);
        //     }
        //     else
        //     {
        //         Console.WriteLine("NOT saved as " + jpgFilename +
        // " because" + err.LocalizedDescription);
        //     }

        // }
    }
}
