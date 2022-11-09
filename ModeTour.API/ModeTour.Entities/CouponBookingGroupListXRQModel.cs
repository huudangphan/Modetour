namespace ModeTour.Entities
{
    public class CouponBookingGroupListXRQModel
    {
        public HeaderRQModel Header { set; get; }

        public CouponBookingGroupListXModel Request { set; get; }

        /// <summary>
        /// 요청 본문
        /// </summary>
        public class CouponBookingGroupListXModel
        {
            /// <summary>
            /// 사용주문번호
            /// </summary>
            public int useOid { set; get; }

            /// <summary>
            /// 사용자PTID(예약자)
            /// </summary>
            public int usePid { set; get; }

            /// <summary>
            /// 
            /// </summary>
            public string PCode { set; get; }

            public string GDS { get; set; }

            public string CountryCode { get; set; }

            public string CityCode { get; set; }

            public string ItemCode { get; set; }

            public Int64 Price { get; set; }

            public Int64 Gross { get; set; }

            public DateTime DepartureDate { get; set; }

            public int Passenger { get; set; }
        }
    }
}
