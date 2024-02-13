using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportClientsAddressesDto
    {
        [Required]
        [XmlElement("StreetName")]
        [MinLength(10)]
        [MaxLength(20)]
        public string StreetName { get; set; }
        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }
        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [XmlElement("City")]
        public string City { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [XmlElement("Country")]
        public string Country { get; set; }
    }
}
