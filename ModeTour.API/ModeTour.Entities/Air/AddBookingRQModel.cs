using System.ComponentModel.DataAnnotations;

namespace ModeTour.Entities.Air
{
    public class AddBookingRQModel
    {
        /// <summary>
        /// 탑승객PTID
        /// </summary>
        public string[] PID { get; set; }

        /// <summary>
        /// 탑승객 타입 코드 (ADT/CHD/INF/STU/LBR..)
        /// </summary>
        [Required]
        public string[] PTC { get; set; }

        /// <summary>
        /// 탑승객 타이틀 (MR/MRS/MS/MSTR/MISS)
        /// </summary>
        [Required]
        public string[] PTL { get; set; }

        /// <summary>
        /// 탑승객 한글이름
        /// </summary>
        [Required]
        public string[] PHN { get; set; }

        /// <summary>
        /// 탑승객 영문성 (SurName)
        /// </summary>
        [Required]
        public string[] PSN { get; set; }

        /// <summary>
        /// 탑승객 영문이름 (First Name)
        /// </summary>
        [Required]
        public string[] PFN { get; set; }

        /// <summary>
        /// 탑승객 생년월일yyyyMMdd (소아,유아일 경우 필수)
        /// </summary>
        [Required]
        public string[] PBD { get; set; }

        /// <summary>
        /// 탑승객 전화번호
        /// </summary>
        public string[] PTN { get; set; }

        /// <summary>
        /// 탑승객 휴대폰
        /// </summary>
        public string[] PMN { get; set; }

        /// <summary>
        /// 탑승객 이메일주소
        /// </summary>
        public string[] PEA { get; set; }

        /// <summary>
        /// 탑승객 회원구분 (01:정회원, 02:웹회원, 03:투어마일리지회원)
        /// </summary>
        public string[] PMC { get; set; }

        /// <summary>
        /// 탑승객 투어마일리지 카드번호
        /// </summary>
        public string[] PMT { get; set; }

        /// <summary>
        /// 탑승객 투어마일리지 적립 요청여부
        /// </summary>
        public string[] PMR { get; set; }

        /// <summary>
        /// 탑승객 탑승객 여권정보 (여권번호|여권만료일|발행국|국적) 2021.08.25 추가
        /// </summary>
        public string[] PAI { get; set; }

        /// <summary>
        /// 예약자 PTID
        /// </summary>
        public string RID { get; set; }

        /// <summary>
        /// 예약자 타이틀 (MR/MS) --passenger title(MR/MS)
        /// </summary>
        [Required]
        public string RTL { get; set; }

        /// <summary>
        /// 예약자 한글이름 --Korea name
        /// </summary>
        [Required]
        public string RHN { get; set; }

        /// <summary>
        /// 예약자 영문성 (SurName) --English Name(Sur name)
        /// </summary>
        [Required]
        public string RSN { get; set; }

        /// <summary>
        /// 예약자 영문이름 (First Name) --English Name(First name)
        /// </summary>
        [Required]
        public string RFN { get; set; }

        /// <summary>
        /// 예약자 생년월일 yyyy-MM-dd --Date of birth yyyyMMdd
        /// </summary>
        [Required]
        public string RDB { get; set; }

        /// <summary>
        /// 예약자 성별 (M:남성, F:여성)
        /// </summary>
        [Required]
        public string RGD { get; set; }

        /// <summary>
        /// 예약자 내/외국인 여부 (L:내국인, F:외국인)  --The person making the reservation is a domestic/foreigner (L: Korean, F: Foreigner)
        /// </summary>
        [Required]
        public string RLF { get; set; }

        /// <summary>
        /// 예약자 전화번호   --Reservation phone number
        /// </summary>
        [Required]
        public string RTN { get; set; }

        /// <summary>
        /// 예약자 휴대폰  --mobile phone reservation
        /// </summary>
        [Required]
        public string RMN { get; set; }

        /// <summary>
        /// 예약자 이메일주소  --email
        /// </summary>
        [Required]
        public string REA { get; set; }

        /// <summary>
        /// 요청사항  --requirement
        /// </summary>
        public string RMK { get; set; }

        /// <summary>
        /// 요청단말기(WEB/MOBILEWEB/MOBILEAPP/CRS/MODEWARE) -- devide(WEB/MOBILEWEB/MOBILEAPP/CRS/MODEWARE)
        /// </summary>
        [Required]
        public string RQT { get; set; }

        /// <summary>
        /// 요청URL  -- URL request
        /// </summary>
        [Required]
        public string RQU { get; set; }

        /// <summary>
        /// 웹사이트 번호  -- Web number
        /// </summary>
        [Required]
        public string SNM { get; set; }

        /// <summary>
        /// 거래처번호 -- account number
        /// </summary>
        [Required]
        public string ANM { get; set; }

        /// <summary>
        /// 거래처직원번호 --   Number of customer staff
        /// </summary>
        public string AEN { get; set; }

        /// <summary>
        /// 구간(OW:편도, RT:왕복, DT:출도착이원구간, MD:다구간)  --   Segment(OW: one-way, RT: round trip, DT: two-way to and from, MD: multiple segments)
        /// </summary>
        [Required]
        public string ROT { get; set; }

        /// <summary>
        /// 오픈여부(귀국일미지정)  -- Open or not(return date not specified)
        /// </summary>
        [Required]
        public string OPN { get; set; }

        /// <summary>
        /// 요금조회 결과 중 선택된 <priceIndex>~</priceIndex> XmlNode(segGroup는 제외)
        /// </summary>
        [Required]
        public string FXL { get; set; }

        /// <summary>
        /// 선택한 여정을 <itinerary>~</itinerary>노드에 삽입한 XmlNode
        /// </summary>
        [Required]
        public string SXL { get; set; }

        /// <summary>
        /// 요금규정 XmlNode
        /// </summary>
        [Required]
        public string RXL { get; set; }

        /// <summary>
        /// 할인항공일 경우 선택된 <fare>~</fare> XmlNode  --    Selected for discount airlines
        /// </summary>
        public string DXL { get; set; }

        /// <summary>
        /// 제휴정보   --link information
        /// </summary>
        public string AKY { get; set; }

        private string _atsf = "Y";
        /// <summary>
        /// 발권대행수수료 적용 여부(Y/N)
        /// </summary>
        /// <value>Y</value>
        public string ATSF { get { return _atsf; } set { _atsf = value; } }

        private string _ftx = "";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string FTX { get { return _ftx; } set { _ftx = value; } }

        /// <summary>
        /// 쿠키
        /// </summary>
        public string COOKIE { get; set; }

        /// <summary>
        /// ADDR - 체류지 정보 (방문국가|상세주소|도시|주|우편번호)
        /// </summary>
        public string ADDR { get; set; }
    }
}
