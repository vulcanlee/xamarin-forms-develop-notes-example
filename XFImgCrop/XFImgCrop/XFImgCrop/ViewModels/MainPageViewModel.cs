using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFImgCrop.Infrastructures;

namespace XFImgCrop.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 基本型別與類別的 Property
        public ImageSource fooImageSource { get; set; }
        public ImageSource fooLoadImageSource { get; set; }
        #endregion

        #region 集合類別的 Property

        #endregion

        #endregion

        #region Field 欄位

        #region ViewModel 內使用到的欄位
        ImageSource _imageSource;
        private IMedia _mediaPicker;
        Image image;

        public delegate Task TakePictureDelegate(byte[] image);
        public TakePictureDelegate NavigationImageCropping;
        #endregion

        #region 命令物件欄位

        public DelegateCommand TakePictureCommand { get; set; }
        public DelegateCommand LoadPictureCommand { get; set; }
        public DelegateCommand SavePictureCommand { get; set; }

        #endregion

        #region 注入物件欄位
        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IPicture _picture;
        #endregion

        #endregion

        #region Constructor 建構式
        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator,
            IPageDialogService dialogService , IPicture picture
            )
        {
            //IUnityContainer myContainer = (App.Current as PrismApplication).Container;
            //_picture= myContainer.Resolve<IPicture>();
            #region 相依性服務注入的物件
            _picture = picture;
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            TakePictureCommand = new DelegateCommand(async () =>
            {
                var fooAction = await _dialogService.DisplayActionSheetAsync("請選擇圖片來源", "取消", null, "相簿", "拍照");
                if (fooAction == "相簿")
                {
                    App.CroppedImage = null;
                    await SelectPicture();
                }
                else if (fooAction == "拍照")
                {
                    App.CroppedImage = null;
                    await TakePicture();
                }
                else if (fooAction == "取消")
                {

                }
            });

            SavePictureCommand = new DelegateCommand(() =>
            {
                if (App.CroppedImage != null)
                {
                    _picture.SavePictureToDisk("MyCrop", App.CroppedImage);
                }
            });

            LoadPictureCommand = new DelegateCommand(() =>
            {
                App.CroppedImage = _picture.LoadPictureFromDisk("MyCrop");
                Stream stream = new MemoryStream(App.CroppedImage);
                fooLoadImageSource = ImageSource.FromStream(() => stream);
            });
            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await ViewModelInit();
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        /// <summary>
        /// ViewModel 資料初始化
        /// </summary>
        /// <returns></returns>
        private async Task ViewModelInit()
        {
            await Task.Delay(100);
        }

        public void Refresh()
        {
            try
            {
                if (App.CroppedImage != null)
                {
                    Stream stream = new MemoryStream(App.CroppedImage);
                    fooImageSource = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region Photos

        private async void Setup()
        {
            if (_mediaPicker != null)
            {
                return;
            }

            ////RM: hack for working on windows phone? 
            await CrossMedia.Current.Initialize();
            _mediaPicker = CrossMedia.Current;
        }

        private async Task SelectPicture()
        {
            Setup();

            _imageSource = null;

            try
            {

                var mediaFile = await CrossMedia.Current.PickPhotoAsync();

                _imageSource = ImageSource.FromStream(mediaFile.GetStream);

                var memoryStream = new MemoryStream();
                await mediaFile.GetStream().CopyToAsync(memoryStream);
                byte[] imageAsByte = memoryStream.ToArray();

                await NavigationImageCropping(imageAsByte);
                //await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task TakePicture()
        {
            Setup();

            _imageSource = null;

            try
            {
                var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    //DefaultCamera = CameraDevice.Front
                });

                _imageSource = ImageSource.FromStream(mediaFile.GetStream);

                var memoryStream = new MemoryStream();
                await mediaFile.GetStream().CopyToAsync(memoryStream);
                byte[] imageAsByte = memoryStream.ToArray();

                await NavigationImageCropping(imageAsByte);
                //await Navigation.PushModalAsync(new CropView(imageAsByte, Refresh));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion
        #endregion

    }
}
