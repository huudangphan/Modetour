using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using static ModeTour.Commons.Enums;

namespace ModeTour.Commons.Helper
{
    public static class XmlHelper
    {
        public static string ConvertString(object obj)
        {
            string result = string.Empty;

            if (obj.GetType() == typeof(string))
            {
                result = obj.ToString();
            }
            else
            {
                var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(obj.GetType());
                var setting = new XmlWriterSettings();
                setting.Indent = true;
                setting.OmitXmlDeclaration = true;
                using (StringWriter stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, setting))
                {
                    serializer.Serialize(writer, obj, ns);
                    result = stream.ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="elemname"></param>
        /// <returns></returns>
        public static string ConvertString(object obj, string elemname)
        {
            string result = string.Empty;

            if (obj.GetType() == typeof(string))
            {
                result = obj.ToString();
            }
            else
            {
                var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(obj.GetType(), new XmlRootAttribute(elemname));
                var setting = new XmlWriterSettings();
                setting.Indent = true;
                setting.OmitXmlDeclaration = true;
                using (StringWriter stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, setting))
                {
                    serializer.Serialize(writer, obj, ns);
                    result = stream.ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// Xml문자열을 해당 Type의 object로 변환
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ConvertObject(string xml, Type type)
        {
            object result = new object();

            try
            {
                var serializer = new XmlSerializer(type);
                using (TextReader reader = new StringReader(xml))
                {
                    result = serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {

                result = null;
            }

            return result;
        }

        /// <summary>
        /// XML 문서 만들기
        /// </summary>
        /// <param name="xml"></param>
        //public static void Response(string xml)
        //{
        //    HttpContext.Current.Session.CodePage = 65001;
        //    HttpContext.Current.Response.Charset = "UTF-8";
        //    HttpContext.Current.Response.ContentType = "text/xml";

        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.Write(xml);

        //    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
        //    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();//현재의 요청을 정리한다.
        //}

        /// <summary>
        /// XML 문서 만들기
        /// </summary>
        /// <param name="obj"></param>
        //public static void Response(object obj)
        //{
        //    Response(ConvertString(obj));
        //}

        /// <summary>
        /// XML 문서 가져오기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static XmlDocument Load(string path, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET)
        {
            return Load(path, string.Empty, string.Empty, encodingType, requestType);
        }

        /// <summary>
        /// XML 문서 가져오기
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static XmlDocument Load(string path, string data, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET)
        {
            return Load(path, string.Empty, data, encodingType, requestType);
        }

        /// <summary>
        /// XML 문서 가져오기
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static XmlDocument Load(string path, string method, string data, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET)
        {
            ResultModel result = APIHelper.Call(path, method, data, APIContentType.XML, encodingType, requestType);

            XmlDocument doc = null;
            if (result.Code == "0")
            {
                doc = new XmlDocument();
                doc.LoadXml(result.Data.ToString());
            }

            return doc;
        }

        public static string Load(string xmlUrl, string method, string data, string xslUrl, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET)
        {
            XmlDocument doc = Load(xmlUrl, method, data, encodingType, requestType);

            return Load(doc, xslUrl);
        }

        public static string Load(XmlDocument doc, string xslUrl, APIEncodingType encodingType = APIEncodingType.UTF8, APIRequestType requestType = APIRequestType.GET)
        {
            string result = string.Empty;

            StringWriter xmlTransWriter = new StringWriter();
            XslCompiledTransform xslDoc = new XslCompiledTransform();
            xslDoc.Load(xslUrl, XsltSettings.Default, new XmlUrlResolver());
            xslDoc.Transform((IXPathNavigable)doc, null, xmlTransWriter);

            result = xmlTransWriter.ToString();

            xmlTransWriter.Close();
            xmlTransWriter.Dispose();

            return result;
        }
    }
}
