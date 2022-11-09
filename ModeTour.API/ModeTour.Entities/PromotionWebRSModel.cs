using System.Xml.Serialization;

namespace ModeTour.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "modetour")]
    public class PromotionWebRSModel
    {
        [XmlElement(ElementName = "promotion")]
        public List<PromotionItemModel> Promotion { get; set; }
    }
    public class PromotionItemModel
    {
        /// <summary>
        /// gubun
        /// </summary>
        [XmlAttribute(AttributeName = "gubun")]
        public String Gubun { get; set; }

        /// <summary>
        /// 기획전 리스트
        /// </summary>
        [XmlElement(ElementName = "item")]
        public List<PItemModel> Item { get; set; }
    }

    public class PItemModel
    {
        /// <summary>
        /// openYN
        /// </summary>
        [XmlAttribute(AttributeName = "open")]
        public String openYn { get; set; }

        /// <summary>
        /// 이미지url
        /// </summary>
        [XmlElement(ElementName = "imgurl")]
        public String ImageURL { get; set; }

        /// <summary>
        /// 경로
        /// </summary>
        [XmlElement(ElementName = "linkurl")]
        public String LinkURL { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        [XmlElement(ElementName = "title")]
        public String Title { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        [XmlElement(ElementName = "subject")]
        public String Subject { get; set; }

    }
}
