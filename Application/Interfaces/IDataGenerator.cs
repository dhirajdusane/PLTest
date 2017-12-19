using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationNamespace.Interfaces
{
    public interface IDataGenerator
    {
        IEnumerable<Data> YieldRandomData(int recordCount, FrequencyEnum frequency);
        IEnumerable<Data> GetRandomDataList(int recordCount, FrequencyEnum frequency);
    }
}
