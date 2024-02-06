using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class ExportedSoldProducts
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlElement("soldProducts")]
        public ExportProductNamePrice[] ProductSold { get; set; } = null!;
    }
}
