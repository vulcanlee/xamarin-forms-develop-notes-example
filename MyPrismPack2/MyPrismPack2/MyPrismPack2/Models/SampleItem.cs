using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyPrismPack2.Models
{
    public class SampleItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        private DateTime showDate;
        public DateTime ShowDate
        {
            get { return showDate; }
            set
            {
                showDate = value;
                if (showDate.Date == DateTime.Now.Date)
                {
                    DateDetail = "就在今日";
                }
                else if (showDate.Date == DateTime.Now.Date.AddDays(+1))
                {
                    DateDetail = "明天";
                }
                else if (showDate.Date == DateTime.Now.Date.AddDays(+2))
                {
                    DateDetail = "就快到了";
                }
                else
                {
                    DateDetail = showDate.ToString("yyyy-MM-dd");
                }
            }
        }
        public string DateDetail { get; set; }

        // 建立目前 SampleItem 的淺層複製
        public SampleItem Clone() => (SampleItem)this.MemberwiseClone();
    }
}
