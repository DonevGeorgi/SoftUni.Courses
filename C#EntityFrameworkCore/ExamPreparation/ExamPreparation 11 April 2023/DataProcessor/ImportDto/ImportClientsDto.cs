using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientsDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(10)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [XmlElement("NumberVat")]
        [MinLength(10)]
        [MaxLength(15)]
        public string NumberVat { get; set; }
        [XmlArray("Addresses")]
        public ImportClientsAddressesDto[] Addresses { get; set; }
    }
}
