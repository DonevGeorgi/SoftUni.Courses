﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }
        [XmlElement("DueDate")]
        public string? DueDate { get; set; }
        [XmlArray("Tasks")]
        public ImportTasksDto[] Tasks {get;set;}
    }
}
