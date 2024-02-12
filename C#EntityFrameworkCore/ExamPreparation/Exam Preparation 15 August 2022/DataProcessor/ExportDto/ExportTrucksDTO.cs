using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportTrucksDTO
    {
        [Required]
        [StringLength(8)]
        [RegularExpression(@"[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string RegistrationNumber { get; set; }
        [Required]
        [StringLength(17)]
        public string VinNumber { get; set; }
        [Required]
        [Range(950,1420)]
        public int TankCapacity { get; set; }
        [Required]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }
        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }
        [Required]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}
