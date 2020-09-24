using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataTools
{
    public static class ObjectExtensions
    {

        //  Every Class that implements this extension must have the Serializable attribute on the class
        //  E.g.
        //  [Serializable]
        //  public class Person
        //  {...}
        public static T DeepCopy<T>(this T self)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                //start at the beginning of the stream
                stream.Seek(0, SeekOrigin.Begin);

                object copy = formatter.Deserialize(stream);

                return (T)copy;
            }
        }


        //  Every Class requires an empty constructor for this to work correctly
        public static T DeepCopyXml<T>(this T self)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, self);
                //start at the beginning of the stream
                stream.Seek(0, SeekOrigin.Begin);

                object copy = formatter.Deserialize(stream);

                return (T)copy;
            }
        }
    }
}
