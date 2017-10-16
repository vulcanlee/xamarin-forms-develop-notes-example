using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UIKit;
using Xamarin.Forms;
using XFFileDownload.Interfaces;
using XFFileDownload.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(OpenFileByName))]
namespace XFFileDownload.iOS.Services
{
    public class OpenFileByName : IOpenFileByName
    {
        public void MakeDownloadFolder(string fullFileName, string mimeType)
        {
        }

        public void OpenFile(string fullFileName)
        {
            var filePath = fullFileName;
            var fileName = Path.GetFileName(fullFileName);

            var PreviewController = UIDocumentInteractionController.FromUrl(NSUrl.FromFilename(filePath));
            PreviewController.Delegate = new UIDocumentInteractionControllerDelegateClass(UIApplication.SharedApplication.KeyWindow.RootViewController);
            Device.BeginInvokeOnMainThread(() =>
            {
                PreviewController.PresentPreview(true);
            });
        }
    }

    public class UIDocumentInteractionControllerDelegateClass : UIDocumentInteractionControllerDelegate
    {
        UIViewController ownerVC;

        public UIDocumentInteractionControllerDelegateClass(UIViewController vc)
        {
            ownerVC = vc;
        }

        public override UIViewController ViewControllerForPreview(UIDocumentInteractionController controller)
        {
            return ownerVC;
        }

        public override UIView ViewForPreview(UIDocumentInteractionController controller)
        {
            return ownerVC.View;
        }
    }
}
