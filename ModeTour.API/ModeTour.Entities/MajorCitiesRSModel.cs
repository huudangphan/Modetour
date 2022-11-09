using System.Xml.Serialization;

namespace ModeTour.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "MajorCities")]
    public class MajorCitiesRSModel
    {
        [XmlElement(ElementName = "Group")]
        public List<GroupModel> Group { get; set; }
    }
    public class GroupModel
    {
        /// <summary>
        /// 그룹Title
        /// </summary>
        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// 도시정보
        /// </summary>
        [XmlArray(ElementName = "Cities")]
        [XmlArrayItem(ElementName = "City")]
        public List<CityModel> CityInfo { get; set; }
    }
    public class CityModel
    {
        /// <summary>
        /// 공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "AirportCode")]
        public string AirportCode { get; set; }

        /// <summary>
        /// 공항명
        /// </summary>
        [XmlAttribute(AttributeName = "AirportKName")]
        public string AirportKName { get; set; }

        /// <summary>
        /// 도시코드
        /// </summary>
        [XmlAttribute(AttributeName = "CityCode")]
        public string CityCode { get; set; }

        /// <summary>
        /// 도시명
        /// </summary>
        [XmlAttribute(AttributeName = "CityKName")]
        public string CityKName { get; set; }

        /// <summary>
        /// 국가코드
        /// </summary>
        [XmlAttribute(AttributeName = "CountryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 국가명
        /// </summary>
        [XmlAttribute(AttributeName = "CountryKName")]
        public string CountryKName { get; set; }

        /// <summary>
        /// 지역번호
        /// </summary>
        [XmlAttribute(AttributeName = "AreaNum")]
        public int AreaNum { get; set; }

        /// <summary>
        /// 지역코드
        /// </summary>
        [XmlAttribute(AttributeName = "AreaCode")]
        public string AreaCode { get; set; }

        /// <summary>
        /// 지역명
        /// </summary>
        [XmlAttribute(AttributeName = "AreaName")]
        public string AreaName { get; set; }

        /// <summary>
        /// 출발공항코드
        /// </summary>
        [XmlAttribute(AttributeName = "DepCityCode")]
        public string DepCityCode { get; set; }

        /// <summary>
        /// 도시(공항)명
        /// </summary>
        [XmlText]
        public String TXT { get; set; }
    }

}
