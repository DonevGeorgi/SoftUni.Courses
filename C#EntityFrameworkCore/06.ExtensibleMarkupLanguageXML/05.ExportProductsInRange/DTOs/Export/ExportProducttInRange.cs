﻿using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class ExportProducttInRange
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("buyer")]
        public string? BuyerName { get; set; }

        public bool ShouldSerializebuyer()
            => !string.IsNullOrEmpty(BuyerName);
    }
}
