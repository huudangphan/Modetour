using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Xml;
using static ModeTour.Commons.Enums;

namespace ModeTour.Commons.Helper
{
    public class APIHelper
    {
        private static string _key = "ModeAPISingleton";

        /// <summary>
        /// TempLayoutHelper Singleton Instance : 웹요청시마다 생성
        /// </summary>
        public static APIHelper Instance
        {
            get
            {
                if (ModeUtils.Context.Items[_key] == null)
                {
                    ModeUtils.Context.Items[_key] = new APIHelper();
                }

                return ModeUtils.Context.Items[_key] as APIHelper;
            }
        }


        private ResultModel _result = new ResultModel();
        /// <summary>
        /// 결과정보
        /// </summary>
        public ResultModel Result { get { return _result; } }

        /// <summary>
        /// content-type 추가 설정정보(ContentType.Xml인 경우 application/x-www-form-urlencoded; 기본 설정)
        /// </summary>
        public string ContentOption { set; get; }

        public string ContentTypeFull { set; get; }

        /// <summary>
        /// 요청이 시간 초과하기 전까지 기다리는 시간(밀리초)입니다. 기본값은 100,000밀리초(100초)입니다.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 문서 타입 : XML | JSON
        /// </summary>
        public APIContentType ContentType { set; get; }

        /// <summary>
        /// 요청 타입 : GET | POST(DEFAULT)
        /// </summary>
        public APIRequestType RequestType { set; get; }

        /// <summary>
        /// 인코딩 타입 : UTF8(DEFAULT) | EUCKR
        /// </summary>
        public APIEncodingType EncodingType { set; get; }

        /// <summary>
        /// 주소
        /// </summary>
        public string Url { set; get; }

        /// <summary>
        /// 메소드
        /// </summary>
        public string Method { set; get; }

        /// <summary>
        /// 전송데이터
        /// </summary>
        public string Data { set; get; }

        private WebHeaderCollection _header = new WebHeaderCollection();
        /// <summary>
        /// 헤더정보
        /// </summary>
        public WebHeaderCollection Header { set { _header = value; } get { return _header; } }

        private CookieContainer _cookie = new CookieContainer();
        /// <summary>
        /// 쿠키정보
        /// </summary>
        public CookieContainer Cookie { set { _cookie = value; } get { return _cookie; } }

        private bool _is_cert = false;
        /// <summary>
        /// 인증정보 설정여부
        /// </summary>
        public bool IsCert { set { _is_cert = value; } get { return _is_cert; } }
        private const string INDENT_STRING = "    ";

        /// <summary>
        /// 생성자
        /// </summary>
        public APIHelper()
        {
            Clear();
            ContentType = APIContentType.XML;
            RequestType = APIRequestType.POST;
            Url = string.Empty;
            Method = string.Empty;
            Data = string.Empty;
        }

        /// <summary>
        /// API 호출
        /// </summary>
        public void Call()
        {
            if (Result.Code != "-1") return;

            try
            {
                //통신 Protocol 지정
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                string url = GetUrl();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetUrl());

                try
                {
                    string result = string.Empty;

                    request.UserAgent = "Mozilla/5.0";
                    request.KeepAlive = false;
                    //request.Timeout = Timeout;

                    if (string.IsNullOrWhiteSpace(ContentTypeFull))
                    {
                        request.ContentType = string.Format("{0} charset={1};", GetContentType(ContentType), GetEncodingType(EncodingType));
                        //request.Accept = GetContentType(ContentType); //오류로 주석처리(2017.05.30)
                    }
                    else
                    {
                        request.ContentType = ContentTypeFull;
                    }

                    request.Method = GetRequestType(RequestType);
                    if (_header.Count > 0)
                    {
                        request.Headers = Header;
                    }

                    //
                    //request.CookieContainer = Cookie;
                    request.UseDefaultCredentials = IsCert;

                    if (RequestType == APIRequestType.POST)
                    {
                        Encoding encoding = Encoding.GetEncoding(GetEncodingType(EncodingType));
                        byte[] data = encoding.GetBytes(Data);
                        request.ContentLength = data.Length;

                        Stream stream = request.GetRequestStream();
                        stream.Write(data, 0, data.Length);
                        stream.Close();
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(GetEncodingType(EncodingType)));
                    result = reader.ReadToEnd().Trim();

                    _result.Data = result;
                    _result.Code = "0";
                    _result.Msg = "success";
                }
                catch (WebException ex1)
                {
                    _result.Code = ex1.HResult.ToString();
                    _result.Msg = ex1.Message;
                    if (ex1.Status == WebExceptionStatus.ProtocolError)
                    {
                        HttpWebResponse response = ex1.Response as HttpWebResponse;
                        if (response != null)
                        {
                            _result.Code = ((int)response.StatusCode).ToString();
                            _result.Msg = response.StatusDescription;
                        }
                    }

                    _result.Data = ex1.ToString();

                    SetExeption("Call", ex1);
                }
            }
            catch (Exception ex)
            {
                _result.Code = ex.HResult.ToString();
                _result.Msg = ex.Message;
                _result.Data = ex.ToString();

                SetExeption("Call", ex);
            }
        }

        /// <summary>
        /// API 호출 상태 초기화
        /// </summary>
        public void Clear()
        {
            //호출대기상태
            Result.Code = "-1";
            Result.Msg = "Wait";
        }

