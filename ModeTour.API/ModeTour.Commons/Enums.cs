namespace ModeTour.Commons
{
    public class Enums
    {
        public enum ActionType
        {
            Add = 1,
            Remove = 2,
            Update = 3,
            Select = 4

        }
        public enum ServiceType
        {
            Config,
            OVERSEAS,
            OVERSEAS2,
            OVERSEAS3,
            AVAILOVERSEAS2,
            DOMESTIC,
            ALLIANCEOVERSEA,
            ALLIANCEDOMESTIC,
            ApiDomestic,
            Allwin
        }
        public enum LayoutVersionType
        {
            /// <summary>
            /// 설정되지 않은 레이아웃 구성
            /// </summary>
            None,
            /// <summary>
            /// 기존 서비스 기준으로 레이아웃 구성
            /// </summary>
            Old,
            /// <summary>
            /// 신규 서비스 기준으로 레이아웃 구성
            /// </summary>
            New
        }
        public enum LayoutOptionMasterType
        {
            Base,
            None,
            TF,
            TBF,
            TLF,
            TLBF,
            TRF,
            TBRF,
            TLRF,
            TLBRF
        }
        /// <summary>
        /// 마스터 페이지 타입
        /// </summary>
        public LayoutOptionMasterType Master { set; get; }

        private string _mloc = "00";
        /// <summary>
        /// 서비스구분코드
        /// </summary>
        public string MLoc { set { _mloc = string.IsNullOrEmpty(value) ? "00" : value; } get { return _mloc; } }

        private string _parameter = string.Empty;
        /// <summary>
        /// 파라미터 값
        /// </summary>
        public string Parameter { set { _parameter = value; } get { return _parameter; } }
        public enum APIEncodingType
        {
            /// <summary>
            /// UTF-8
            /// </summary>
            UTF8,
            /// <summary>
            /// EUC-KR
            /// </summary>
            EUCKR
        }

    }
}
