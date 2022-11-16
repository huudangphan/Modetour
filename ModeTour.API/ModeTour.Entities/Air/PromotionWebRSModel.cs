using System.Xml.Serialization;

namespace ModeTour.Entities.Air
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
        public string Gubun { get; set; }

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
        public string openYn { get; set; }

        /// <summary>
        /// 이미지url
        /// </summary>
        [XmlElement(ElementName = "imgurl")]
        public string ImageURL { get; set; }

        /// <summary>
        /// 경로
        /// </summary>
        [XmlElement(ElementName = "linkurl")]
        public string LinkURL { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        [XmlElement(ElementName = "subject")]
        public string Subject { get; set; }

    }
}
