namespace ModeTour.Entities
{
    public class GetNoticeDSModel
    {
        public int ItemNo { get; set; }

        /// <summary>
        /// 스텝1
        /// </summary>
        public int Step1 { get; set; }

        /// <summary>
        /// 작성자
        /// </summary>
        public String Writer { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 조회수
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime WriteDate { get; set; }

        /// <summary>
        /// 공지
        /// </summary>
        public String Notice { get; set; }
    }
    public class GetNoticeDSModelTemp
    {
        public int 일련번호 { get; set; }

        /// <summary>
        /// 스텝1
        /// </summary>
        public int 스텝1 { get; set; }

        /// <summary>
        /// 작성자
        /// </summary>
        public String 작성자 { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        public String 제목 { get; set; }

        /// <summary>
        /// 조회수
        /// </summary>
        public int 조회수 { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime 등록일 { get; set; }

        /// <summary>
        /// 공지
        /// </summary>
        public String 공지 { get; set; }
    }
}
