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
            //XmlSerializer xml = new XmlSerializer(typeof(List<string>), new Type[] { typeof(string) });
            //
            RandomDataGenerator generator = new RandomDataGenerator();
            ////StringBuilder builder = new StringBuilder();
            using (StreamWriter file = new StreamWriter(fullFilePath))
            using (XMLFileReaderWriter rw = new XMLFileReaderWriter(file))
            {
                {

                    foreach (var item in generator.YieldRandomData(count, frequency))
                        rw.Write(item);
                    //    {
                    //        xml.Serialize(file, generator.YieldRandomString(count, frequency).ToList());// builder.Append(item.TickValue)
                    //    }
                }
            }
            using (StreamReader reader = new StreamReader(fullFilePath))
            {
                XMLFileReaderWriter rw = new XMLFileReaderWriter(reader);
                foreach (var item in rw.Read())
                {

                }
            }
        }
    }
}
