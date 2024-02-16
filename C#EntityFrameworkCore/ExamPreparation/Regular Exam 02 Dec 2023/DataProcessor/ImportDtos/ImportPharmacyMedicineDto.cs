﻿using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportPharmacyMedicineDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0.01,1000.00)]
        [XmlElement("Price")]
        public decimal Price { get; set; }
        [Required]
        [XmlAttribute("category")]
        public int Category { get; set; }
        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; }
        [Required]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; }
        [Required]
        [XmlElement("Producer")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; }
    }
}
