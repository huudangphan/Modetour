using System.ComponentModel.DataAnnotations;

namespace ModeTour.Entities.Air
{
    public class FXLDowngradeRQModel
    {
        /// <summary>
        /// 요금조회 결과 중 선택된 <priceIndex>~</priceIndex> XmlNode(segGroup는 제외)
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
        /// 요청단말기(WEB/MOBILEWEB/MOBILEAPP/CRS/MODEWARE)
        /// </summary>
        [Required]
        public String RQT { get; set; }
    }
}
