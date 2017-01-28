using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTrigger
{
    /// <summary>
    /// 定義Trigger條件滿足時候，要執行使用者自訂的動作
    /// </summary>
    class NumericValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry entry)
        {
            //請在這裡定義使用者要執行的動作
            double result;
            bool isValid = Double.TryParse(entry.Text, out result);
            entry.TextColor = isValid ? Color.Default : Color.Red;
            entry.Scale = 1.4;
        }
    }
}
