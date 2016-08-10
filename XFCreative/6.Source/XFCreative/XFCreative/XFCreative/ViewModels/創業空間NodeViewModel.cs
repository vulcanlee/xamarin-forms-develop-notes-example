using Newtonsoft.Json;
using Plugin.ExternalMaps;
using Plugin.Share;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFCreative.Services;

namespace XFCreative.Models
{
    public class 創業空間NodeViewModel : BindableBase
    {
        public DelegateCommand<創業空間NodeViewModel> 查看地圖Command { get; set; }
        public DelegateCommand<創業空間NodeViewModel> 查看官網Command { get; set; }

        #region 創業空間名稱
        private string _創業空間名稱;
        public string 創業空間名稱
        {
            get { return _創業空間名稱; }
            set { SetProperty(ref _創業空間名稱, value); }
        }
        #endregion

        #region 空間主照片
        private string _空間主照片;

        public string 空間主照片
        {
            get { return _空間主照片; }
            set { SetProperty(ref _空間主照片, value); }
        }
        #endregion

        #region 使用坪數
        private string _使用坪數;

        public string 使用坪數
        {
            get { return _使用坪數; }
            set { SetProperty(ref _使用坪數, value); }
        }
        #endregion

        #region 地址
        private string _地址;

        public string 地址
        {
            get { return _地址; }
            set { SetProperty(ref _地址, value); }        }

        #endregion

        public 創業空間NodeViewModel()
        {
            查看地圖Command = new DelegateCommand<創業空間NodeViewModel>(查看地圖);
            查看官網Command = new DelegateCommand<創業空間NodeViewModel>(查看官網);
        }


        private async void 查看官網(創業空間NodeViewModel obj)
        {
            var 創業空間明細 = GlobalData.創業空間Repository.Items.FirstOrDefault(x => x.創業空間名稱 == obj.創業空間名稱);
            if (創業空間明細 != null)
            {
                if (string.IsNullOrEmpty(創業空間明細.官方網站) == false)
                {
                    await CrossShare.Current.OpenBrowser(創業空間明細.官方網站);
                }
            }
        }

        private async void 查看地圖(創業空間NodeViewModel obj)
        {
            var 創業空間明細 = GlobalData.創業空間Repository.Items.FirstOrDefault(x => x.創業空間名稱 == obj.創業空間名稱);
            if (創業空間明細 != null)
            {
                if (string.IsNullOrEmpty(創業空間明細.座標經度) == false && string.IsNullOrEmpty(創業空間明細.座標緯度) == false)
                {
                    var fooLat = Convert.ToDouble(創業空間明細.座標緯度);
                    var fooLon = Convert.ToDouble(創業空間明細.座標經度);
                    var success = await CrossExternalMaps.Current.NavigateTo(創業空間明細.創業空間名稱, fooLat, fooLon, Plugin.ExternalMaps.Abstractions.NavigationType.Default);
                }
            }
        }
    }


}
