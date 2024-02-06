using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Sale")]
    public class ImportSalesDTO
    {
        [XmlElement("carId")]
        public decimal Discount { get; set; }
        [XmlElement("customerId")]
        public int CarId { get; set; }
        [XmlElement("discount")]
        public int CustomerId { get; set; }
    }
}
