using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }
        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"^[A-Z0-9]{4}\-[A-Z0-9]{4}\-[A-Z0-9]{4}$")]
        public string ProductKey { get; set; }
        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
        [Required]
        [XmlElement("Card")]
        public string Card { get; set; }
        [Required]
        [XmlAttribute("title")]
        public string Game { get; set; }
    }
}
