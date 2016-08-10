using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.Models
{
    public class 創業空間明細 : BindableBase
    {
        #region 創業空間名稱
        private string _創業空間名稱;
        public string 創業空間名稱
        {
            get { return _創業空間名稱; }
            set { SetProperty(ref _創業空間名稱, value); }
        }
        #endregion

        #region 所屬單位
        private string _所屬單位;

        public string 所屬單位
        {
            get { return _所屬單位; }
            set { SetProperty(ref _所屬單位, value); }
        }
        #endregion

        #region 創業空間類型
        private string _創業空間類型;

        public string 創業空間類型
        {
            get { return _創業空間類型; }
            set { SetProperty(ref _創業空間類型, value); }
        }
        #endregion

        #region 招募團隊類型
        private string _招募團隊類型;

        public string 招募團隊類型
        {
            get { return _招募團隊類型; }
            set { SetProperty(ref _招募團隊類型, value); }
        }
        #endregion

        #region 座標經度
        private string _座標經度;

        public string 座標經度
        {
            get { return _座標經度; }
            set { SetProperty(ref _座標經度, value); }
        }
        #endregion

        #region 座標緯度
        private string _座標緯度;

        public string 座標緯度
        {
            get { return _座標緯度; }
            set { SetProperty(ref _座標緯度, value); }
        }
        #endregion

        #region 空間是否出租
        private string _空間是否出租;

        public string 空間是否出租
        {
            get { return _空間是否出租; }
            set { SetProperty(ref _空間是否出租, value); }
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

        #region 縣市區域
        private string _縣市區域;

        public string 縣市區域
        {
            get { return _縣市區域; }
            set { SetProperty(ref _縣市區域, value); }
        }
        #endregion

        #region 地址
        private string _地址;

        public string 地址
        {
            get { return _地址; }
            set { SetProperty(ref _地址, value); }
        }
        #endregion

        #region 標籤
        private string _標籤;

        public string 標籤
        {
            get { return _標籤; }
            set { SetProperty(ref _標籤, value); }
        }
        #endregion

        #region 詳細照片
        private string _詳細照片;

        public string 詳細照片
        {
            get { return _詳細照片; }
            set { SetProperty(ref _詳細照片, value); }
        }
        #endregion

        #region 聯絡人
        private string _聯絡人;

        public string 聯絡人
        {
            get { return _聯絡人; }
            set { SetProperty(ref _聯絡人, value); }
        }
        #endregion

        #region 連絡電話
        private string _連絡電話;

        public string 連絡電話
        {
            get { return _連絡電話; }
            set { SetProperty(ref _連絡電話, value); }
        }
        #endregion

        #region 聯絡email
        private string _聯絡email;

        public string 聯絡email
        {
            get { return _聯絡email; }
            set { SetProperty(ref _聯絡email, value); }
        }
        #endregion

        #region 官方網站
        private string _官方網站;

        public string 官方網站
        {
            get { return _官方網站; }
            set { SetProperty(ref _官方網站, value); }
        }
        #endregion

        #region 建築類型
        private string _建築類型;

        public string 建築類型
        {
            get { return _建築類型; }
            set { SetProperty(ref _建築類型, value); }
        }
        #endregion

        #region 建造材質
        private string _建造材質;

        public string 建造材質
        {
            get { return _建造材質; }
            set { SetProperty(ref _建造材質, value); }
        }
        #endregion

        #region 建物現況
        private string _建物現況;

        public string 建物現況
        {
            get { return _建物現況; }
            set { SetProperty(ref _建物現況, value); }
        }
        #endregion

        #region 樓別樓高
        private string _樓別樓高;

        public string 樓別樓高
        {
            get { return _樓別樓高; }
            set { SetProperty(ref _樓別樓高, value); }
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

        #region 空間資訊
        private string _空間資訊;

        public string 空間資訊
        {
            get { return _空間資訊; }
            set { SetProperty(ref _空間資訊, value); }
        }
        #endregion

        #region 進駐使用人數
        private string _進駐使用人數;

        public string 進駐使用人數
        {
            get { return _進駐使用人數; }
            set { SetProperty(ref _進駐使用人數, value); }
        }
        #endregion

        #region 價格方案
        private string _價格方案;

        public string 價格方案
        {
            get { return _價格方案; }
            set { SetProperty(ref _價格方案, value); }
        }
        #endregion

        #region 使用時間
        private string _使用時間;

        public string 使用時間
        {
            get { return _使用時間; }
            set { SetProperty(ref _使用時間, value); }
        }
        #endregion

        #region 備註
        private string _備註;

        public string 備註
        {
            get { return _備註; }
            set { SetProperty(ref _備註, value); }
        }
        #endregion

        #region 建立時間
        private DateTime _建立時間;

        public DateTime 建立時間
        {
            get { return _建立時間; }
            set { SetProperty(ref _建立時間, value); }
        }
        #endregion

        #region 修改時間
        private DateTime _修改時間;

        public DateTime 修改時間
        {
            get { return _修改時間; }
            set { SetProperty(ref _修改時間, value); }
        }
        #endregion

    }


}
