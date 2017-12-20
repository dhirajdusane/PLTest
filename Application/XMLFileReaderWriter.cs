using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ApplicationNamespace
{
    public class XMLFileReaderWriter : IDisposable
    {
        private XmlWriter writer;
        private XmlReader reader;
        private XmlSerializer serializer;
        private XmlSerializerNamespaces namespaces;

        private XMLFileReaderWriter()
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer = new XmlSerializer(typeof(Data));
        }

        public XMLFileReaderWriter(TextReader target) : this()
        {
            reader = XmlReader.Create(target);
        }

        public XMLFileReaderWriter(TextWriter target) : this()
        {
            writer = XmlWriter.Create(target);
            writer.WriteStartElement("TickData");
        }

        public void Write(Data data)
        {
            data.StringData = data.ToString();
            serializer.Serialize(writer, data, namespaces);
        }

        public IEnumerable<Data> Read()
        {
            if (!reader.IsStartElement("TickData"))
            {
                yield break;
            }

            reader.Read();

            while (reader.MoveToContent() == XmlNodeType.Element)
            {
                object o = serializer.Deserialize(reader);
                yield return o as Data;
            }
        }

        public void Dispose()
        {
            if (writer != null)
            {
                writer.WriteEndElement();
                writer.Dispose();
            }

            if (reader != null)
                reader.ReadEndElement();
        }
    }

    [Serializable]    
    public class dataClass
    {
        [XmlElement("data")]
        public string dataElement { get; set; }
    }
}
