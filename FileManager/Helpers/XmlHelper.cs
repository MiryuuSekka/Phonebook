using System.IO;
using System.Xml.Serialization;

namespace FileManager.Helpers
{
    internal class XmlHelper<AnyType>
    {
        AnyType myMethod(AnyType Type)
        {
            return Type;
        }

        XmlSerializer _serializer;

        internal XmlHelper()
        {
            _serializer = new XmlSerializer(typeof(AnyType));
        }

        internal void WriteFile(AnyType notes)
        {
            using (var writer = new FileStream("Note.xml", FileMode.OpenOrCreate))
            {
                _serializer.Serialize(writer, notes);
            }
        }

        internal bool ReadFile(ref AnyType notes)
        {
            using (var reader = new FileStream("Note.xml", FileMode.Open))
            {
                try
                {
                    notes = (AnyType)_serializer.Deserialize(reader);
                }
                catch (FileNotFoundException)
                {
                    return false; 
                }
            }
            return true;
        }
    }
}
