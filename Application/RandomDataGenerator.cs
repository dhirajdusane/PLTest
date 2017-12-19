using ApplicationNamespace.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationNamespace
{
    public class RandomDataGenerator : IDataGenerator
    {
        public FrequencyEnum GetDefaultFrequency()
        {
            FrequencyEnum enumValue = FrequencyEnum.PerMinute;
            Enum.TryParse<FrequencyEnum>(ConfigurationManager.AppSettings[Constants.DefaultStartDate], out enumValue);
            return enumValue;
        }

        public IEnumerable<Data> GetRandomDataList(int recordCount, FrequencyEnum frequency)
        {
            return YieldRandomData(recordCount, frequency).ToList();
        }

        public IEnumerable<Data> YieldRandomData(int recordCount, FrequencyEnum frequency)
        {
            Random rand = new Random();

            DateTime startData = new DateTime(2000,01,01);
            DateTime.TryParse(ConfigurationManager.AppSettings[Constants.DefaultStartDate], out startData);
            Func<DateTime, DateTime> increment = null;

            switch (frequency)
            {
                case FrequencyEnum.PerSecond:
                    increment = (date) =>
                    {
                        return date.AddSeconds(1);
                    };
                    break;
                case FrequencyEnum.PerMinute:
                    increment = (date) =>
                    {
                        return date.AddMinutes(1);
                    };
                    break;
                case FrequencyEnum.PerHour:
                    increment = (date) =>
                    {
                        return date.AddHours(1);
                    };
                    break;
                case FrequencyEnum.PerDay:
                    increment = (date) =>
                    {
                        return date.AddDays(1);
                    };
                    break;
            }

            DateTime loopDate = startData;
            for (int i = 0; i < recordCount; i++)
            {
                loopDate = increment(loopDate);
                yield return new Data() { TickValue = loopDate, RandomValue = rand.Next(0, 1000) };
            }
        }
    }
}
