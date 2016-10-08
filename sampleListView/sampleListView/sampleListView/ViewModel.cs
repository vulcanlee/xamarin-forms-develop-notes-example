using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleListView
{

    public class ViewModel
    {
        public ObservableCollection<someDataClass> MyItemList { get; set; }

        public ViewModel()
        {
            MyItemList = new ObservableCollection<someDataClass>()
            {
                new someDataClass { sometext="sometext1", othertext="othertext1" },
                new someDataClass { sometext="sometext2", othertext="othertext2" },
                new someDataClass { sometext="sometext3", othertext="othertext3" },
                new someDataClass { sometext="sometext4", othertext="othertext4" },
            };
        }
    }

    public class someDataClass
    {
        public string sometext { get; set; }
        public string othertext { get; set; }
    }
}
