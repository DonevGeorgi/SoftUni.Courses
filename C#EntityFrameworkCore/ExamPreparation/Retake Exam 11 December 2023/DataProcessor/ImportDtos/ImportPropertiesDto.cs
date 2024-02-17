﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportPropertiesDto
    {
        [Required]
        [MinLength(16)]
        [MaxLength(20)]
        public string PropertyIdentifier { get; set; }
        [Required]
        [Range(0,1000000)]
        public int Area { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Details { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        public string DateOfAcquisition { get; set; }
    }
}
