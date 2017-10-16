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
        public void MakeDownloadFolder(string fullFileName, string mimeType)
        {
            var filePath = fullFileName;
            var fileName = Path.GetFileName(fullFileName);
            Java.IO.File file = new Java.IO.File(fullFileName);

            var context = Android.App.Application.Context;
            DownloadManager downloadManager = (DownloadManager)context.GetSystemService(Context.DownloadService);
            downloadManager.AddCompletedDownload(fileName, fileName, true, mimeType, fullFileName, file.Length(), true);
        }

        public void OpenFile(string fullFileName)
        {
            try
            {
                var filePath = fullFileName;
                var fileName = Path.GetFileName(fullFileName);

                var bytes = File.ReadAllBytes(filePath);

                //將這個檔案，複製到公開的資料夾內，也就是說，您下載的檔案，是可以儲存在應用程式沙箱資料夾內
                string externalStorageState = global::Android.OS.Environment.ExternalStorageState;
                var externalPath = global::Android.OS.Environment.ExternalStorageDirectory.Path + "/" + 
                    global::Android.OS.Environment.DirectoryDownloads + "/" + fileName;
                File.WriteAllBytes(externalPath, bytes);

                // 取得這個檔案的 Android File 物件
                Java.IO.File file = new Java.IO.File(externalPath);
                file.SetReadable(true);

                string application = "";
                string extension = Path.GetExtension(filePath);

                // 設定 mimeType
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

                // 開啟這個檔案
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