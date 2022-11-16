using System.Xml.Serialization;

namespace ModeTour.Entities.Air
{
    [XmlRoot(ElementName = "flightInfo")]
    public class FlightInfoModel
    {
        [XmlAttribute(AttributeName = "ptc")]
        public String PTC { get; set; }

        [XmlAttribute(AttributeName = "rot")]
        public String ROT { get; set; }

        [XmlAttribute(AttributeName = "opn")]
        public String OPN { get; set; }

        [XmlElement(ElementName = "flightIndex")]
        public List<FlightIndexModel> FlightIndex { get; set; }
    }

    [XmlType("flightIndex")]
    public class FlightIndexModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public String REF { get; set; }

        [XmlAttribute(AttributeName = "ptc")]
        public String PTC { get; set; }

        [XmlElement(ElementName = "segGroup")]
        public List<SegGroupModel> SegGroup { get; set; }
    }

    [XmlType("itinerary")]
    public class ItinerarySegModel
    {
        [XmlElement(ElementName = "segGroup")]
        public List<SegGroupModel> SegGroup { get; set; }
    }
}
