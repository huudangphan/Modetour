using System.Xml.Serialization;

namespace ModeTour.Entities.Air
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
