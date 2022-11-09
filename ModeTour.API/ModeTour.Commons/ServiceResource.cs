namespace ModeTour.Commons;

public class ServiceResource
{
    public class Config
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AirService.asmx";
        public static readonly string LIVE = "http://configservice.modetour.com/AirService.asmx";
    }

    /// <summary>
    /// 해외항공
    /// </summary>
    public class Overseas
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AirService.asmx";
        public static readonly string LIVE = "http://airservice2.modetour.com/AirService.asmx";
    }

    /// <summary>
    /// 해외항공 Version2
    /// </summary>
    public class Overseas2
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AirService2.asmx";
        public static readonly string LIVE = "http://airservice2.modetour.com/AirService2.asmx";
    }

    public class AvailOverseas2
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AirService2.asmx";
        public static readonly string LIVE = "http://airavailservice2.modetour.com/airservice2.asmx";
    }

    /// <summary>
    /// 해외항공 Version3
    /// </summary>
    public class Overseas3
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AirService3.asmx";
        public static readonly string LIVE = "http://airservice2.modetour.com/AirService3.asmx";
    }

    public class AvailOverseas3
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AirService3.asmx";
        public static readonly string LIVE = "http://airavailservice2.modetour.com/airservice3.asmx";
    }

    /// <summary>
    /// (제휴)해외항공
    /// </summary>
    public class AllianceOverseas
    {
        public static readonly string DEV = "http://172.30.52.110:8202/AllianceService.asmx";
        public static readonly string LIVE = "http://airservice2.modetour.com/AllianceService.asmx";
    }

    /// <summary>
    /// 국내항공
    /// </summary>
    public class Domestic
    {
        public static readonly string DEV = "http://172.30.52.110:8201/AirDomestic.asmx";
        public static readonly string LIVE = "http://airdomservice2.modetour.com/AirDomestic.asmx";
    }

    /// <summary>
    /// (제휴)국내항공
    /// 
    /// </summary>
    public class AllianceDomestic
    {
        public static readonly string DEV = "http://172.30.52.110:8201/AllianceService.asmx";
        public static readonly string LIVE = "http://airdomavailservice2.modetour.com/AllianceService.asmx"; //스케줄조회, 랜딩
    }

    public class ApiDomestic
    {
        public static readonly string DEV = "http://172.30.52.110:8092/api/";
        public static readonly string LIVE = "http://credit.modetour.com/api/";
    }
    /// <summary>
    /// (제휴) 올윈 부가서비스
    /// </summary>
    public class Allwin
    {
        public static readonly string DEV = "http://172.30.52.110:8088/Air/Allwin.asmx";
        public static readonly string LIVE = "https://webservice.modetour.com/Air/Allwin.asmx";
    }
}
