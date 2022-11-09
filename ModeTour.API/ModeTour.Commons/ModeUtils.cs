using Microsoft.AspNetCore.Http;
using ModeTour.Commons.Helper;
using static ModeTour.Commons.Enums;

namespace ModeTour.Commons
{
    public class ModeUtils
    {
        static ModeUtils()
        {

        }

        private static HttpContext _context = null;
        /// <summary>
        /// HttpContext에 대한 Instance를 반환
        /// </summary>
        //public static HttpContext Context
        //{
        //    get
        //    {
        //        return HttpContent;
        //    }
        //}
        public static HttpContext Context { get; }
        private static readonly string _layout_version_key = "ModeUtilsLayoutVersion";
        private static LayoutVersionType _layout_version;
        /// <summary>
        /// 레이아웃 버전 정보
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// ModeUtils.LayoutVersion = LayoutVersionType.Old;
        /// ]]>
        /// </code>
        /// </example>
        //public static LayoutVersionType LayoutVersion
        //{
        //    set { _layout_version = value; }
        //    get
        //    {
        //        if (ModeUtils.Context.Items[_layout_version_key] == null)
        //        {
        //            ModeUtils.Context.Items[_layout_version_key] = _layout_version;

        //            if (!Enum.TryParse(ModeUtils.Context.Items[_layout_version_key].ToString(), out _layout_version))
        //            {
        //                _layout_version = LayoutVersionType.Old;
        //            }
        //        }
        //        return _layout_version;
        //    }
        //}

        /// <summary>
        /// ILayoutHelper에 대한 Instance를 반환
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// ModeUtils.LayoutVersion = LayoutVersionType.Old;
        /// ModeUtils.Layout.Option.MLoc = "02";
        /// ModeUtils.Layout.Option.Master = LayoutOptionMasterType.TF;
        /// 
        /// ltlTop.Text = ModeUtils.Layout.Data.Body.Top;
        /// ltlLeft.Text = ModeUtils.Layout.Data.Body.Left;
        /// ltlNavi.Text = ModeUtils.Layout.Data.Body.Navi;
        /// ltlRight.Text = ModeUtils.Layout.Data.Body.Right;
        /// ltlFooter.Text = ModeUtils.Layout.Data.Body.Footer;
        /// ]]>
        /// </code>
        /// </example>
        //public static ILayoutHelper Layout
        //{
        //    get
        //    {
        //        return (LayoutVersion == LayoutVersionType.New ? LayoutHelper.Instance : TempLayoutHelper.Instance);
        //    }
        //}

        /// <summary>
        /// RequestHelper에 대한 Instance를 반환
        /// </summary>
        /// <example>Request 값 가져오기
        /// <code>
        /// <![CDATA[
        /// ModeUtils.Request["data"];
        /// ]]>
        /// </code>
        /// </example>
        /// <example>Request Form 값 가져오기
        /// <code>
        /// <![CDATA[
        /// ModeUtils.Request.Form["data"];
        /// ]]>
        /// </code>
        /// </example>
        /// <example>Request QueryString 값 가져오기
        /// <code>
        /// <![CDATA[
        /// ModeUtils.Request.QueryString["data"];
        /// ]]>
        /// </code>
        /// </example>
        //public static RequestHelper Request { get { return RequestHelper.Instance; } }

        /// <summary>
        /// SiteHelper에 대한 Instance를 반환
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// 
        /// ]]>
        /// </code>
        /// </example>
        //public static SiteModel Site { get { return SiteHelper.Instance.Data; } }

        /// <summary>
        /// HostHelper에 대한 Instance를 반환
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// ModeUtils.Host.Url;
        /// ModeUtils.Host.JsUrl;
        /// ModeUtils.Host.ImgUrl;
        /// ModeUtils.Host.WWW;
        /// ModeUtils.Host.Hotel;
        /// ]]>
        /// </code>
        /// </example>
        public static HostHelper Host { get { return HostHelper.Instance; } }

        /// <summary>
        /// DBHelper에 대한 Instance를 반환
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///  ModeUtils.DB.ConnectionString = "ConnectionString";
        ///  ModeUtils.DB.Open();
        ///  ModeUtils.DB.SetProcedureName("SP_Procedure_Name");
        ///  ModeUtils.DB.SetParameter("@Name", "홍길동");
        ///  
        ///  ModeUtils.DB.Execute();
        /// 
        ///  ModeUtils.DB.ClearParameter();
        ///  ModeUtils.DB.Close();
        /// ]]>
        /// </code>
        /// </example>
        //public static DBHelper DB { get { return DBHelper.Instance; } }

        /// <summary>
        /// APIHelper에 대한 Instance를 반환
        /// </summary>
        public static APIHelper API { get { return APIHelper.Instance; } }



        /// <summary>
        /// Request 정보에 해당하는 기기정보 반환
        /// </summary>
        //public static DeviceType Device { get { return DeviceHelper.GetDeviceType(); } }


        /// <summary>
        /// VersionHelper에 대한 Instance를 반환
        /// </summary>
        //public static VersionHelper Version { get { return VersionHelper.Instance; } }
    }
}
