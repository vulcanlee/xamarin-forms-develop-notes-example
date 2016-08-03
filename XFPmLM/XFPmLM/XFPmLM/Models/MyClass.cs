using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFPmLM.Models
{
    public class MyClass : IMyClass
    {
        public string Value { get; set; } = "這是預設值";

        public string GetValue()
        {
            return Value;
        }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}
