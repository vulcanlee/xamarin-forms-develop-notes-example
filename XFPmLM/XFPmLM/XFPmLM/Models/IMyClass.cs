using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFPmLM.Models
{
    public interface IMyClass
    {
        string Value { get; set; }
        string GetValue();

        void SetValue(string value);
    }
}
