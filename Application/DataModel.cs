using ApplicationNamespace.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationNamespace
{
    public class DataModel : IDataModel
    {
        public void WriteXMLFile(string fullFilePath, int count, FrequencyEnum frequency)
        {
            RandomDataGenerator generator = new RandomDataGenerator();

            using (StreamWriter file = new StreamWriter(fullFilePath))
            {
                using (XMLFileReaderWriter rw = new XMLFileReaderWriter(file))
                {
                    foreach (var item in generator.YieldRandomData(count, frequency))
                        rw.Write(item);
                }
            }
        }

        public IEnumerable<Data> ReadXMLFile(string fullFilePath)
        {
            using (StreamReader reader = new StreamReader(fullFilePath))
            {
                using (XMLFileReaderWriter rw = new XMLFileReaderWriter(reader))
                {
                    foreach (var item in rw.Read())
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}