        /// <summary>
        /// 요청에 대한 응답값 XML 문서 반환
        /// </summary>
        /// <returns>XmlDocument</returns>
        public XmlDocument GetXml()
        {
            Call();

            XmlDocument result;

            try
            {
                result = new XmlDocument();
                result.LoadXml(Result.Data.ToString());
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// URL 정보 가져오기
        /// </summary>
        /// <returns>string</returns>
        public string GetUrl()
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(Method))
            {
                result = Url;
            }
            else
            {
                result = string.Format("{0}/{1}", Url, Method);
            }

            if (!string.IsNullOrEmpty(Data) && RequestType == APIRequestType.GET)
            {
                result = string.Format("{0}?{1}", result, Data);
            }

            return result;
        }

        /// <summary>
        /// 요청문서타입 정보 가져오기
        /// </summary>
        /// <param name="type"></param>
        /// <returns>string</returns>
        public string GetContentType(APIContentType type)
        {
            string result;

            //문서타입이 XML이고, 문서옵션 정보가 설정되어 있지 않으면 기본설정
            if (type == APIContentType.XML && string.IsNullOrEmpty(ContentOption))
            {
                ContentOption = "application/x-www-form-urlencoded;";
            }

            switch (type)
            {
                case APIContentType.XML:
                    result = "text/xml;"; break;
                case APIContentType.JSON:
                    result = "application/json;"; break;
                default:
                    result = string.Empty; break;
            }

            return string.Format("{0} {1}", ContentOption, result);
        }

        /// <summary>
        /// 요청타입 정보 가져오기
        /// </summary>
        /// <param name="type"></param>
        /// <returns>string</returns>
        public string GetRequestType(APIRequestType type)
        {
            string result;

            switch (type)
            {
                case APIRequestType.GET:
                    result = "GET"; break;
                case APIRequestType.PUT:
                    result = "PUT"; break;
                case APIRequestType.DELETE:
                    result = "DELETE"; break;
                default:
                    result = "POST"; break;
            }

            return result;
        }

        /// <summary>
        /// 인코딩 정보 가져오기
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetEncodingType(APIEncodingType type)
        {
            string result;

            switch (type)
            {
                case APIEncodingType.UTF8:
                    result = "utf-8"; break;
                case APIEncodingType.EUCKR:
                    result = "euc-kr"; break;
                default:
                    result = "utf-8"; break;
            }

            return result;
        }

        /// <summary>
        /// 예외정보 설정
        /// </summary>
        /// <param name="method"></param>
        /// <param name="ex"></param>
        public void SetExeption(string method, Exception ex)
        {
            ex.Data.Add("API_ContentType", ContentType.ToString());
            ex.Data.Add("API_RequestType", RequestType.ToString());
            ex.Data.Add("API_Url", Url);
            ex.Data.Add("API_Method", Method);
            ex.Data.Add("API_Data", Data);
            ex.Data.Add("API_Result", Result.ToString());

        }
        public static object PostData<TEntity>(TEntity model, string url)
        {
            try
            {
                string postData = JsonConvert.SerializeObject(model);
                string strUrl = String.Format(url);
                WebRequest request = WebRequest.Create(strUrl);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                    var response = request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        //result = result.ToString().Replace("\"", " ");                      

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return null;
            }
        }

        #region -- STATIC METHOD : S

        /// <summary>
        /// API 호출
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentType"></param>
        /// <param name="encodingType"></param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// APIHelper.Call();
        /// ]]>
        /// </code>
        /// </example>
        public static ResultModel Call(string url, APIContentType contentType, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET, string contentOption = "")
        {
            return Call(url, string.Empty, contentType, encodingType, requestType, contentOption);
        }

        /// <summary>
        /// API호출
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="encodingType"></param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public static ResultModel Call(string url, string data, APIContentType contentType, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET, string contentOption = "")
        {
            return Call(url, string.Empty, data, contentType, encodingType, requestType, contentOption);
        }

        /// <summary>
        /// API 호출
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="encodingType"></param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public static ResultModel Call(string url, string method, string data, APIContentType contentType, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET, string contentOption = "")
        {
            APIHelper api = new APIHelper();
            api.Url = url;
            api.Method = method;
            api.Data = data;
            api.ContentType = contentType;
            api.ContentOption = contentOption;
            api.EncodingType = encodingType;
            api.RequestType = requestType;
            api.Call();

            return api.Result;
        }

        #endregion -- STATIC METHOD : E
        public static HttpResult ConvertJsonToObject(string json)
        {
            try
            {
                HttpResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResult>(Functions.ToString(json));
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static ResultModel ConvertJsonToObjectx(string json)
        {
            try
            {
                ResultModel result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(Functions.ToString(json));
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public static object ConvertJsonToObject(string json, Type type)
        {
            try
            {
                object result = Newtonsoft.Json.JsonConvert.DeserializeObject(Functions.ToString(json), type);
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }

    public enum APIContentType
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE,
        /// <summary>
        /// XML
        /// </summary>
        XML,
        /// <summary>
        /// Json
        /// </summary>
        JSON,
        /// <summary>
        /// 문자열
        /// </summary>
        STRING,
        /// <summary>
        /// HTML
        /// </summary>
        HTML
    }
    public enum APIRequestType
    {
        /// <summary>
        /// GET
        /// </summary>
        GET,
        /// <summary>
        /// POST
        /// </summary>
        POST,
        /// <summary>
        /// PUT
        /// </summary>
        PUT,
        /// <summary>
        /// DELETE
        /// </summary>
        DELETE
    }


}
