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
using XFFileDownload.Interfaces;
using XFFileDownload.Droid.Services;
using System.IO;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OpenFileByName))]
namespace XFFileDownload.Droid.Services
{
    public class OpenFileByName : IOpenFileByName
    {
        public void OpenFile(string fullFileName)
        {
            try
            {
                var filePath = fullFileName;
                var fileName = Path.GetFileName(fullFileName);

                var bytes = File.ReadAllBytes(filePath);

                //Copy the private file's data to the EXTERNAL PUBLIC location
                string externalStorageState = global::Android.OS.Environment.ExternalStorageState;
                var externalPath = global::Android.OS.Environment.ExternalStorageDirectory.Path + "/" + 
                    global::Android.OS.Environment.DirectoryDownloads + "/" + fileName;
                File.WriteAllBytes(externalPath, bytes);

                Java.IO.File file = new Java.IO.File(externalPath);
                file.SetReadable(true);

                string application = "";
                string extension = Path.GetExtension(filePath);

                // get mimeTye
                switch (extension.ToLower())
                {
                    case ".txt":
                        application = "text/plain";
                        break;
                    case ".doc":
                    case ".docx":
                        application = "application/msword";
                        break;
                    case ".pdf":
                        application = "application/pdf";
                        break;
                    case ".xls":
                    case ".xlsx":
                        application = "application/vnd.ms-excel";
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        application = "image/jpeg";
                        break;
                    default:
                        application = "*/*";
                        break;
                }

                //Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + filePath);
                Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(uri, application);
                intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                Forms.Context.StartActivity(intent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}