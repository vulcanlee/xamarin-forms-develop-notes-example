using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFImgCrop.Droid.Infrastructures;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_Droid))]
namespace XFImgCrop.Droid.Infrastructures
{
    public class Picture_Droid : XFImgCrop.Infrastructures.IPicture
    {
        public byte[] LoadPictureFromDisk(string filename)
        {
            byte[] fooResult = new byte[10];
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            string name = filename + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);

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
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            string name = filename + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new File(filePath)));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

        }
    }
}