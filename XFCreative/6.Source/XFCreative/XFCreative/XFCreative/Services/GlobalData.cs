using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFCreative.Repositories;

namespace XFCreative.Services
{
    public class GlobalData
    {
        public static string 執行篩選資料 = "執行篩選資料";
        public static string DBName = "DoggyDB.db3";

        public static 創業空間Repository 創業空間Repository = new 創業空間Repository();
        public static 系統紀錄Repository 系統紀錄Repository = new 系統紀錄Repository();

    }
}
