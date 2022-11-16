using System.ComponentModel.DataAnnotations;

namespace ModeTour.Entities.Air
{
    public class SearchFareAvailSimpleRQModel
    {
        [Required]
        public int SNM { get; set; }

        /// <summary>
        /// 항공사 코드(하나 이상일 경우 콤마로 구분)
        /// </summary>
        public string SAC { get; set; }

        /// <summary>
        /// 출발지 공항 코드
        /// </summary>
        [Required]
        public string DLC { get; set; }

        /// <summary>
        /// 도착지 공항 코드
        /// </summary>
        [Required]
        public string ALC { get; set; }

        /// <summary>
        /// 구간(OW:편도, RT:왕복, DT:출도착이원구간, MD:다구간)
        /// </summary>
        [Required]
        public string ROT { get; set; }

        /// <summary>
        /// 출발일 (YYYYMMDD)
        /// </summary>
        [Required]
        public string DTD { get; set; }

        /// <summary>
        /// 도착일(오픈일 경우 공백 또는 7D/14D/45D/1M/2M/3M/6M/300D 중 하나 입력)
        /// </summary>
        [Required]
        public string ARD { get; set; }

        /// <summary>
        /// 캐빈 클래스(Y:Economic, M:Economic Standard, W:Economic Premium, C:Business, F:First/Supersonic)
        /// </summary>
        public string CCD { get; set; }

        /// <summary>
        /// 직항여부(Y/N)
        /// </summary>
        [Required]
        public string DRT { get; set; }

        /// <summary>
        /// 성인
        /// </summary>
        [Required]
        public int ADC { get; set; }

        /// <summary>
        /// 소아
        /// </summary>
        [Required]
        public int CHC { get; set; }

        /// <summary>
        /// 유아
        /// </summary>
        [Required]
        public int IFC { get; set; }

        /// <summary>
        /// 응답 결과 수
        /// </summary>
        [Required]
        public int NRR { get; set; }

        /// <summary>
        /// 요청단말기(WEB/MOBILEWEB/MOBILEAPP/CRS/MODEWARE)
        /// </summary>
        [Required]
        public string RQT { get; set; }
    }
}
