using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictsDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [XmlElement("PostalCode")]
        [StringLength(8)]
        [RegularExpression(@"^[A-Z]{2}\-\d{5}$")]
        public string PostalCode { get; set; }
        [Required]
        [XmlAttribute("Region")]
        public string Region { set; get; }
        [XmlArray("Properties")]
        public ImportPropertiesDto[] Properties { get; set; }
    }
}
