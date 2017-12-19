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

            serializer = new XmlSerializer(typeof(string));
        }

        public XMLFileReaderWriter(TextReader target) : this()
        {
            reader = XmlReader.Create(target);
            //reader.ReadStartElement();
        }

        public XMLFileReaderWriter(TextWriter target) : this()
        {
            writer = XmlWriter.Create(target);
            writer.WriteStartElement("BillingFile");
        }

        public void Write(Data data)
        {
            //if (_disposed) throw new ObjectDisposedException("AccountWriter");
            //
            //if (!_wroteHeader)
            //{
            //    _writer.WriteStartElement("BillingFile");
            //    _wroteHeader = true;
            //}

            serializer.Serialize(writer, data.ToString(), namespaces);
        }

        public IEnumerable<string> Read()
        {
            if (!reader.IsStartElement("BillingFile"))
            {
                yield break;
            }

            reader.Read();

            while (reader.MoveToContent() == XmlNodeType.Element)
            {
                object o = serializer.Deserialize(reader);
                yield return "";
            }

            //reader.Read();
            //while (reader.MoveToContent() == XmlNodeType.Text)
            //{
            //    object obj = serializer.Deserialize(reader);
            //}
        }

        public void Dispose()
        {
            if (writer != null)
                writer.WriteEndElement();

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
