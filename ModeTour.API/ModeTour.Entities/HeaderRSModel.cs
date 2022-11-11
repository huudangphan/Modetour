using System.Xml.Serialization;

namespace ModeTour.Entities
{
    public class HeaderRSModel
    {
        /// <summary>
        /// 해당 서비스 특정 값 RS에만 제공
        /// </summary>
        [XmlElement(ElementName = "guid")]
        public string guid { set; get; }

        /// <summary>
        /// RQ RS생성시간. yyyy-MM-dd HH:mm:ss RS에만 제공 
        /// </summary>
        [XmlElement(ElementName = "timeStamp")]
        public string timestamp { set; get; }

        /// <summary>
        /// version
        /// </summary>
        [XmlElement(ElementName = "ver")]
        public string ver { set; get; }

        /// <summary>
        /// 거래처 인증 코드
        /// </summary>
        [XmlElement(ElementName = "agentCode")]
        public string agentCode { set; get; }

        /// <summary>
        /// 웹사이트 번호
        /// </summary>
        [XmlElement(ElementName = "snm")]
        public int snm { set; get; }

        /// <summary>
        /// 요청한 단말기 종류[WEB,CRS,MOBILEWEB,MOBILAPP]
        /// </summary>
        [XmlElement(ElementName = "rqt")]
        public string rqt { set; get; }

        /// <summary>
        /// 요청한 페이지 URL
        /// </summary>
        [XmlElement(ElementName = "rqu")]
        public string rqu { set; get; }

        /// <summary>
        /// 요청한 컴퓨터 IP
        /// </summary>
        [XmlElement(ElementName = "rip")]
        public string rip { set; get; }
    }
}
