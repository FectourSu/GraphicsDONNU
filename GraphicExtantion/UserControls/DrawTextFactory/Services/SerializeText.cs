using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp1.GraphicExtantion.UserControls.DrawTextClass.Services
{
    class SerializeText
    {
        public SerializeText(string path)
        {
            this.Path = path;
        }

        public string Path { get; }

        public void Serialize<T>(T serializeObject)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, serializeObject);
            }
        }

        public T Deserialize<T>()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            T result;

            using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                return result = (T)xmlSerializer.Deserialize(fileStream);
            }
        }
    }
}
