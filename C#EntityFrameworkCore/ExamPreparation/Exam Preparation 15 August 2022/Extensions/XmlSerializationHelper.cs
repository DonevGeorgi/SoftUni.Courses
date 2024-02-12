using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Trucks.Extensions
{
    public class XmlSerializationHelper
    {
        public static T Deserialize<T>(string inputXml, string rootName)
        {
            if (string.IsNullOrEmpty(inputXml))
                throw new ArgumentException("Input XML connot be null or empty", nameof(inputXml));

            if(string.IsNullOrEmpty(rootName))
                throw new ArgumentException("Root name connot be null or empty",nameof(rootName));

            try
            {
                XmlRootAttribute xmlRoot = new(rootName);
                XmlSerializer xmlSerializer = new(typeof(T),xmlRoot);

                using var reader = new StringReader(inputXml);
                return (T)xmlSerializer.Deserialize(reader);
            }
            catch(XmlException ex)
            {
                Debug.WriteLine(ex);
                throw new InvalidOperationException("XML deserialization failed", ex);
            }
            catch(InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                throw new InvalidOperationException($"{typeof(T)} deserialization failed", ex);
            }
        }

        public static string Serialize<T>(T obj,string rootName,bool omitXmlDeclaration = false)
        {
            if(obj == null)
                throw new ArgumentNullException(nameof(obj), "Object to serialize cannot be null.");
            
            if(string.IsNullOrEmpty(rootName))
                throw new ArgumentNullException(nameof(rootName),"Root name cannot be null or empty.");

            try
            {
                XmlRootAttribute xmlRoot = new(rootName);
                XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

                XmlSerializerNamespaces namespaces = new();
                namespaces.Add(string.Empty, string.Empty);

                XmlWriterSettings settings = new()
                {
                    OmitXmlDeclaration = omitXmlDeclaration,
                    Indent = true,
                };

                StringBuilder sb = new();
                using var stringWrite = new StringWriter(sb);
                using var xmlWriter = XmlWriter.Create(stringWrite, settings);

                xmlSerializer.Serialize(xmlWriter, obj, namespaces);
                return sb.ToString().TrimEnd();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Serialization error: {ex.Message}");
                throw new InvalidOperationException($"Serializing {typeof(T)} failed.",ex);
            }
        }
    }
}
