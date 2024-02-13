﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [Required]
        [XmlElement("Title")]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }
        [Required]
        [Range(0.00,10.00)]
        [XmlElement("Rating")]
        public float Rating { get; set; }
        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [Required]
        [XmlElement("Description")]
        [MaxLength(700)]
        public string Description { get; set; }
        [Required]
        [XmlElement("Screenwriter")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }
}