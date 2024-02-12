using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDto
    {
        [XmlAttribute("TrucksCount")]
        public int TruckCount {  get; set; }

        [XmlElement("DespatcherName")]
        public string Name { get; set; }
        [XmlArray("Trucks")]
        public ImportTrucksDto[] Trucks { get; set; }
    }
}
