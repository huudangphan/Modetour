namespace ModeTour.Entities
{
    public class GetTodayListDSModel
    {
        public List<TodayModel> TodayList { get; set; }
    }

    /// <summary>
    /// 땡처리항공권 Item
    /// </summary>
    public class TodayModel
    {
        /// <summary>
        /// 재고번호
        /// </summary>
        public Int64 Vnum { get; set; }

        /// <summary>
        /// 단체명
        /// </summary>
        public String GroupNM { get; set; }

        /// <summary>
        /// 상품코드
        /// </summary>
        public String ItemCD { get; set; }

        /// <summary>
        /// 이전가격
        /// </summary>
        public Int64 Normal { get; set; }

        /// <summary>
        /// 가격
        /// </summary>
        public Int64 disFare { get; set; }

        /// <summary>
        /// 제세공과금
        /// </summary>
        public Int64 Tax2 { get; set; }

        /// <summary>
        /// Tax
        /// </summary>
        public Int64 Tax { get; set; }

        /// <summary>
        /// 항공코드
        /// </summary>
        public String AirCD { get; set; }

        /// <summary>
        /// 항공사명
        /// </summary>
        public String AirNM { get; set; }

        /// <summary>
        /// 출발일(yyyy-MM-dd)
        /// </summary>
        public DateTime SDate { get; set; }

        /// <summary>
        /// 도착일(yyyy-MM-dd)
        /// </summary>
        public DateTime EDate { get; set; }

        /// <summary>
        /// 출발시간
        /// </summary>
        public String STime { get; set; }

        /// <summary>
        /// 도착시간
        /// </summary>
        public String ETime { get; set; }

        /// <summary>
        /// 기간
        /// </summary>
        public Int64 Day { get; set; }

        /// <summary>
        /// 웹판매가능좌석
        /// </summary>
        public Int64 RSeatWeb { get; set; }

        /// <summary>
        /// 잔여좌석
        /// </summary>
        public Int64 LeftOverSeat { get; set; }

        /// <summary>
        /// 잔여좌석2
        /// </summary>
        public Int64 LeftOverSeat2 { get; set; }

        /// <summary>
        /// 구역번호
        /// </summary>
        public String AreaNum { get; set; }
    }
}
