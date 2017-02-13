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
using XFSDCard.Infrastructure;
using System.IO;
using XFSDCard.Droid.Infrastructure;

[assembly: Xamarin.Forms.Dependency(typeof(ExternalStorage))]
namespace XFSDCard.Droid.Infrastructure
{
    public class ExternalStorage : IExternalStorage
    {
        public string Read(string path, string filename)
        {
            var fooResult = "";

            // Gets the current state of the primary "external" storage device.
            if (Android.OS.Environment.ExternalStorageState == Android.OS.Environment.MediaMounted)
            {
                var foo = Android.OS.Environment.GetExternalStoragePublicDirectory("");
                var fooFullPath2 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, path);
                // 確認這個目錄是否存在
                if (Directory.Exists(fooFullPath2) == false)
                {
                    return "";
                }
                else
                {
                    // 組合最終有檔案名稱的完整路徑
                    var fooFilenamex = Path.Combine(fooFullPath2, filename);
                    if (File.Exists(fooFilenamex) == true)
                    {
                        // 從檔案中讀取出內容
                        fooResult = File.ReadAllText(fooFilenamex);
                    }
                }
            }
            return fooResult;
        }

        public bool Write(string path, string filename, string content)
        {
            var fooResult = false;

            // Gets the current state of the primary "external" storage device.
            if (Android.OS.Environment.ExternalStorageState == Android.OS.Environment.MediaMounted)
            {
                // 組合最終完整路徑
                var fooFullPath2 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, path);
                // 確認這個目錄是否存在
                if(Directory.Exists(fooFullPath2) == false)
                {
                    // 不存在，則產生它
                    Directory.CreateDirectory(fooFullPath2);
                }
                // 組合最終有檔案名稱的完整路徑
                var fooFilenamex = Path.Combine(fooFullPath2, filename);
                //將內容寫入檔案內
                File.WriteAllText(fooFilenamex, content);
            }

            return fooResult;
        }
    }
}