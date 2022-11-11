using System.ComponentModel.DataAnnotations;

namespace ModeTour.Entities
{
    public class SearchRule3RQModel
    {
        /// <summary>
        /// 웹사이트 번호 --website number
        /// </summary>
        [Required]
        public int SNM { get; set; }

        public string SAC { get; set; }

        /// <summary>
        /// 선택한 여정을 <itinerary>~</itinerary>노드에 삽입한 XmlNode --selected itinerary
        /// </summary>
        [Required]
        public string SXL { get; set; }

        /// <summary>
        /// 요금조회 결과 중 선택된 <priceIndex>~</priceIndex> XmlNode(segGroup는 제외) --Selected from rate survey results

        /// </summary>
        [Required]
        public string FXL { get; set; }

        /// <summary>
        /// FREF  -  REF
        /// </summary>
        [Required]
        public string FREF { get; set; }

        /// <summary>
        /// FGID - GUID
        /// </summary>
        [Required]
        public string FGID { get; set; }

        /// <summary>
        /// 요청단말기(WEB/MOBILEWEB/MOBILEAPP/CRS/MODEWARE) --devide type
        /// </summary>
        [Required]
        public string RQT { get; set; }
    }
}
