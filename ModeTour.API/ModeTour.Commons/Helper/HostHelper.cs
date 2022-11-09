using System.Text.RegularExpressions;

namespace ModeTour.Commons.Helper
{
    public enum HostEnvironmentType
    {
        /// <summary>
        /// 개발
        /// </summary>
        DEV,
        /// <summary>
        /// 테스트
        /// </summary>
        QA,
        //BETA,
        /// <summary>
        /// 실 서비스
        /// </summary>
        Live
    }
    public class HostHelper
    {
        private static string _key = "ModeHostSingleton";

        /// <summary>
        /// HostHelper Singleton Instance : 웹요청시마다 생성
        /// </summary>
        public static HostHelper Instance
        {
            get
            {
                if (ModeUtils.Context.Items[_key] == null)
                {
                    ModeUtils.Context.Items[_key] = new HostHelper();
                }

                return ModeUtils.Context.Items[_key] as HostHelper;
            }
        }

        /// <summary>
        /// 사용하지 말것 : 삭제예정
        /// </summary>
        public static string JsUrl { get { return Instance.JS; } }

        private string _current_domain;
        /// <summary>
        /// 현재페이지 도메인
        /// </summary>
        public string CurrentDomain { get { return _current_domain; } }

        private int _current_port;
        public int CurrentPort { get { return _current_port; } }

        private string _environment_str;
        /// <summary>
        /// 개발환경 문자열(dev / qa)
        /// </summary>
        public string EnvironmentStr { get { return _environment_str; } }

        private string _environment_fiexed_str;
        /// <summary>
        /// 개발환경 fiexed 문자열(dev- / qa-)
        /// </summary>
        public string EnvironmentFiexedStr { get { return _environment_fiexed_str; } }

        private HostEnvironmentType _environment;
        /// <summary>
        /// 개발환경타입
        /// </summary>
        public HostEnvironmentType Environment
        {
            get
            {
                if (string.IsNullOrEmpty(_environment_str))
                {
                    _environment = HostEnvironmentType.Live;
                }
                else if (!Enum.TryParse(_environment_str.ToUpper(), out _environment))
                {
                    _environment = HostEnvironmentType.Live;
                }
                return _environment;
            }
        }

        private string _protocol;

        private string _domain;
        /// <summary>
        /// 도메인
        /// </summary>
        public string Domain { get { return _domain; } }

        private string _url;
        /// <summary>
        /// 기본 URL
        /// </summary>
        public string Url { get { return _url; } }

        private string _js;
        /// <summary>
        /// JS 기본 URL
        /// </summary>
        public string JS { get { return _js; } }


        private string _js2;
        /// <summary>
        /// JS 기본 URL
        /// </summary>
        public string JS2 { get { return _js2; } }

        private string _css;
        /// <summary>
        /// CSS 기본 URL
        /// </summary>
        public string CSS { get { return _css; } }

        private string _img;
        /// <summary>
        /// 이미지 기본 URL
        /// </summary>
        public string IMG { get { return _img; } }

        /// <summary>
        /// 닷컴 URL
        /// </summary>
        //public string WWW { get { return string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_MODETOUR); } }

        ///// <summary>
        ///// 호텔 URL
        ///// </summary>
        //public string Hotel { get { return string.Format("{0}://{1}{2}", _protocol, _current_domain, HostResource.PATH_HOTEL); } }

        ///// <summary>
        ///// XML 서버 URL
        ///// </summary>
        //public string XML { get { return string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_XML); } }

        ///// <summary>
        ///// 닷컴 API URL
        ///// </summary>
        //public string API { get { return string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_API); } }

        ///// <summary>
        ///// 전체 URL
        ///// </summary>
        //public string FullUrl { get { return Convert.ToString(HttpContext.Current.Request.Url); } }

        ///// <summary>
        ///// 클라이언트 IP
        ///// </summary>
        //public string ClientIP { get { return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; } }

        ///// <summary>
        ///// 서버 IP
        ///// </summary>
        //public string ServerIP { get { return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]; } }

        /// <summary>
        /// 닷컴 모바일 URL
        /// </summary>
        //public string ModetourMobile { get { return string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_MODETOURMOBILE); } }

        ///// <summary>
        ///// 닷컴 결제 URL
        ///// </summary>
        //public string ModetourPay { get { return string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_PAY_MODETOUR); } }

