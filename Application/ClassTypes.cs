using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationNamespace
{
public enum FrequencyEnum
    {
        PerSecond,
        PerMinute,
        PerHour,
        PerDay
    }

    public class Constants
    {
        public const string DefaultStartDate = "DefaultStartDate";
        public const string DefaultFrequency = "DefaultFrequency";
    }
}
