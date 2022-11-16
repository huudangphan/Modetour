using System.Xml;
using System.Xml.Serialization;
using static ModeTour.Entities.Air.SearchFareAvailSimpleRSModel;

namespace ModeTour.Entities.Air
{
    [Serializable]
    [XmlRoot(ElementName = "priceIndex")]
    [XmlType("priceIndex")]
    public class PriceIndexOrderModel
    {
        /// <summary>
        /// 참조번호
        /// </summary>
        [XmlAttribute(AttributeName = "ref")]
        public String Ref { get; set; }

        [XmlAttribute(AttributeName = "guid")]
        public String Guid { get; set; }

        /// <summary>
        /// 요금조건코드(ADT:성인, DIS:장애인, STU:학생, SRC:경로, LBR:근로자)
        /// </summary>
        [XmlAttribute(AttributeName = "ptc")]
        public String PTC { get; set; }

        /// <summary>
        /// GDS
        /// </summary>
        [XmlAttribute(AttributeName = "gds")]
        public String GDS { get; set; }

        [XmlAttribute(AttributeName = "mode")]
        public String Mode { get; set; }

        /// <summary>
        /// 종합정보
        /// </summary>
        [XmlElement(ElementName = "summary")]
        public SummaryModel Summary { get; set; }

        /// <summary>
        /// 대표여정정보
        /// </summary>
        [XmlElement(ElementName = "segGroup")]
        public SearchFareAvailSimpleRSModel.PriceSegGroupModel PriceSeg { get; set; }

        /// <summary>
        /// 탑승객 요금 정보
        /// </summary>
        [XmlArray(ElementName = "paxFareGroup")]
        [XmlArrayItem(ElementName = "paxFare")]
        public List<PaxFareModel> PaxFareGroup { get; set; }

        /// <summary>
        /// 기타 요금 정보(패널티 등)
        /// </summary>
        [XmlAnyElement("fareMessage")]
        public XmlElement FareMessage { get; set; }

        /// <summary>
        /// 요금규정 URL(갈릴레오 운임일 경우)
        /// </summary>
        [XmlElement(ElementName = "fareRuleUrl")]
        public String FareRuleUrl { get; set; }

        /// <summary>
        /// 프로모션 정보
        /// </summary>
        //[XmlElement(ElementName = "promotionInfo")]
        //public PromotionInfoModel PromotionInfo { get; set; }


        public class PaxFareModel
        {
            /// <summary>
            /// 탑승객 구분 코드(ADT:성인, CHD:소아, INF:유아, DIS:장애인, STU:학생, SRC:경로, LBR:근로자)
            /// </summary>
            [XmlAttribute(AttributeName = "ptc")]
            public String PTC { get; set; }

            /// <summary>
            /// 탑승객 타입별 종합 정보
            /// </summary>
            //[XmlElement(ElementName = "amount")]
            //public AmountModel Amount { get; set; }

            /// <summary>
            /// 여정별 요금 정보
            /// </summary>
            [XmlArray(ElementName = "segFareGroup")]
            [XmlArrayItem(ElementName = "segFare")]
            public List<SegFareModel> SegFare { get; set; }

            /// <summary>
            /// 탑승객 정보
            /// </summary>
            [XmlArray(ElementName = "traveler")]
            [XmlArrayItem(ElementName = "ref")]
            public List<TravelerRefModel> TraverlerRef { get; set; }
        }
        public class TravelerRefModel
        {
            /// <summary>
            /// 보호자 참조번호
            /// </summary>
            [XmlAttribute(AttributeName = "ind")]
            public String Ind { get; set; }

            /// <summary>
            /// 탑승객 참조번호
            /// </summary>
            [XmlText]
            public String NodeValue { get; set; }
        }
    }
}
