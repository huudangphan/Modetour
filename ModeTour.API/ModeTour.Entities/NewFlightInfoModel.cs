using System.Xml.Serialization;

namespace ModeTour.Entity
{
    [XmlRoot(ElementName = "flightInfo")]
    public class NewFlightInfoModel
    {
        [XmlAttribute(AttributeName = "ptc")]
        public String PTC { get; set; }

        [XmlAttribute(AttributeName = "rot")]
        public String ROT { get; set; }

        [XmlAttribute(AttributeName = "opn")]
        public String OPN { get; set; }

        [XmlElement(ElementName = "segGroup")]
        public List<NewSegGroupModel> SegGroup { get; set; }
    }
    [XmlType("itinerary")]
    public class ItineraryModel
    {
        [XmlElement(ElementName = "segGroup")]
        public List<NewSegGroupModel> SegGroup { get; set; }
    }
    [XmlType("segGroup")]
    public class NewSegGroupModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public String REF { get; set; }

        /// <summary>
        /// 총 여정시간  Total travel time
        /// </summary>
        [XmlAttribute(AttributeName = "ejt")]
        public String EJT { get; set; }

        /// <summary>
        /// 총 비행시간   toltal flight time

        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public String EFT { get; set; }

        /// <summary>
        /// 총 대기시간 total time wait
        /// </summary>
        [XmlAttribute(AttributeName = "ewt")]
        public String EWT { get; set; }

        /// <summary>
        /// 대표 항공사코드 Airline code
        /// </summary>
        [XmlAttribute(AttributeName = "mjc")]
        public String MJC { get; set; }

        /// <summary>
        /// 공동운항 여부 is share information?
        /// </summary>
        [XmlAttribute(AttributeName = "cds")]
        public String CDS { get; set; }

        /// <summary>
        /// 경유수  
        /// </summary>
        private Int16 nosp = 0;
        [XmlAttribute(AttributeName = "nosp")]
        public Int16 NOSP
        {
            get { return this.nosp; }
            set { this.nosp = value; }
        }

        /// <summary> 
        /// 그룹 여정정보(출발공항/도착공항/출발일시/도착일시/총소요시간/대표항공사/경유수/기착수/공동운항여부)  information of group's itinerary
        /// </summary>
        [XmlAttribute(AttributeName = "iti")]
        public String ITI { get; set; }

        /// <summary>
        /// 여정 정보(*표시는 기착지 ex) ICN/*TPE/BKK )   information of itinerary
        /// </summary>
        [XmlAttribute(AttributeName = "rtg")]
        public String RTG { get; set; }

        /// <summary>
        /// aif
        /// </summary>
        [XmlAttribute(AttributeName = "aif")]
        public String GroupAIF { get; set; }

        /// <summary>
        /// 여정번호 itinerary no
        /// </summary>
        [XmlAttribute(AttributeName = "fiRef")]
        public String FiRef { get; set; }

        [XmlElement(ElementName = "seg")]
        public List<NewSegModel> Seg { get; set; }
    }
    [XmlType("seg")]
    public class NewSegModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public String REF { get; set; }

        /// <summary>
        /// 출발지 공항코드  departure airport code
        /// </summary>
        [XmlAttribute(AttributeName = "dlc")]
        public String DLC { get; set; }

        /// <summary>
        /// 도착지 공항코드 destination airport code
        /// </summary>
        [XmlAttribute(AttributeName = "alc")]
        public String ALC { get; set; }

        /// <summary>
        /// 출발일시  start date
        /// </summary>
        [XmlAttribute(AttributeName = "ddt")]
        public String DDT { get; set; }

        /// <summary>
        /// 도착일시 to
        /// </summary>
        [XmlAttribute(AttributeName = "ardt")]
        public String ARDT { get; set; }

        /// <summary>
        /// 비행시간 time flight
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public String EFT { get; set; }

        /// <summary>
        /// 대기시간 time wait
        /// </summary>
        [XmlAttribute(AttributeName = "ett")]
        public String ETT { get; set; }

        /// <summary>
        /// 기착시간 time to stop
        /// </summary>
        [XmlAttribute(AttributeName = "gwt")]
        public String GWT { get; set; }

        /// <summary>
        /// 마케팅 항공사코드  airline code marketing
        /// </summary>
        [XmlAttribute(AttributeName = "mcc")]
        public String MCC { get; set; }

        /// <summary>
        /// 운항 항공사코드 airline code active
        /// </summary>
        [XmlAttribute(AttributeName = "occ")]
        public String OCC { get; set; }

        /// <summary>
        /// 공동운항 여부 is share information
        /// </summary>
        [XmlAttribute(AttributeName = "cds")]
        public String CDS { get; set; }

        /// <summary>
        /// 편명  flight number
        /// </summary>
        [XmlAttribute(AttributeName = "fln")]
        public String FLN { get; set; }

        /// <summary>
        /// 기종  perforated lung air
        /// </summary>
        [XmlAttribute(AttributeName = "eqt")]
        public String EQT { get; set; }

        /// <summary>
        /// 경유 수(기착) number of stop
        /// </summary>
        [XmlAttribute(AttributeName = "stn")]
        public String STN { get; set; }

        /// <summary>
        /// 이티켓 발행 가능 여부 is possible e-ticket
        /// </summary>
        [XmlAttribute(AttributeName = "etc")]
        public String ETC { get; set; }

        /// <summary>
        /// aif
        /// </summary>
        [XmlAttribute(AttributeName = "aif")]
        public String AIF { get; set; }

        /// <summary>
        /// 기착 정보 stopover information
        /// </summary>
        [XmlElement(ElementName = "seg")]
        public List<StopOverModel> StopOver { get; set; }
    }
}
