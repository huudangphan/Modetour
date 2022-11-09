namespace ModeTour.Entities
{
    public class HeaderRQModel
    {
        /// <summary>
        /// 해당 서비스 특정 값 RS에만 제공
        /// </summary>
        public string GUID { set; get; }

        /// <summary>
        /// RQ RS생성시간. yyyy-MM-dd HH:mm:ss RS에만 제공 
        /// </summary>
        public string TIMESTAMP { set; get; }

        /// <summary>
        /// version
        /// </summary>
        public string VER { set; get; }

        /// <summary>
        /// 거래처 인증 코드
        /// </summary>
        public int AgentCode { set; get; }

        /// <summary>
        /// 웹사이트 번호
        /// </summary>
        public int SNM { set; get; }

        /// <summary>
        /// 요청한 단말기 종류[WEB,CRS,MOBILEWEB,MOBILAPP]
        /// </summary>
        public string RQT { set; get; }

        /// <summary>
        /// 요청한 페이지 URL
        /// </summary>
        public string RQU { set; get; }

        /// <summary>
        /// 요청한 컴퓨터 IP
        /// </summary>
        public string RIP { set; get; }
    }
}
