using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.Models
{
    public class 創業空間資料
    {
        public string 創業空間名稱 { get; set; }
        public string 所屬單位 { get; set; }
        public string 創業空間類型 { get; set; }
        public string 招募團隊類型 { get; set; }
        public string 座標經度 { get; set; }
        public string 座標緯度 { get; set; }
        public string 空間是否出租 { get; set; }
        public string 空間主照片 { get; set; }
        public string 縣市區域 { get; set; }
        public string 地址 { get; set; }
        public string 標籤 { get; set; }
        public string 詳細照片 { get; set; }
        public string 聯絡人 { get; set; }
        public string 連絡電話 { get; set; }
        [JsonProperty(PropertyName= "聯絡e-mail")]
        public string 聯絡email { get; set; }
        public string 官方網站 { get; set; }
        public string 建築類型 { get; set; }
        public string 建造材質 { get; set; }
        public string 建物現況 { get; set; }
        [JsonProperty(PropertyName = "樓別/樓高")]
        public string 樓別樓高 { get; set; }
        public string 使用坪數 { get; set; }
        public string 空間資訊 { get; set; }
        [JsonProperty(PropertyName = "進駐/使用人數")]
        public string 進駐使用人數 { get; set; }
        public string 價格方案 { get; set; }
        public string 使用時間 { get; set; }
        public string 備註 { get; set; }
        public DateTime 建立時間 { get; set; }
        public DateTime 修改時間 { get; set; }
    }
}
