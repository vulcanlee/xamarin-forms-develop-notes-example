using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.Models
{
    public class 網頁資料NodeViewModel : BindableBase
    {
        #region 標題名稱
        private string _標題名稱;
        public string 標題名稱
        {
            get { return _標題名稱; }
            set { SetProperty(ref _標題名稱, value); }
        }
        #endregion

        #region 網頁內容
        private string _網頁內容;

        public string 網頁內容
        {
            get { return _網頁內容; }
            set { SetProperty(ref _網頁內容, value); }
        }
        #endregion

    }


}
