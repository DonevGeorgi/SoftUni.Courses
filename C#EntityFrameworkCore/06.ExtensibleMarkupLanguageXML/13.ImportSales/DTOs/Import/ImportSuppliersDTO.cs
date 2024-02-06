using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Supplier")]
    public class ImportSuppliersDTO
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }

    }
}
