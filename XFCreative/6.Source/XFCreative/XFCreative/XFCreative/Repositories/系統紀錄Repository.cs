using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFCreative.Models;

namespace XFCreative.Repositories
{
    public class 系統紀錄Repository
    {
        public SQLRepository<系統紀錄> 資料表 { get; set; } = new SQLRepository<Models.系統紀錄>();


    }
}
