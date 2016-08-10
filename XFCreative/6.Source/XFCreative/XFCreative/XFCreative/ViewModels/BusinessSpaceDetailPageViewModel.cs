using Newtonsoft.Json;
using Plugin.ExternalMaps;
using Plugin.Messaging;
using Plugin.Share;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XFCreative.Models;
using XFCreative.Services;

namespace XFCreative.ViewModels
{
    public class BusinessSpaceDetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        public readonly IPageDialogService _dialogService;


        public DelegateCommand 查看空間資訊Command { get; set; }
        public DelegateCommand 查看價格方案Command { get; set; }
        public DelegateCommand 查看地圖Command { get; set; }
        public DelegateCommand 撥打電話Command { get; set; }
        public DelegateCommand 發送簡訊Command { get; set; }
        public DelegateCommand 發送電子郵件Command { get; set; }
        public DelegateCommand 分享內容Command { get; set; }
        public DelegateCommand 分享連結Command { get; set; }
        public DelegateCommand 查看官網Command { get; set; }

       private 創業空間明細 _創業空間明細;
        public 創業空間明細 創業空間明細
        {
            get { return _創業空間明細; }
            set { SetProperty(ref _創業空間明細, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BusinessSpaceDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;
            _dialogService = dialogService;

            查看空間資訊Command = new DelegateCommand(查看空間資訊);
            查看價格方案Command = new DelegateCommand(查看價格方案);
            查看地圖Command = new DelegateCommand(查看地圖);
            撥打電話Command = new DelegateCommand(撥打電話);
            發送簡訊Command = new DelegateCommand(發送簡訊);
            發送電子郵件Command = new DelegateCommand(發送電子郵件);
            分享內容Command = new DelegateCommand(分享內容);
            分享連結Command = new DelegateCommand(分享連結);
            查看官網Command = new DelegateCommand(查看官網);
    }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("創業空間Selected"))
            {
                var foo創業空間Selected = parameters["創業空間Selected"] as 創業空間NodeViewModel;
                系統初始化(foo創業空間Selected);
            }

        }

        public void 系統初始化(創業空間NodeViewModel 創業空間NodeViewModel)
        {
            var fooItem = GlobalData.創業空間Repository.Items.FirstOrDefault(x => x.創業空間名稱 == 創業空間NodeViewModel.創業空間名稱);
            if (fooItem != null)
            {
                創業空間明細 = new 創業空間明細()
                {
                    創業空間名稱 = fooItem.創業空間名稱,
                    使用坪數 = fooItem.使用坪數,
                    使用時間 = fooItem.使用時間,
                    修改時間 = fooItem.修改時間,
                    備註 = fooItem.備註,
                    價格方案 = fooItem.價格方案,
                    創業空間類型 = fooItem.創業空間類型,
                    地址 = fooItem.地址,
                    官方網站 = fooItem.官方網站,
                    座標經度 = fooItem.座標經度,
                    座標緯度 = fooItem.座標緯度,
                    建物現況 = fooItem.建物現況,
                    建立時間 = fooItem.建立時間,
                    建築類型 = fooItem.建築類型,
                    建造材質 = fooItem.建造材質,
                    所屬單位 = fooItem.所屬單位,
                    招募團隊類型 = fooItem.招募團隊類型,
                    樓別樓高 = fooItem.樓別樓高,
                    標籤 = fooItem.標籤,
                    空間主照片 = fooItem.空間主照片,
                    空間是否出租 = fooItem.空間是否出租,
                    空間資訊 = fooItem.空間資訊,
                    縣市區域 = fooItem.縣市區域,
                    聯絡email = fooItem.聯絡email,
                    聯絡人 = fooItem.聯絡人,
                    詳細照片 = fooItem.詳細照片,
                    連絡電話 = fooItem.連絡電話,
                    進駐使用人數 = fooItem.進駐使用人數,
                };
            }
        }

