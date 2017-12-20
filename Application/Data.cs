using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationNamespace
{
    [Serializable]
    public class Data 
    {
        private DateTime tickValue;
        [XmlIgnore]
        public DateTime TickValue
        {
            get { return tickValue; }
            set { tickValue = value; }
        }

        private int randomValue;
        [XmlIgnore]
        public int RandomValue
        {
            get { return randomValue; }
            set { randomValue = value; }
        }

        [XmlText]
        public string StringData
        {
            get { return this.ToString(); ; }
            set
            {
                string[] cols = value.Split(',');
                DateTime.TryParse(cols[0], out tickValue);
                int.TryParse(cols[1], out randomValue);
            }
        }
        
        public override string ToString()
        {
            return TickValue.ToString() + "," + RandomValue.ToString();
        }
    }
}
