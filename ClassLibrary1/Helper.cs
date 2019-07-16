using System.IO;
using System.Xml.Serialization;

namespace BLL
{
    internal class Helper<AnyType>
    {
        private AnyType myMethod(AnyType a)
        {
            return a;
        }

        internal void XmlSerialization( AnyType PersonList)
        {
            var formatter = new XmlSerializer(typeof(AnyType));
            using (var fs = new FileStream(@"E:\prog\sample\EpamTest1\Notebook.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, PersonList);
            }
        }

        internal AnyType XmlDeserialization()
        {
            var formatter = new XmlSerializer(typeof(AnyType));
            using (var fs = new FileStream(@"E:\prog\sample\EpamTest1\Notebook.xml", FileMode.OpenOrCreate))
            {
                return (AnyType)formatter.Deserialize(fs);

            }
        }

    }
}
