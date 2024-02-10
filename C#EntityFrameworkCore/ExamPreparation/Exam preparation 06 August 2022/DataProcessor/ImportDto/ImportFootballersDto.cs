﻿using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballersDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }
        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }
        [Required]
        [XmlElement("BestSkillType")]
        public int PositionType { get; set; }
        [Required]
        [XmlElement("PositionType")]
        public int BestSkillType { get; set; }
    }
}
