﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("part")]
    public class ExportPartsForCars
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
