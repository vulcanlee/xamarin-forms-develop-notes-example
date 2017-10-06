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
using PCLStorage;
using XFFileDownload.Interfaces;
using XFFileDownload.Droid.Services;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(PublicFileSystem))]
namespace XFFileDownload.Droid.Services
{
    class PublicFileSystem : IPublicFileSystem
    {
        // https://developer.android.com/reference/android/os/Environment.html#DIRECTORY_DOWNLOADS
        public IFolder PublicDownloadFolder
        {
            get
            {
                //var localAppData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var localAppData = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
                return new FileSystemFolder(localAppData);
            }
        }
        public IFolder PublicPictureFolder
        {
            get
            {
                var localAppData = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
                return new FileSystemFolder(localAppData);
            }
        }
        public IFolder PublicMovieFolder
        {
            get
            {
                var localAppData = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMovies).AbsolutePath;
                return new FileSystemFolder(localAppData);
            }
        }
        public IFolder PublicDCIMFolder
        {
            get
            {
                var localAppData = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
                return new FileSystemFolder(localAppData);
            }
        }
    }
}