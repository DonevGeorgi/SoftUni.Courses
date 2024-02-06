using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Users")]
public class ExportUsersWithCount
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUserWhitAge[] Users { get; set; } = null!;
}