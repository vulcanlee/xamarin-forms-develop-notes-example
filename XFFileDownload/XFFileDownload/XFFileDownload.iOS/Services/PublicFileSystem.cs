using System;
using System.Collections.Generic;
using System.Text;
using PCLStorage;
using XFFileDownload.Interfaces;
using XFFileDownload.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(PublicFileSystem))]
namespace XFFileDownload.iOS.Services
{
    class PublicFileSystem : IPublicFileSystem
    {
        public IFolder PublicDownloadFolder
        {
            get
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return new FileSystemFolder(localAppData);
            }
        }
        public IFolder PublicPictureFolder
        {
            get
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return new FileSystemFolder(localAppData);
            }
        }
        public IFolder PublicMovieFolder
        {
            get
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return new FileSystemFolder(localAppData);
            }
        }
        public IFolder PublicDCIMFolder
        {
            get
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return new FileSystemFolder(localAppData);
            }
        }
    }
}
