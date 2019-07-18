using System.IO;
using System.Xml.Serialization;

namespace FileManager.Helpers
{
    internal class XmlHelper<AnyType>
    {
        string FilePath;
        AnyType myMethod(AnyType Type)
        {
            return Type;
        }

        XmlSerializer Serializer;

        internal XmlHelper(string Path)
        {
            FilePath = Path;
            Serializer = new XmlSerializer(typeof(AnyType));
        }

        internal void WriteFile(AnyType notes)
        {
            File.WriteAllText(FilePath, "");
            using (var writer = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                Serializer.Serialize(writer, notes);
            }
        }

        internal bool ReadFile(ref AnyType notes)
        {
            using (var reader = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                notes = (AnyType)Serializer.Deserialize(reader);
            }
            return true;
        }
    }
}
