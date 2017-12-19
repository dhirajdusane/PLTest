using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationNamespace
{
    [Serializable]
    public class Data 
    {
        public DateTime TickValue { get; set; }
        public int RandomValue { get; set; }

        public override string ToString()
        {
            return TickValue.ToString() + "," + RandomValue.ToString();
        }
    }
}
