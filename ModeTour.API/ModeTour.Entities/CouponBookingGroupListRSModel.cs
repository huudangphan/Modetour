using System.Xml.Serialization;

namespace ModeTour.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "couponBookingGroupListRS")]
    public class CouponBookingGroupListRSModel
    {
        [XmlElement(ElementName = "header")]
        public HeaderRSModel header { set; get; }

        [XmlElement(ElementName = "response")]
        public CouponBookingGroupListResponse response { set; get; }

        public class CouponBookingGroupListResponse
        {
            [XmlElement(ElementName = "bookingInfo")]
            public BookingInfoModel bookingInfo { set; get; }

            [XmlElement(ElementName = "couponCommonList")]
            public CouponCommonListModel couponList { set; get; }

            public class BookingInfoModel
            {
                /// <summary>
                /// 사용자주문번호 -- user order no
                /// </summary>
                [XmlElement(ElementName = "useOid")]
                public int useOid { set; get; }

                /// <summary>
                /// 출발일, 체크인 날짜 
                /// </summary>
                [XmlElement(ElementName = "departureDate")]
                public string departureDate { set; get; }

                /// <summary>
                /// 공급사코드 -- supplier no
                /// </summary>
                [XmlElement(ElementName = "gdsCode")]
                public string gdsCode { set; get; }

                /// <summary>
                /// 국가코드
                /// </summary>
                [XmlElement(ElementName = "countryCode")]
                public string countryCode { set; get; }

                /// <summary>
                /// 도시코드[IA:공항코드, IH:도시코드]
                /// </summary>
                [XmlElement(ElementName = "cityCode")]
                public string cityCode { set; get; }

                /// <summary>
                /// 아이템코드
                /// </summary>
                [XmlElement(ElementName = "itemCode")]
                public string itemCode { set; get; }

                /// <summary>
                /// 항공료, 호텔요금[할인받을 요금] -- airfare, hotel [discounted price]
                /// </summary>
                [XmlElement(ElementName = "gross")]
                public int gross { set; get; }

                /// <summary>
                /// 총 항공요금, 호텔 요금[결제 예정금액]
                /// </summary>
                [XmlElement(ElementName = "totalPrice")]
                public int totalPrice { set; get; }
            }

            public class CouponCommonListModel
            {
                [XmlElement(ElementName = "coupon")]
                public List<CouponModel> coupon { set; get; }
            }
        }
    }
}