        ///// <summary>
        ///// 닷컴 결제 모바일 URL
        ///// </summary>
        //public string ModetourPayMobile { get { return string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_PAY_MODETOURMOBILE); } }

        /// <summary>
        /// 생성자
        /// </summary>
        public HostHelper()
        {
            //SetProtocol();
            //SetCurrentDomain();
            SetEnviroment();
            SetDomain();

            SetUrl();

            if (_current_domain.Equals("211.56.231.60"))
            {
                _environment_str = "";
                _environment_fiexed_str = "";
                _environment = HostEnvironmentType.Live;
                _domain = "m.modetour.com";
                _protocol = "http";
                _url = string.Format("{0}://m.modetour.com", _protocol, _current_domain, _current_port);
                _js = string.Format("{0}://{1}:{2}/js", _protocol, _current_domain, _current_port);
                _js2 = string.Format("{0}://{1}:{2}/js2", _protocol, _current_domain, _current_port);
                //_css = string.Format("{0}://{1}:{2}/include/css", _protocol, _current_domain, _current_port);
                _css = string.Format("{0}://{1}:{2}/css", _protocol, _current_domain, _current_port);
            }
        }

        //private void SetProtocol()
        //{
        //    _protocol = ModeUtils.Context.Request.Url.Scheme;
        //}

        /// <summary>
        /// 현재 도메인 정보 설정
        /// </summary>
        //private void SetCurrentDomain()
        //{
        //    _current_domain = ModeUtils.Context.Request.Url.Host.ToLower();
        //    _current_port = ModeUtils.Context.Request.Url.Port;
        //}

        /// <summary>
        /// 개발환경 정보 설정
        /// </summary>
        private void SetEnviroment()
        {
            if (_current_domain.Equals("172.17.52.108") || _current_domain.IndexOf("new") > -1)
            {
                _environment_str = "qa";
            }
            else
            {
                string reg = @"(?<frefix>.*?)-[\w]";
                Regex r = new Regex(reg, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                MatchCollection mc = r.Matches(_current_domain); // str은 처리할 스트링

                for (int i = 0; i < mc.Count; i++)
                {
                    Match m = mc[i];
                    _environment_str += m.Groups["frefix"].ToString();
                }

                if (Enum.GetNames(typeof(HostEnvironmentType)).Where(str => str.ToLower().Equals(_environment_str)).Count() == 0)
                {
                    _environment_str = string.Empty;
                }
            }

            if (!string.IsNullOrEmpty(_environment_str))
            {
                _environment_fiexed_str = string.Format("{0}-", _environment_str);
            }
        }

        /// <summary>
        /// 도메인 정보 설정
        /// </summary>
        private void SetDomain()
        {
            if (!string.IsNullOrEmpty(_environment_fiexed_str) && _current_domain.StartsWith(_environment_fiexed_str))
            {
                _domain = _current_domain.Replace(_environment_fiexed_str, string.Empty);
            }
            else
            {
                _domain = _current_domain;
            }
        }

        /// <summary>
        /// URL 정보 설정
        /// </summary>
        private void SetUrl()
        {
            _url = string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, _domain);
            _js = string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_JS);
            _js2 = string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_JS2);
            _css = string.Format("{0}://{1}{2}", _protocol, _environment_fiexed_str, HostResource.DOMAIN_CSS);
            _img = string.Format("{0}://{1}", _protocol, HostResource.DOMAIN_IMG);
        }

        /// <summary>
        /// URL 프로토콜 강제 설정
        /// </summary>
        /// <param name="getUrl">url</param>
        /// <param name="getType">true:https false:http</param>
        /// <returns></returns>
        public string ChangeSSL(string getUrl, bool getType)
        {
            string returnValue = "";
            string[] getUrlSplit = getUrl.Split(':');
            getUrlSplit[0] = getUrlSplit[0].ToLower();
            if (getType == true && getUrlSplit[0] == "http")
            {
                getUrlSplit[0] = "https";
            }
            else if (getType == false && getUrlSplit[0] == "https")
            {
                getUrlSplit[0] = "http";
            }
            returnValue = getUrlSplit[0];

            for (int i = 1; i < getUrlSplit.Length; i++)
            {
                returnValue += ":" + getUrlSplit[i];
            }
            return returnValue;
        }
    }
}
