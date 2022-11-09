using System.Xml;
using System.Xml.Serialization;

namespace ModeTour.Entity
{
    [Serializable]
    [XmlRoot(ElementName = "ResponseDetails")]
    public class SearchFareAvailSimpleRSModel
    {
        [XmlAttribute(AttributeName = "ref")]
        public String Ref { get; set; }

        [XmlAttribute(AttributeName = "guid")]
        public String GUID { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public String Version { get; set; }

        [XmlAttribute(AttributeName = "timeStamp")]
        public String TimeStamp { get; set; }

        /// <summary>
        /// 요금Summary정보
        /// </summary>
        [XmlArray(ElementName = "priceSummary")]
        [XmlArrayItem(ElementName = "min")]
        public List<PriceSummaryModel> PriceSummary { get; set; }

        /// <summary>
        /// 여정정보
        /// </summary>
        [XmlElement(ElementName = "flightInfo")]
        public NewFlightInfoModel FlightInfo { get; set; }

        /// <summary>
        /// 요금정보
        /// </summary>
        [XmlArray(ElementName = "priceInfo")]
        [XmlArrayItem(ElementName = "priceIndex")]
        public List<PriceIndexModel> PriceIndex { get; set; }

        #region 요금Summary 정보(PriceSummaryModel)

        public class PriceSummaryModel
        {
            [XmlAttribute(AttributeName = "airline")]
            public String Airline { get; set; }

            [XmlAttribute(AttributeName = "price")]
            public String Price { get; set; }
        }

        #endregion

        #region 요금 정보(PriceIndex)

        [XmlType("priceIndex")]
        public class PriceIndexModel
        {
            [XmlAttribute(AttributeName = "ref")]
            public Int32 REF { get; set; }

            /// <summary>
            /// 요금조건코드(ADT:성인, DIS:장애인, STU:학생, SRC:경로, LBR:근로자)
            /// </summary>
            [XmlAttribute(AttributeName = "ptc")]
            public String PTC { get; set; }

            [XmlAttribute(AttributeName = "pvc")]
            public String PVC { get; set; }

            [XmlAttribute(AttributeName = "mode")]
            public String Mode { get; set; }

            [XmlAttribute(AttributeName = "cabin")]
            public String Cabin { get; set; }

            [XmlAttribute(AttributeName = "minPrice")]
            public String MinPrice { get; set; }


            [XmlAttribute(AttributeName = "fareCount")]
            public Int16 FareCount { get; set; }

            /// <summary>
            /// 여정정보
            /// </summary>
            [XmlElement(ElementName = "segGroup")]
            public PriceSegGroupModel PriceSeg { get; set; }

            /// <summary>
            /// 상세요금정보
            /// </summary>
            [XmlArray(ElementName = "paxFareInfo")]
            [XmlArrayItem(ElementName = "paxFareGroup")]
            public List<NewPaxFareGroupModel> PaxFareGroup { get; set; }

        }

        #endregion

        #region 여정정보 (PriceSegModel/REFModel)

        //[XmlType("segGroup")]
        public class PriceSegGroupModel
        {
            /// <summary>
            /// 여정정보
            /// </summary>
            [XmlElement(ElementName = "seg")]
            public List<PriceSegModel> Seg { get; set; }
        }

        //[XmlType("seg")]
        public class PriceSegModel
        {
            /// <summary>
            /// 여정정보
            /// </summary>
            [XmlElement(ElementName = "ref")]
            public List<REFModel> REF { get; set; }
        }

        //[XmlType("ref")]
        public class REFModel
        {
            /// <summary>
            /// 여정 참조번호 number references
            /// </summary>
            [XmlAttribute(AttributeName = "sgRef")]
            public String sgRef { get; set; }

            /// <summary>
            /// baggage
            /// </summary>
            [XmlAttribute(AttributeName = "baggage")]
            public String Baggage { get; set; }

            /// <summary>
            /// 여정 정보(*표시는 기착지 ex) ICN/*TPE/BKK )
            /// </summary>
            [XmlAttribute(AttributeName = "rtg")]
            public String RTG { get; set; }

            /// <summary>
            /// 그룹 여정정보(0.출발공항/1.도착공항/2.출발일시/3.도착일시/4.총소요시간/5.총비행시간/6.총대기시간/7.대표항공사/8.경유수/9.기착수/10.공동운항여부)
            /// </summary>
            [XmlText]
            public String ITI { get; set; }
        }

        #endregion

        #region 상세요금정보 (PaxFareGroupModel)

        [XmlType("paxFareInfo")]
        public class NewPaxFareGroupModel
        {
            /// <summary>
            /// 참조번호
            /// </summary>
            [XmlAttribute(AttributeName = "ref")]
            public String Ref { get; set; }

            [XmlAttribute(AttributeName = "gds")]
            public String PaxGDS { get; set; }

            /// </summary>
            [XmlAttribute(AttributeName = "ptc")]
            public String PTC { get; set; }

            /// </summary>
            [XmlAttribute(AttributeName = "mode")]
            public String Mode { get; set; }

            /// <summary>
            /// 요금Summary
            /// </summary>
            [XmlElement(ElementName = "summary")]
            public SummaryModel Summary { get; set; }

            /// <summary>
            /// 타입별요금상세
            /// </summary>
            [XmlElement(ElementName = "paxFare")]
            public List<NewPaxFareModel> PaxFare { get; set; }


            /// <summary>
            /// 기타 요금 정보(패널티 등)
            /// </summary>
            [XmlAnyElement("fareMessage")]
            public XmlElement FareMessage { get; set; }


            [XmlElement(ElementName = "promotionInfo")]
            [XmlText]
            public string PromotionInfo { get; set; }

        }

        #region Summary

        [XmlType("summary")]
        public class SummaryModel
        {
            /// <summary>
            /// 항공판매가 합계(disFare + tax + fsc)
            /// </summary>
            [XmlAttribute(AttributeName = "price")]
            public Int32 Price { get; set; }

            /// <summary>
            /// 항공요금 합계
            /// </summary>
            [XmlAttribute(AttributeName = "subPrice")]
            public Int32 SubPrice { get; set; }

            /// <summary>
            /// 항공요금 합계
            /// </summary>
            [XmlAttribute(AttributeName = "fare")]
            public Int32 Fare { get; set; }

            /// <summary>
            /// 항공할인요금 합계
            /// </summary>
            [XmlAttribute(AttributeName = "disFare")]
            public Int32 DisFare { get; set; }

            /// <summary>
            /// TAX 합계
            /// </summary>
            [XmlAttribute(AttributeName = "tax")]
            public Int32 Tax { get; set; }

            /// <summary>
            /// 유류할증료합계
            /// </summary>
            [XmlAttribute(AttributeName = "fsc")]
            public Int32 Fsc { get; set; }

            /// <summary>
            /// 파트너 할인요금합계
            /// </summary>
            [XmlAttribute(AttributeName = "disPartner")]
            public Int32 DisPartner { get; set; }

            /// <summary>
            /// 발권 여행사 수수료(@mTasf + @aTasf) 
            /// </summary>
            [XmlAttribute(AttributeName = "tasf")]
            public Int32 Tasf { get; set; }

            /// <summary>
            /// 모두투어의 기본 TASF
            /// </summary>
            [XmlAttribute(AttributeName = "mTasf")]
            public Int32 MTasf { get; set; }

            /// <summary>
            /// 제휴사의 기본 TASF 
            /// </summary>
            [XmlAttribute(AttributeName = "aTasf")]
            public Int32 ATasf { get; set; }

            [XmlAttribute(AttributeName = "pvc")]
            public String PVC { get; set; }

            [XmlAttribute(AttributeName = "mas")]
            public String MAS { get; set; }

            [XmlAttribute(AttributeName = "cabin")]
            public String Cabin { get; set; }

            /// <summary>
            /// 발권시한
            /// </summary>
            [XmlAttribute(AttributeName = "ttl")]
            public String Ttl { get; set; }

            /// <summary>
            /// 공동운항 여부
            /// </summary>
            [XmlAttribute(AttributeName = "cds")]
            public String CDS { get; set; }

            /// <summary>
            /// 미확정 운임 여부
            /// </summary>
            [XmlAttribute(AttributeName = "ucf")]
            public String UCF { get; set; }

            /// <summary>
            /// 자동 발권 불가 운임 여부
            /// </summary>
            [XmlAttribute(AttributeName = "ntf")]
            public String NTF { get; set; }

            /// <summary>
            /// 확정 운임 여부
            /// </summary>
            [XmlAttribute(AttributeName = "cff")]
            public String CFF { get; set; }

            /// <summary>
            /// 자동 발권 운임 여부
            /// </summary>
            [XmlAttribute(AttributeName = "ttf")]
            public String TTF { get; set; }


            /// <summary>
            /// TASF 적용 사용자 선택 가능 여부(Y:사용자 선택 가능, N:사용자 선택 불가)
            /// </summary>
            [XmlAttribute(AttributeName = "sutf")]
            public String Sutf { get; set; }

            /// <summary>
            /// 프로모션 번호 
            /// </summary>
            [XmlAttribute(AttributeName = "pmcd")]
            public String Pmcd { get; set; }

            /// <summary>
            /// 프로모션명 
            /// </summary>
            [XmlAttribute(AttributeName = "pmtl")]
            public String Pmtl { get; set; }

            /// <summary>
            /// 프로모션카드코드 
            /// </summary>
            [XmlAttribute(AttributeName = "pmsc")]
            public String Pmsc { get; set; }

            /// <summary>
            /// 프로모션카드명 
            /// </summary>
            [XmlAttribute(AttributeName = "pmsn")]
            public String Pmsn { get; set; }

            /// <summary>
            /// 부가서비스 번호 
            /// </summary>
            [XmlAttribute(AttributeName = "sscd")]
            public String Sscd { get; set; }

            /// <summary>
            /// 부가서비스명 
            /// </summary>
            [XmlAttribute(AttributeName = "sstl")]
            public String Sstl { get; set; }
        }

        #endregion

        [XmlType("paxFareGroup")]
        public class NewPaxFareModel
        {

            /// <summary>
            /// 요금조건코드(ADT:성인, DIS:장애인, STU:학생, SRC:경로, LBR:근로자)
            /// </summary>
            [XmlAttribute(AttributeName = "ptc")]
            public String PTC { get; set; }

            /// <summary>
            /// 항공요금 합계
            /// </summary>
            [XmlAttribute(AttributeName = "price")]
            public Int32 Price { get; set; }

            [XmlAttribute(AttributeName = "subPrice")]
            public Int32 SubPrice { get; set; }

            /// <summary>
            /// 항공요금 합계
            /// </summary>
            [XmlAttribute(AttributeName = "fare")]
            public Int32 Fare { get; set; }

            /// <summary>
            /// 항공할인요금 합계
            /// </summary>
            [XmlAttribute(AttributeName = "disFare")]
            public Int32 DisFare { get; set; }

            /// <summary>
            /// TAX 합계
            /// </summary>
            [XmlAttribute(AttributeName = "tax")]
            public Int32 Tax { get; set; }

            /// <summary>
            /// 유류할증료합계
            /// </summary>
            [XmlAttribute(AttributeName = "fsc")]
            public Int32 Fsc { get; set; }

            /// <summary>
            /// 파트너 할인요금합계
            /// </summary>
            [XmlAttribute(AttributeName = "disPartner")]
            public Int32 DisPartner { get; set; }

            /// <summary>
            /// 발권 여행사 수수료(@mTasf + @aTasf) 
            /// </summary>
            [XmlAttribute(AttributeName = "tasf")]
            public Int32 Tasf { get; set; }

            /// <summary>
            /// 모두투어의 기본 TASF
            /// </summary>
            [XmlAttribute(AttributeName = "mTasf")]
            public Int32 MTasf { get; set; }

            /// <summary>
            /// 제휴사의 기본 TASF 
            /// </summary>
            [XmlAttribute(AttributeName = "aTasf")]
            public Int32 ATasf { get; set; }

            /// <summary>
            /// 인원수 
            /// </summary>
            [XmlAttribute(AttributeName = "count")]
            public Int32 Count { get; set; }


            [XmlElement(ElementName = "segFare")]
            public List<SegFareModel> SegFare { get; set; }

            /// <summary>
            /// 
            /// </summary>
            //[XmlArray(ElementName = "segFareGroup")]
            //[XmlArrayItem(ElementName = "segFare ")]
            //public List<SegFareModel> SegFare { get; set; }
        }

        [XmlType("segFare")]
        public class SegFareModel
        {
            /// <summary>
            /// 참조번호
            /// </summary>
            [XmlAttribute(AttributeName = "ref")]
            public string REF { get; set; }


            [XmlText]
            public String Text { get; set; }

        }

        #endregion
    }
}
