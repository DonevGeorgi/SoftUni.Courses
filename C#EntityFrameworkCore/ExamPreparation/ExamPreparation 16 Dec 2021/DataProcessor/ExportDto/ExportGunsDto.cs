﻿using Artillery.Data.Models.Enums;
using Artillery.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Guns")]
    public class ExportGunsDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }
        [XmlAttribute("GunType")]
        public string GunType { get; set; }
        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }
        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }
        [XmlAttribute("Range")]
        public int Range { get; set; }
        [XmlArray("Countries")]
        public ExportCountryGunDto[] Countries { get; set; }
    }
}