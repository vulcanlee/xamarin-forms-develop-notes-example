using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.Models
{
    public class 系統紀錄
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string 篩選城市 { get; set; }
    }


}
