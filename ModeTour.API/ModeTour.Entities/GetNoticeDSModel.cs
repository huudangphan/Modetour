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
}
