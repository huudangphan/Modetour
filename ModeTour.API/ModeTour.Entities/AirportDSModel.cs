namespace ModeTour.Entities
{
    public class AirportDSModel
    {
        /// <summary>
        /// 공항코드
        /// </summary>
        public String AirportCode { get; set; }

        /// <summary>
        /// 공항명(영문)
        /// </summary>
        public String AirportName { get; set; }

        /// <summary>
        /// 공항명2(상세)
        /// </summary>
        public String AirportName2 { get; set; }

        /// <summary>
        /// 공항명(한글)
        /// </summary>
        public String AirportKorName { get; set; }

        /// <summary>
        /// 도시코드
        /// </summary>
        public String CityCode { get; set; }

        /// <summary>
        /// 도시명(영문)
        /// </summary>
        public String CityName { get; set; }

        /// <summary>
        /// 도시명(한글)
        /// </summary>
        public String CityKorName { get; set; }

        /// <summary>
        /// 국가코드
        /// </summary>
        public String NationCode { get; set; }

        /// <summary>
        /// 지역코드
        /// </summary>
        public String AreaCode { get; set; }
    }
}
