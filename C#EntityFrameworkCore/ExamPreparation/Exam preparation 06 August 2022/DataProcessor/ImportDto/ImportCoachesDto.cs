using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachesDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("Nationality")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }
        [Required]
        [XmlArray("Footballers")]
        public ImportFootballersDto[] Footballers { get; set; }
    }
}