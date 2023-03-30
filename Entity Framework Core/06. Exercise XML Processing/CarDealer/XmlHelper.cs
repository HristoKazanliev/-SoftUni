using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer= new XmlSerializer(typeof(T), xmlRoot);

            using StringReader xmlString = new StringReader(inputXml);
            T deserializedDtos = (T)xmlSerializer.Deserialize(xmlString);

            return deserializedDtos;
        }

        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

            using StringReader xmlString = new StringReader(inputXml);
            T[] deserializedDtos = (T[])xmlSerializer.Deserialize(xmlString);

            return deserializedDtos;
        }
    }
}
