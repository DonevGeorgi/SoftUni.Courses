using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("partId")]
public class ImportCarPartDTO
{
    [XmlAttribute("id")]
    public int PartyId { get; set; }
}