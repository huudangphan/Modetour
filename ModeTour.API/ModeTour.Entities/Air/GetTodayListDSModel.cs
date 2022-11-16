namespace ModeTour.Entities.Air
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
        public long Vnum { get; set; }

        /// <summary>
        /// 단체명
        /// </summary>
        public string GroupNM { get; set; }

        /// <summary>
        /// 상품코드
        /// </summary>
        public string ItemCD { get; set; }

        /// <summary>
        /// 이전가격
        /// </summary>
        public long Normal { get; set; }

        /// <summary>
        /// 가격
        /// </summary>
        public long disFare { get; set; }

        /// <summary>
        /// 제세공과금
        /// </summary>
        public long Tax2 { get; set; }

        /// <summary>
        /// Tax
        /// </summary>
        public long Tax { get; set; }

        /// <summary>
        /// 항공코드
        /// </summary>
        public string AirCD { get; set; }

        /// <summary>
        /// 항공사명
        /// </summary>
        public string AirNM { get; set; }

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
        public string STime { get; set; }

        /// <summary>
        /// 도착시간
        /// </summary>
        public string ETime { get; set; }

        /// <summary>
        /// 기간
        /// </summary>
        public long Day { get; set; }

        /// <summary>
        /// 웹판매가능좌석
        /// </summary>
        public long RSeatWeb { get; set; }

        /// <summary>
        /// 잔여좌석
        /// </summary>
        public long LeftOverSeat { get; set; }

        /// <summary>
        /// 잔여좌석2
        /// </summary>
        public long LeftOverSeat2 { get; set; }

        /// <summary>
        /// 구역번호
        /// </summary>
        public string AreaNum { get; set; }
    }
}
