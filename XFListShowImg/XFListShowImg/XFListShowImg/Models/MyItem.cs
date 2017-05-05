using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFListShowImg.Models
{

    [ImplementPropertyChanged]
    public class MyItem
    {
        public int Number { get; set; }
        public Color BoxColor { get; set; }
        public string ImageUrl { get; set; }
        public bool ShowImage { get; set; }
    }
}
