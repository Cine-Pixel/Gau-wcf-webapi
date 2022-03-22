using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EduClientApp.Classes
{
    public static class HelpMethods
    {
        public static T Deserialize<T>(string xml) where T: new()
        {
            T result;
            var xmlSerializer = new XmlSerializer(typeof(T));
            //DataContractSerializer ser = new DataContractSerializer(typeof(T));

            using (TextReader textReader = new StringReader(xml)) { 
            //using (Stream stream = new MemoryStream()) {

                //byte[] data = Encoding.UTF8.GetBytes(xml);
                //stream.Write(data, 0, data.Length);
                //stream.Position = 0;

                result = (T)xmlSerializer.Deserialize(textReader);
                //result = (T)ser.ReadObject(stream);
            }
            return result;
        }

        public static XmlDocument SerializeToXml<T>(T source)
        {
            var document = new XmlDocument { XmlResolver = null };
            var navigator = document.CreateNavigator();
            using (var writer = navigator.AppendChild())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, source);
            }
            return document;
        }
    }
}
