using System.Xml.Serialization;

namespace ModeTour.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "ResponseDetails")]
    public class CheckSelectFareRSModel
    {
        [XmlElement(ElementName = "fareComparison")]
        [XmlText]
        public string FareComparison { get; set; }
    }
}
