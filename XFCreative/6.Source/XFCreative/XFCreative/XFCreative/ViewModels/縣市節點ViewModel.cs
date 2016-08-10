using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.Models
{
    public class 縣市節點ViewModel : BindableBase
    {
        #region 縣市
        private string _縣市;
        public string 縣市
        {
            get { return _縣市; }
            set { SetProperty(ref _縣市, value); }
        }
        #endregion
    }


}
