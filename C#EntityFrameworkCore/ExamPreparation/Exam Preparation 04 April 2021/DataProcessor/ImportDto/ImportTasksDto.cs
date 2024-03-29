﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTasksDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }
        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }
        [Required]
        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }
        [Required]
        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
}