        private async void 查看空間資訊()
        {
            var fooNavigationParameters = new NavigationParameters();
            var fooItem = new 網頁資料NodeViewModel()
            {
                標題名稱 = "空間資訊",
                網頁內容 = 創業空間明細.空間資訊,
            };
           
            fooNavigationParameters.Add("網頁資料NodeViewModel", fooItem);
            await _navigationService.Navigate("WebView更多資訊Page", fooNavigationParameters);
        }

        private async void 查看價格方案()
        {
            var fooNavigationParameters = new NavigationParameters();
            var fooItem = new 網頁資料NodeViewModel()
            {
                標題名稱 = "價格方案",
                網頁內容 = 創業空間明細.價格方案,
            };

            fooNavigationParameters.Add("網頁資料NodeViewModel", fooItem);
            await _navigationService.Navigate("WebView更多資訊Page", fooNavigationParameters);
        }

        private async void 查看地圖()
        {
            if(string.IsNullOrEmpty(創業空間明細.座標經度) == false && string.IsNullOrEmpty(創業空間明細.座標緯度)==false)
            {
                var fooLat = Convert.ToDouble(創業空間明細.座標緯度);
                var fooLon = Convert.ToDouble(創業空間明細.座標經度);
                var success = await CrossExternalMaps.Current.NavigateTo(創業空間明細.創業空間名稱, fooLat, fooLon, Plugin.ExternalMaps.Abstractions.NavigationType.Default);
            }
        }

        private void 撥打電話()
        {
            if (string.IsNullOrEmpty(創業空間明細.連絡電話) == false)
            {
                // Make Phone Call
                var phoneCallTask = MessagingPlugin.PhoneDialer;
                if (phoneCallTask.CanMakePhoneCall)
                    phoneCallTask.MakePhoneCall(創業空間明細.連絡電話);
            }
        }

        private async void 分享內容()
        {
            if (string.IsNullOrEmpty(創業空間明細.官方網站) == false)
            {
                var title = "我找到一個好地方";
                var message = 創業空間明細.創業空間名稱;

                // Share message and an optional title.
                await CrossShare.Current.Share(message, title);
            }
        }

        private async void 分享連結()
        {
            if (string.IsNullOrEmpty(創業空間明細.官方網站) == false)
            {
                var title = "我找到一個好地方";
                var message = 創業空間明細.創業空間名稱;
                var url = 創業空間明細.官方網站;

                // Share a link and an optional title and message.
                await CrossShare.Current.ShareLink(url, message, title);
            }
        }

        private async void 發送電子郵件()
        {
            await _dialogService.DisplayAlert("抱歉", $"此功能尚未建置", "確定");
            //var emailTask = MessagingPlugin.EmailMessenger;
            //if (emailTask.CanSendEmail)
            //{
            //    // Send simple e-mail to single receiver without attachments, CC, or BCC.
            //    emailTask.SendEmail("plugins@xamarin.com", "Xamarin Messaging Plugin", "Hello from your friends at Xamarin!");

            //    // Send a more complex email with the EmailMessageBuilder fluent interface.
            //    var email = new EmailMessageBuilder()
            //      .To("plugins@xamarin.com")
            //      .Cc("plugins.cc@xamarin.com")
            //      .Bcc(new[] { "plugins.bcc@xamarin.com", "plugins.bcc2@xamarin.com" })
            //      .Subject("Xamarin Messaging Plugin")
            //      .Body("Hello from your friends at Xamarin!")
            //      .Build();

            //    emailTask.SendEmail(email);
            //}
        }

        private async void 發送簡訊()
        {
            await _dialogService.DisplayAlert("抱歉", $"此功能尚未建置", "確定");
            //var smsMessenger = MessagingPlugin.SmsMessenger;
            //if (smsMessenger.CanSendSms)
            //    smsMessenger.SendSms("+272193343499", "Hello from your friends at Xamarin!");
        }

        private async void 查看官網()
        {
            if (string.IsNullOrEmpty(創業空間明細.官方網站) == false)
            {
               await CrossShare.Current.OpenBrowser(創業空間明細.官方網站);
            }
        }

    }
}
