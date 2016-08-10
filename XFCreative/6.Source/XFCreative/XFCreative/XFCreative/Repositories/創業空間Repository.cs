using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XFCreative.Models;

namespace XFCreative.Repositories
{
    public class 創業空間Repository
    {
        public List<創業空間資料> Items = new List<創業空間資料>();

        public async Task 取得最新資料()
        {
            var fooClient = new HttpClient();
            var fooRet = await fooClient.GetStringAsync("http://sme.moeasmea.gov.tw/startup/upload/opendata/gov_source_map_opendata.json");

            Items = JsonConvert.DeserializeObject<List<創業空間資料>>(fooRet);

            foreach (var item in Items)
            {
                item.空間主照片 = item.空間主照片.Replace("https", "http");
                item.詳細照片 = item.詳細照片.Replace("https", "http");
            }
        }
    }
}
