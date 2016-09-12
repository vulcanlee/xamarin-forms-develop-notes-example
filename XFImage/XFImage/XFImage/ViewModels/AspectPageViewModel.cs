using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;
using PCLStorage;

namespace XFImage.ViewModels
{
    public class AspectPageViewModel : BindableBase, INavigationAware
    {
        private string demoImage;
        public string DemoImage
        {
            get { return demoImage; }
            set { SetProperty(ref demoImage, value); }
        }

        public string ImgSize { get; set; }
        public string ImgType { get; set; }

        private Aspect imgAspect;
        public Aspect ImgAspect
        {
            get { return imgAspect; }
            set { SetProperty(ref imgAspect, value); }
        }

        private LayoutOptions imgAlignment;
        public LayoutOptions ImgAligment
        {
            get { return imgAlignment; }
            set { SetProperty(ref imgAlignment, value); }
        }

        public DelegateCommand ImgAspectFillCommand { get; private set; }
        public DelegateCommand ImgAspectFitCommand { get; private set; }
        public DelegateCommand ImgFillCommand { get; private set; }
        public DelegateCommand 橫式圖片Command { get; private set; }
        public DelegateCommand 直式圖片Command { get; private set; }
        public DelegateCommand 大圖片Command { get; private set; }
        public DelegateCommand 小圖片Command { get; private set; }
        public DelegateCommand<string> 圖片AlignmentCommand { get; private set; }

        public AspectPageViewModel()
        {
            DemoImage = "https://developer.xamarin.com/demo/IMG_3256.JPG?width=640";
            ImgAspect = Aspect.Fill;
            ImgAligment = LayoutOptions.End;
            ImgSize = "L";
            ImgType = "L";

            ImgAspectFillCommand = new DelegateCommand(ImgAspectFill);
            ImgAspectFitCommand = new DelegateCommand(ImgAspectFit);
            ImgFillCommand = new DelegateCommand(ImgFill);
            橫式圖片Command = new DelegateCommand(橫式圖片);
            直式圖片Command = new DelegateCommand(直式圖片);
            大圖片Command = new DelegateCommand(大圖片);
            小圖片Command = new DelegateCommand(小圖片);
            圖片AlignmentCommand = new DelegateCommand<string>(圖片Alignment);
        }

        private void 小圖片()
        {
            ImgSize = "S";
            RefreshImage();
        }

        private void 大圖片()
        {
            ImgSize = "L";
            RefreshImage();
        }

        void RefreshImage()
        {
            if (ImgType == "L")
            {
                if (ImgSize == "L")
                {
                    DemoImage = "https://raw.githubusercontent.com/vulcanlee/xamarin-forms-develop-notes-example/master/XFImage_Image/PCL/hImage.JPG";
                }
                else
                {
                    DemoImage = "https://raw.githubusercontent.com/vulcanlee/xamarin-forms-develop-notes-example/master/XFImage_Image/PCL/hsImage.jpg";
                }
            }
            else
            {
                if (ImgSize == "L")
                {
                    DemoImage = "https://raw.githubusercontent.com/vulcanlee/xamarin-forms-develop-notes-example/master/XFImage_Image/PCL/vImage.jpg";
                }
                else
                {
                    DemoImage = "https://raw.githubusercontent.com/vulcanlee/xamarin-forms-develop-notes-example/master/XFImage_Image/PCL/vsImage.jpg";
                }
            }
        }

        private void 圖片Alignment(string alignment)
        {
            if (alignment == "Fill")
            {
                ImgAligment = LayoutOptions.Fill;
            }
            else if (alignment == "End")
            {
                ImgAligment = LayoutOptions.End;
            }
            else if (alignment == "Start")
            {
                ImgAligment = LayoutOptions.Start;
            }
            else if (alignment == "Center")
            {
                ImgAligment = LayoutOptions.Center;
            }
        }

        private void 直式圖片()
        {
            ImgType = "P";
            RefreshImage();
        }

        private void 橫式圖片()
        {
            ImgType = "L";
            RefreshImage();
        }

        private void ImgFill()
        {
            ImgAspect = Aspect.Fill;
        }

        private void ImgAspectFit()
        {
            ImgAspect = Aspect.AspectFit;
        }

        private void ImgAspectFill()
        {
            ImgAspect = Aspect.AspectFill;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
