using System.Xml.Serialization;

namespace ModeTour.Entities
{
    public class CouponModel
    {
        /// <summary>
        /// 쿠폰 발급번호[key]
        /// </summary>
        [XmlElement(ElementName = "issueNumber")]
        public int issueNumber { set; get; }

        /// <summary>
        /// 발급주문번호
        /// </summary>
        [XmlElement(ElementName = "issueOid")]
        public int issueOid { set; get; }

        /// <summary>
        /// 발급자PTID(예약자) 
        /// </summary>
        [XmlElement(ElementName = "issuePid")]
        public int issuePid { set; get; }

        /// <summary>
        /// 발급일
        /// </summary>
        [XmlElement(ElementName = "issueDate")]
        public string issueDate { set; get; }

        /// <summary>
        /// 할인 번호
        /// </summary>
        [XmlElement(ElementName = "dcNumber")]
        public Int64 DcNum { set; get; }

        /// <summary>
        /// 쿠폰 번호
        /// </summary>
        [XmlElement(ElementName = "couponNumber")]
        public string couponNumber { set; get; }

        /// <summary>
        /// 할인쿠폰명 
        /// </summary>
        [XmlElement(ElementName = "couponName")]
        public string couponName { set; get; }

        /// <summary>
        /// 할인구분[percent, price]
        /// </summary>
        [XmlElement(ElementName = "divisionPP")]
        public string divisionPP { set; get; }

        /// <summary>
        /// 할인율 또는 할인금액 
        /// </summary>
        [XmlElement(ElementName = "couponPercent")]
        public double couponPercent { set; get; }

        /// <summary>
        /// 최소적용금액[판매금액대비 할인 적용 할 수 있는 금액]
        /// </summary>
        [XmlElement(ElementName = "couponMinPrice")]
        public int couponMinPrice { set; get; }

        /// <summary>
        /// 최대할인금액[할인 가능한 최대금액] 
        /// </summary>
        [XmlElement(ElementName = "couponMaxPrice")]
        public int couponMaxPrice { set; get; }

        /// <summary>
        /// 쿠폰 할인 금액
        /// </summary>
        [XmlElement(ElementName = "discountPrice")]
        public int discountPrice { set; get; }

        /// <summary>
        /// 가용가능일S : yyyy-MM-dd
        /// </summary>
        [XmlElement(ElementName = "useStartDate")]
        public string useStartDate { set; get; }

        /// <summary>
        /// 사용가능일E : yyyy-MM-dd
        /// </summary>
        [XmlElement(ElementName = "useEndDate")]
        public string useEndDate { set; get; }

        /// <summary>
        /// 시작일S : yyyy-MM-dd
        /// </summary>
        [XmlElement(ElementName = "startDate")]
        public string startDate { set; get; }

        /// <summary>
        /// 시작일E : yyyy-MM-dd
        /// </summary>
        [XmlElement(ElementName = "endDate")]
        public string endDate { set; get; }

        /// <summary>
        /// 사용 가능거래처번호
        /// </summary>
        [XmlElement(ElementName = "useAgentNumber")]
        public int useAgentNumber { set; get; }

        /// <summary>
        /// 사용 가능사이트번호
        /// </summary>
        [XmlElement(ElementName = "useSiteNumber")]
        public int useSiteNumber { set; get; }

        /// <summary>
        /// 품목코드 IA, IH, DA, DH 
        /// </summary>
        [XmlElement(ElementName = "useProductCode")]
        public string useProductCode { set; get; }

        /// <summary>
        /// 유효기간 : 숫자 + [일 or 월 or 년] : 1D, 1M, 1Y 
        /// </summary>
        [XmlElement(ElementName = "expirationDate")]
        public string expirationDate { set; get; }

        /// <summary>
        /// 사용조건 호텔 공급사코드
        /// </summary>
        [XmlElement(ElementName = "gdsCode")]
        public string gdsCode { set; get; }

        /// <summary>
        /// 사용조건 지역코드
        /// </summary>
        [XmlElement(ElementName = "areaCode")]
        public string areaCode { set; get; }

        /// <summary>
        /// 사용조건 국가코드
        /// </summary>
        [XmlElement(ElementName = "countryCode")]
        public string countryCode { set; get; }

        /// <summary>
        /// 사용조건 국가명
        /// </summary>
        [XmlElement(ElementName = "countryName")]
        public string countryName { set; get; }

        /// <summary>
        /// 사용조건 도시코드[IA : 공항, IH : 도시]
        /// </summary>
        [XmlElement(ElementName = "cityCode")]
        public string cityCode { set; get; }

        /// <summary>
        /// 사용조건 도시명
        /// </summary>
        [XmlElement(ElementName = "cityName")]
        public string cityName { set; get; }

        /// <summary>
        /// 사용조건 아이템코드[IA : 항공사, IH : 호텔]
        /// </summary>
        [XmlElement(ElementName = "itemCode")]
        public string itemCode { set; get; }

        /// <summary>
        /// 사용조건 아이템명
        /// </summary>
        [XmlElement(ElementName = "itemName")]
        public string itemName { set; get; }

        /// <summary>
        /// 단말기
        /// </summary>
        [XmlElement(ElementName = "rqtName")]
        public string rqtName { set; get; }

        /// <summary>
        /// 제외지역
        /// </summary>
        [XmlElement(ElementName = "excludeAreaCode")]
        public string excludeAreaCode { set; get; }

        /// <summary>
        /// 제외국가
        /// </summary>
        [XmlElement(ElementName = "excludeCountryCode")]
        public string excludeCountryCode { set; get; }

        /// <summary>
        /// 제외국가명
        /// </summary>
        [XmlElement(ElementName = "excludeCountryName")]
        public string excludeCountryName { set; get; }

        /// <summary>
        /// 제외도시
        /// </summary>
        [XmlElement(ElementName = "excludeCityCode")]
        public string excludeCityCode { set; get; }

        /// <summary>
        /// 제외도시명
        /// </summary>
        [XmlElement(ElementName = "excludeCityName")]
        public string excludeCityName { set; get; }

        /// <summary>
        /// 제외아이템
        /// </summary>
        [XmlElement(ElementName = "excludeItemCode")]
        public string excludeItemCode { set; get; }

        /// <summary>
        /// 제외아이템명
        /// </summary>
        [XmlElement(ElementName = "excludeItemName")]
        public string excludeItemName { set; get; }

        /// <summary>
        /// 사용여부
        /// </summary>
        [XmlElement(ElementName = "useYN")]
        public string useYN { set; get; }

        /// <summary>
        /// 패키지용 : 상품소분류CSV
        /// </summary>
        [XmlElement(ElementName = "productCSV")]
        public string productCSV { set; get; }

        /// <summary>
        /// 패키지용 : 판매종류CSV
        /// </summary>
        [XmlElement(ElementName = "saleCSV")]
        public string saleCSV { set; get; }

        /// <summary>
        /// 패키지용 : 지역CSV
        /// </summary>
        [XmlElement(ElementName = "stateCSV")]
        public string stateCSV { set; get; }

        /// <summary>
        /// 패키지요 : 회원구분CSV
        /// </summary>
        [XmlElement(ElementName = "memberCSV")]
        public string memberCSV { set; get; }

    }
}
