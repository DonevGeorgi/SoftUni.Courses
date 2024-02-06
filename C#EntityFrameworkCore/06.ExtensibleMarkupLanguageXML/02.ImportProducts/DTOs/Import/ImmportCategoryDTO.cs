using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("Category")]
    public class ImmportCategoryDTO
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;
    }
}
