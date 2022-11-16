namespace ModeTour.Entities.Air
{
    public class AirportDSModel
    {
        /// <summary>
        /// 공항코드
        /// </summary>
        public string AirportCode { get; set; }

        /// <summary>
        /// 공항명(영문)
        /// </summary>
        public string AirportName { get; set; }

        /// <summary>
        /// 공항명2(상세)
        /// </summary>
        public string AirportName2 { get; set; }

        /// <summary>
        /// 공항명(한글)
        /// </summary>
        public string AirportKorName { get; set; }

        /// <summary>
        /// 도시코드
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 도시명(영문)
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 도시명(한글)
        /// </summary>
        public string CityKorName { get; set; }

        /// <summary>
        /// 국가코드
        /// </summary>
        public string NationCode { get; set; }

        /// <summary>
        /// 지역코드
        /// </summary>
        public string AreaCode { get; set; }
    }
}
