using System.Xml.Serialization;

namespace ModeTour.Entities.Air
{
    [XmlType("segGroup")]
    public class SegGroupModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public short REF { get; set; }

        /// <summary>
        /// 여정 갯수
        /// </summary>
        [XmlAttribute(AttributeName = "nosp")]
        public short NOSP { get; set; }

        /// <summary>
        /// 공동운항 여부
        /// </summary>
        [XmlAttribute(AttributeName = "cds")]
        public string CDS { get; set; }

        /// <summary>
        /// 대표 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "mjc")]
        public string MJC { get; set; }

        /// <summary>
        /// 총 여정시간
        /// </summary>
        [XmlAttribute(AttributeName = "jrt")]
        public string JRT { get; set; }

        /// <summary>
        /// 총 여정시간 
        /// </summary>
        [XmlAttribute(AttributeName = "ejt")]
        public string EJT { get; set; }

        /// <summary>
        /// 총 대기시간
        /// </summary>
        [XmlAttribute(AttributeName = "ewt")]
        public string EWT { get; set; }

        /// <summary>
        /// 총 비행시간
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public string EFT { get; set; }

        /// <summary>
        /// aif
        /// </summary>
        [XmlAttribute(AttributeName = "aif")]
        public string GroupAIF { get; set; }

        [XmlElement(ElementName = "seg")]
        public List<SegModel> Seg { get; set; }
    }
    public class SegModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public string REF { get; set; }

        /// <summary>
        /// 비행시간
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public string EFT { get; set; }


        [XmlAttribute(AttributeName = "ewt")]
        public string EWT { get; set; }

        /// <summary>
        /// 대기시간
        /// </summary>
        [XmlAttribute(AttributeName = "ett")]
        public string ETT { get; set; }

        [XmlAttribute(AttributeName = "gwt")]
        public string GWT { get; set; }

        [XmlAttribute(AttributeName = "rbd")]
        public string RBD { get; set; }

        [XmlAttribute(AttributeName = "pnr")]
        public string PNR { get; set; }

        /// <summary>
        /// 이티켓 발행 가능 여부
        /// </summary>
        [XmlAttribute(AttributeName = "etc")]
        public string ETC { get; set; }

        /// <summary>
        /// 경유 수(기착)
        /// </summary>
        [XmlAttribute(AttributeName = "stn")]
        public string STN { get; set; }

        /// <summary>
        /// 기종
        /// </summary>
        [XmlAttribute(AttributeName = "eqt")]
        public string EQT { get; set; }

        /// <summary>
        /// 편명
        /// </summary>
        [XmlAttribute(AttributeName = "fln")]
        public string FLN { get; set; }

        [XmlAttribute(AttributeName = "occn")]
        public string OCCN { get; set; }

        /// <summary>
        /// 운항 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "occ")]
        public string OCC { get; set; }

        [XmlAttribute(AttributeName = "mccn")]
        public string MCCN { get; set; }

        /// <summary>
        /// 마케팅 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "mcc")]
        public string MCC { get; set; }

        /// <summary>
        /// 도착일시
        /// </summary>
        [XmlAttribute(AttributeName = "ardt")]
        public string ARDT { get; set; }

        /// <summary>
        /// 출발일시
        /// </summary>
        [XmlAttribute(AttributeName = "ddt")]
        public string DDT { get; set; }

        /// <summary>
        /// 도착도시명
        /// </summary>
        [XmlAttribute(AttributeName = "accn")]
        public string ACCN { get; set; }

        /// <summary>
        /// 도착공항명
        /// </summary>
        [XmlAttribute(AttributeName = "alcn")]
        public string ALCN { get; set; }

        /// <summary>
        /// 도착지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "alc")]
        public string ALC { get; set; }

        /// <summary>
        /// 출발도시명
        /// </summary>
        [XmlAttribute(AttributeName = "dccn")]
        public string DCCN { get; set; }

        /// <summary>
        /// 출발공항명
        /// </summary>
        [XmlAttribute(AttributeName = "dlcn")]
        public string DLCN { get; set; }

        /// <summary>
        /// 출발지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "dlc")]
        public string DLC { get; set; }

        [XmlAttribute(AttributeName = "cabin")]
        public string Cabin { get; set; }

        /// <summary>
        /// aif
        /// </summary>
        [XmlAttribute(AttributeName = "aif")]
        public string AIF { get; set; }

        /// <summary>
        /// 여정 상태 코드(항공사코드)
        /// </summary>
        [XmlAttribute(AttributeName = "rsco")]
        public string RSCO { get; set; }

        /// <summary>
        /// 여정 상태 코드(통합코드)
        /// </summary>
        [XmlAttribute(AttributeName = "rsc")]
        public string RSC { get; set; }

        /// <summary>
        /// 도착지 터미널 정보
        /// </summary>
        [XmlAttribute(AttributeName = "atc")]
        public string ATC { get; set; }

        /// <summary>
        /// 출발지 터미널 정보
        /// </summary>
        [XmlAttribute(AttributeName = "dtc")]
        public string DTC { get; set; }

        /// <summary>
        /// 출발지 국가코드
        /// </summary>
        [XmlAttribute(AttributeName = "duc")]
        public string DUC { get; set; }

        /// <summary>
        /// 도착지국가코드
        /// </summary>
        [XmlAttribute(AttributeName = "auc")]
        public string AUC { get; set; }

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
        public string DLC { get; set; }

        /// <summary>
        /// 도착지 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "alc")]
        public string ALC { get; set; }

        /// <summary>
        /// 출발일시(YYYY-MM-DD HH:MM)
        /// </summary>
        [XmlAttribute(AttributeName = "ddt")]
        public string DDT { get; set; }

        /// <summary>
        /// 도착일시(YYYY-MM-DD HH:MM)
        /// </summary>
        [XmlAttribute(AttributeName = "ardt")]
        public string ARDT { get; set; }

        /// <summary>
        /// 비행시간
        /// </summary>
        [XmlAttribute(AttributeName = "eft")]
        public string EFT { get; set; }

        /// <summary>
        /// 기착시간
        /// </summary>
        [XmlAttribute(AttributeName = "gwt")]
        public string GWT { get; set; }

    }
}
