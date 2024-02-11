using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    public class ExportGamesDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
