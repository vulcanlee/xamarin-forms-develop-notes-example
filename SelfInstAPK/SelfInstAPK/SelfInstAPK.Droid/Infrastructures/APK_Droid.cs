using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SelfInstAPK.Infrastructures;


[assembly: Xamarin.Forms.Dependency(typeof(SelfInstAPK.Droid.Infrastructures.APK_Droid))]
namespace SelfInstAPK.Droid.Infrastructures
{
    public class APK_Droid : IAPK
    {
        public string DownlaodPath = "";
        public string Filename = "new.apk";
        public string FullFilename = "";
        FileStream fooStream;

        public void GenApkFile(Stream downloadStream)
        {
            DownlaodPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).ToString();
            //DownlaodPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            FullFilename = Path.Combine(DownlaodPath, Filename);

            if (File.Exists(FullFilename) == false)
            {
                Directory.CreateDirectory(DownlaodPath);
                fooStream= File.Create(FullFilename);
            }
            else
            {
                fooStream= File.OpenWrite(FullFilename);
            }


            //DownlaodPath = Android.OS.Environment.DirectoryDownloads;
            using (FileStream fs = fooStream)
            {
                downloadStream.CopyTo(fs);
            }
        }

        public void InstallAPK()
        {
            Intent setupIntent = new Intent(Intent.ActionView);
            setupIntent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(FullFilename)), "application/vnd.android.package-archive");
            setupIntent.AddFlags(ActivityFlags.NewTask);

            var context = Android.App.Application.Context;
            context.StartActivity(setupIntent);
        }
    }
}