namespace ModeTour.Commons
{
    public class ResultModel
    {
        private string _code = string.Empty;
        /// <summary>
        /// 결과 코드 값 (기본값 : 999)
        /// </summary>
        public string Code { set; get; }

        private string _msg = string.Empty;
        /// <summary>
        /// 결과 메세지 값 (기본값 : new object)
        /// </summary>
        public string Msg { set; get; }

        /// <summary>
        /// 결과 데이터
        /// </summary>
        public object Data { set; get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ResultModel()
        {
            Code = "999";
            Msg = "new object";
        }

        /// <summary>
        /// 해당 객체에 대한 결과 정보 반환
        /// </summary>
        /// <returns type="string">code : Code 값, msg : Msg 값, data : Data 값</returns>
        public override string ToString()
        {
            if (Data == null)
            {
                return string.Format("code : {0}, msg : {1}", Code, Msg);
            }
            else
            {
                return string.Format("code : {0}, msg : {1}, data : {2}", Code, Msg, Data.ToString());
            }
        }
    }
}
