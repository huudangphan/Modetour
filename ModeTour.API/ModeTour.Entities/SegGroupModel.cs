using System.Xml.Serialization;

namespace ModeTour.Entity
{
    [XmlType("segGroup")]
    public class SegGroupModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public Int16 REF { get; set; }

        /// <summary>
        /// 여정 갯수
        /// </summary>
        [XmlAttribute(AttributeName = "nosp")]
        public Int16 NOSP { get; set; }

        /// <summary>
        /// 공동운항 여부
        /// </summary>
        [XmlAttribute(AttributeName = "cds")]
        public String CDS { get; set; }

        /// <summary>
        /// 대표 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "mjc")]
        public String MJC { get; set; }

        /// <summary>
        /// 총 여정시간
        /// </summary>
        [XmlAttribute(AttributeName = "jrt")]
        public String JRT { get; set; }

        /// <summary>
        /// 총 여정시간 
        /// </summary>
        [XmlAttribute(AttributeName = "ejt")]
        public String EJT { get; set; }

        /// <summary>
        /// 총 대기시간
        /// </summary>
        [XmlAttribute(AttributeName = "ewt")]
        public String EWT { get; set; }

        /// <summary>
        /// 총 비행시간
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public String EFT { get; set; }

        /// <summary>
        /// aif
        /// </summary>
        [XmlAttribute(AttributeName = "aif")]
        public String GroupAIF { get; set; }

        [XmlElement(ElementName = "seg")]
        public List<SegModel> Seg { get; set; }
    }
    public class SegModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public String REF { get; set; }

        /// <summary>
        /// 비행시간
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public String EFT { get; set; }


        [XmlAttribute(AttributeName = "ewt")]
        public String EWT { get; set; }

        /// <summary>
        /// 대기시간
        /// </summary>
        [XmlAttribute(AttributeName = "ett")]
        public String ETT { get; set; }

        [XmlAttribute(AttributeName = "gwt")]
        public String GWT { get; set; }

        [XmlAttribute(AttributeName = "rbd")]
        public String RBD { get; set; }

        [XmlAttribute(AttributeName = "pnr")]
        public String PNR { get; set; }

        /// <summary>
        /// 이티켓 발행 가능 여부
        /// </summary>
        [XmlAttribute(AttributeName = "etc")]
        public String ETC { get; set; }

        /// <summary>
        /// 경유 수(기착)
        /// </summary>
        [XmlAttribute(AttributeName = "stn")]
        public String STN { get; set; }

        /// <summary>
        /// 기종
        /// </summary>
        [XmlAttribute(AttributeName = "eqt")]
        public String EQT { get; set; }

        /// <summary>
        /// 편명
        /// </summary>
        [XmlAttribute(AttributeName = "fln")]
        public String FLN { get; set; }

        [XmlAttribute(AttributeName = "occn")]
        public String OCCN { get; set; }

        /// <summary>
        /// 운항 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "occ")]
        public String OCC { get; set; }

        [XmlAttribute(AttributeName = "mccn")]
        public String MCCN { get; set; }

        /// <summary>
        /// 마케팅 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "mcc")]
        public String MCC { get; set; }

        /// <summary>
        /// 도착일시
        /// </summary>
        [XmlAttribute(AttributeName = "ardt")]
        public String ARDT { get; set; }

        /// <summary>
        /// 출발일시
        /// </summary>
        [XmlAttribute(AttributeName = "ddt")]
        public String DDT { get; set; }

        /// <summary>
        /// 도착도시명
        /// </summary>
        [XmlAttribute(AttributeName = "accn")]
        public String ACCN { get; set; }

        /// <summary>
        /// 도착공항명
        /// </summary>
        [XmlAttribute(AttributeName = "alcn")]
        public String ALCN { get; set; }

        /// <summary>
        /// 도착지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "alc")]
        public String ALC { get; set; }

        /// <summary>
        /// 출발도시명
        /// </summary>
        [XmlAttribute(AttributeName = "dccn")]
        public String DCCN { get; set; }

        /// <summary>
        /// 출발공항명
        /// </summary>
        [XmlAttribute(AttributeName = "dlcn")]
        public String DLCN { get; set; }

        /// <summary>
        /// 출발지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "dlc")]
        public String DLC { get; set; }

        [XmlAttribute(AttributeName = "cabin")]
        public String Cabin { get; set; }

        /// <summary>
        /// aif
        /// </summary>
        [XmlAttribute(AttributeName = "aif")]
        public String AIF { get; set; }

        /// <summary>
        /// 여정 상태 코드(항공사코드)
        /// </summary>
        [XmlAttribute(AttributeName = "rsco")]
        public String RSCO { get; set; }

        /// <summary>
        /// 여정 상태 코드(통합코드)
        /// </summary>
        [XmlAttribute(AttributeName = "rsc")]
        public String RSC { get; set; }

        /// <summary>
        /// 도착지 터미널 정보
        /// </summary>
        [XmlAttribute(AttributeName = "atc")]
        public String ATC { get; set; }

        /// <summary>
        /// 출발지 터미널 정보
        /// </summary>
        [XmlAttribute(AttributeName = "dtc")]
        public String DTC { get; set; }

        /// <summary>
        /// 출발지 국가코드
        /// </summary>
        [XmlAttribute(AttributeName = "duc")]
        public String DUC { get; set; }

        /// <summary>
        /// 도착지국가코드
        /// </summary>
        [XmlAttribute(AttributeName = "auc")]
        public String AUC { get; set; }

        /// <summary>
        /// 기착 정보
        /// </summary>
        [XmlElement(ElementName = "seg")]
        public List<StopOverModel> StopOver { get; set; }
    }

    public class StopOverModel
    {
        /// <summary>
        /// 출발지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "dlc")]
        public String DLC { get; set; }

        /// <summary>
        /// 도착지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "alc")]
        public String ALC { get; set; }

        /// <summary>
        /// 출발일시(YYYY-MM-DD HH:MM)
        /// </summary>
        [XmlAttribute(AttributeName = "ddt")]
        public String DDT { get; set; }

        /// <summary>
        /// 도착일시(YYYY-MM-DD HH:MM)
        /// </summary>
        [XmlAttribute(AttributeName = "ardt")]
        public String ARDT { get; set; }

        /// <summary>
        /// 비행시간
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public String EFT { get; set; }

        /// <summary>
        /// 기착시간
        /// </summary>
        [XmlAttribute(AttributeName = "gwt")]
        public String GWT { get; set; }

    }
}
