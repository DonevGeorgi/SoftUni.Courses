using CarDealer.DTOs.Export;
using System.Xml.Serialization;

[XmlType("sale")]
public class ExportSalesWhitDiscount
{
    [XmlElement("car")]
    public ExportCarsWhitParts Car { get; set; } = null!;

    [XmlElement("discount")]
    public decimal Discount { get; set; }

    [XmlElement("customer-name")]
    public string CustomerName { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("price-with-discount")]
    public decimal PriceWithDiscount
    {
        get
        {
            if (IsYoungDriver)
            {
                return Price;
            }
            return Price - (Price * Discount / 100);
        }
        set { }
    }

    [XmlIgnore]
    public bool IsYoungDriver { get; set; }

}