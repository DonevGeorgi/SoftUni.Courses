using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("Purchase")]
    public class ExportPurchasesDto
    {
        [XmlElement("Card")]
        public string CardNumber {  get; set; }
        [XmlElement("Cvc")]
        public string Cvc {  get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
        [XmlElement("Game")]
        public ExportGamesDto Games { get; set; }
    }
}
