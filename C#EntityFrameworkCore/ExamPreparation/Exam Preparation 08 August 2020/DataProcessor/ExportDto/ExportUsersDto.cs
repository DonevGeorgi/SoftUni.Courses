using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("User")]
    public class ExportUsersDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlArray("Purchases")]
        public ExportPurchasesDto[] Purchases { get; set; }
        [XmlElement("TotalSpent")]
        public decimal TotalSpend { get; set; }
    }
}
