using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [XmlElement("PhoneNumber")]
        [StringLength(14)]
        public string PhoneNumber { get; set; }
        [Required]
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; }
        [XmlArray("Medicines")]
        public ImportPharmacyMedicineDto[] Medicine { get; set; }
    }
}
