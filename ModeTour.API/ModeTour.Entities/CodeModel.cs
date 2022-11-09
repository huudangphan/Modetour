namespace ModeTour.Entities
{
    public class CodeModel
    {
        /// <summary>
        /// 종류
        /// </summary>
        public string Group { set; get; }

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// 코드명
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 상태1~상태10
        /// </summary>
        public Dictionary<string, string> Status { get; set; }
    }
}
