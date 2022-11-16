using System.Xml.Serialization;

namespace ModeTour.Entities.Air
{
    [Serializable]
    [XmlRoot(ElementName = "ResponseDetails")]
    public class SearchBookingRSModel
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "timeStamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// 예약 기본 정보
        /// </summary>
        [XmlElement(ElementName = "bookingInfo")]
        public InfoModel Booking { get; set; }

        /// <summary>
        /// 여정 정보
        /// </summary>
        [XmlArray(ElementName = "flightInfo")]
        [XmlArrayItem(ElementName = "segGroup")]
        public List<SegGroupModel> FlightInfo { get; set; }

        /// <summary>
        /// 탑승객 정보
        /// </summary>
        [XmlArray(ElementName = "travellerInfo")]
        [XmlArrayItem(ElementName = "paxData")]
        public List<TravellerModel> Traveller { get; set; }

        /// <summary>
        /// 탑승객 타입별 요금 정보(1인 기준)
        /// </summary>
        [XmlArray(ElementName = "fareInfo")]
        [XmlArrayItem(ElementName = "fare")]
        public List<FareModel> Fare { get; set; }

        /// <summary>
        /// 부가서비스
        /// </summary>
        [XmlElement(ElementName = "supplementaryService")]
        public SupplementaryServiceModel SupplementaryService { get; set; }

        /// <summary>
        /// 예약자 정보
        /// </summary>
        [XmlElement(ElementName = "attn")]
        public OrderModel Order { get; set; }

        /// <summary>
        /// 담당여행사 정보
        /// </summary>
        [XmlElement(ElementName = "agent")]
        public AgentModel Agent { get; set; }

        /// <summary>
        /// 결제요청 등록 정보
        /// </summary>
        [XmlElement(ElementName = "paymentReqInfo")]
        public PaymentReqInfoModel PaymentReqInfo { get; set; }

        /// <summary>
        /// 결제 정보
        /// </summary>
        [XmlElement(ElementName = "paymentInfo")]
        public PaymentModel Payment { get; set; }

        /// <summary>
        /// 증빙서류 정보
        /// </summary>
        //[XmlIgnore]
        [XmlElement(ElementName = "proofInfo")]
        public ProofModel Proof { get; set; }
    }
    public class InfoModel
    {
        /// <summary>
        /// Vendor 약자
        /// </summary>
        [XmlElement(ElementName = "gds")]
        public string GDS { get; set; }

        /// <summary>
        /// Vendor 예약번호
        /// </summary>
        [XmlElement(ElementName = "bookingNo")]
        public BookingNo BookingNo { get; set; }

        /// <summary>
        /// 모두투어 예약번호
        /// </summary>
        [XmlElement(ElementName = "modeBookingNo")]
        public long ModeBookingno { get; set; }

        string AgentBookingNo = "";
        /// <summary>
        /// 거래처 예약번호
        /// </summary>        
        [XmlElement(ElementName = "agentBookingNo")]
        public string agentBookingNo { set { AgentBookingNo = value; } get { return AgentBookingNo; } }

        string AllianceBookingNo = "";
        /// <summary>
        /// 거래처 예약번호
        /// </summary>
        [XmlElement(ElementName = "allianceBookingNo")]
        public string allianceBookingNo { set { AllianceBookingNo = value; } get { return AllianceBookingNo; } }

        /// <summary>
        /// 예약일시
        /// </summary>
        [XmlElement(ElementName = "bookingCreationDate")]
        public string CreationDate { get; set; }

        /// <summary>
        /// 예약상태
        /// </summary>
        [XmlElement(ElementName = "bookingStatus")]
        public BookingStatus Status { get; set; }

        /// <summary>
        /// 예약좌석
        /// </summary>
        [XmlElement(ElementName = "bookingClass")]
        public BookingClass Seat { get; set; }

        /// <summary>
        /// 마케팅항공사
        /// </summary>
        [XmlElement(ElementName = "bookingAirline")]
        public BookingAirLine AirLine { get; set; }

        /// <summary>
        /// 여정
        /// </summary>
        [XmlElement(ElementName = "bookingRtg")]
        public BookingRtg Rtg { get; set; }

        /// <summary>
        /// 요금규정
        /// </summary>
        [XmlElement(ElementName = "bookingRuleId")]
        public BookingRuleId RuleId { get; set; }

        /// <summary>
        /// 승객유형(요금조건)
        /// </summary>
        [XmlElement(ElementName = "paxType")]
        public BookingPaxType PaxType { get; set; }

        /// <summary>
        /// 유효기간(최대체류기간)
        /// </summary>
        [XmlElement(ElementName = "expiryDate")]
        public BookingExpiryDate ExpiryDate { get; set; }

        /// <summary>
        /// 최종발권시한
        /// </summary>
        [XmlElement(ElementName = "bookingTL")]
        public BookingTL TL { get; set; }

        /// <summary>
        /// 요금정보
        /// </summary>
        [XmlElement(ElementName = "bookingAmount")]
        public BookingAmount Amount { get; set; }
    }

    public class BookingRuleId
    {
        /// <summary>
        /// 증빙서류 필요여부(공백일 경우 담당자 확인 필요)
        /// Y|N|EMPTY(N)
        /// </summary>
        [XmlAttribute(AttributeName = "proof")]
        public string NeedYN { get; set; }

        [XmlText]
        public string RuleId { get; set; }
    }

    public class BookingNo
    {
        /// <summary>
        /// 알파벳 형태의 PNR
        /// </summary>
        [XmlAttribute(AttributeName = "pnr")]
        public string PNR { get; set; }

        /// <summary>
        /// 숫자 형태의 PNR
        /// </summary>
        [XmlText]
        public string PNRNumber { get; set; }

    }

    public class BookingStatus
    {
        /// <summary>
        /// 예약상태코드(HK:확약, HL:대기, TK:스케쥴변경, UC:불가, XX:취소)
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 2018.08.31 여권정보등록여부
        /// </summary>
        [XmlAttribute(AttributeName = "passport")]
        public string PassportYN { get; set; }

        /// <summary>
        /// 아피스입력여부
        /// </summary>
        [XmlAttribute(AttributeName = "apis")]
        public string Apis { get; set; }

        /// <summary>
        /// 발권완료여부
        /// </summary>
        [XmlAttribute(AttributeName = "issue")]
        public string Issue { get; set; }

        /// <summary>
        /// ESTA 비자 신청 가능여부(Y|N)
        /// </summary>
        [XmlAttribute(AttributeName = "esta")]
        public string Esta { get; set; }

        /// <summary>
        /// 캐나다 ETA 비자 신청 가능여부(Y|N)
        /// </summary>
        [XmlAttribute(AttributeName = "eta")]
        public string Eta { get; set; }

        /// <summary>
        /// 환불 여부(W:전체, P:부분, 공백:환불없음)
        /// </summary>
        [XmlAttribute(AttributeName = "refund")]
        public string Refund { get; set; }

        /// <summary>
        /// 미주/캐나다 여부(Y|N)
        /// </summary>
        [XmlAttribute(AttributeName = "usa")]
        public string USA { get; set; }

        /// <summary>
        /// 예약상태설명
        /// </summary>
        [XmlText]
        public string Status { get; set; }
    }

    public class BookingClass
    {
        /// <summary>
        /// 좌석코드(Y:일반석, C:비즈니스석, F:일등석) 
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 좌석설명
        /// </summary>
        [XmlText]
        public string Class { get; set; }
    }

    public class BookingAirLine
    {
        /// <summary>
        /// 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 항공사명
        /// </summary>
        [XmlText]
        public string Name { get; set; }
    }

    public class BookingRtg
    {
        /// <summary>
        /// 여정타입코드(OW:편도, RT:왕복, DT:출도착이원구간, MD:다구간)
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 여정코드
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 여정정보
        /// </summary>
        [XmlText]
        public string Explain { get; set; }
    }

    public class BookingPaxType
    {
        /// <summary>
        /// 승객유형코드
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 프로모션카드명(프로모션카드인 경우만 표시 아닌경우는 "")
        /// </summary>
        [XmlAttribute(AttributeName = "card")]
        public string Card { get; set; }

        /// <summary>
        /// 프로모션 표시코드
        /// </summary>
        [XmlAttribute(AttributeName = "sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 승객유형설명
        /// </summary>
        [XmlText]
        public string Explain { get; set; }
    }

    public class BookingExpiryDate
    {
        /// <summary>
        /// 기간코드
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 유효기간
        /// </summary>
        [XmlText]
        public string Date { get; set; }
    }

    public class BookingTL
    {
        /// <summary>
        /// 항공사의 TL
        /// </summary>
        [XmlAttribute(AttributeName = "ttl")]
        public string TTL { get; set; }

        /// <summary>
        /// 최종발권시한(모두투어 TL)
        /// </summary>
        [XmlText]
        public string Date { get; set; }
    }

    public class BookingAmount
    {
        /// <summary>
        /// 항공판매가 합계(@fare + @tax + @fsc + @tasf)
        /// </summary>
        [XmlAttribute(AttributeName = "price")]
        public long Price { get; set; }

        /// <summary>
        /// 2017-05-19 이권태
        /// </summary>
        [XmlAttribute(AttributeName = "subPrice")]
        public long subPrice { get; set; }


        /// <summary>
        /// 항공요금 합계
        /// </summary>
        [XmlAttribute(AttributeName = "fare")]
        public long Fare { get; set; }

        /// <summary>
        /// TAX 합계
        /// </summary>
        [XmlAttribute(AttributeName = "tax")]
        public long Tax { get; set; }

        /// <summary>
        /// 유류할증료 합계
        /// </summary>
        [XmlAttribute(AttributeName = "fsc")]
        public long Fsc { get; set; }

        /// <summary>
        /// 파트너 할인요금 합계
        /// </summary>
        [XmlAttribute(AttributeName = "disPartner")]
        public string DisPartner { get; set; }

        /// <summary>
        /// TASF(발권 여행사 수수료)
        /// </summary>
        [XmlAttribute(AttributeName = "tasf")]
        public long Tasf { get; set; }

        /// <summary>
        /// 부가서비스요금 합계
        /// </summary>
        [XmlAttribute(AttributeName = "supplementaryService")]
        public string SupplementaryService { get; set; }

        /// <summary>
        /// 미확정 운임 여부
        /// </summary>
        [XmlAttribute(AttributeName = "ucf")]
        public string Ucf { get; set; }

        /// <summary>
        /// 자동 발권 불가 운임 여부
        /// </summary>
        [XmlAttribute(AttributeName = "ntf")]
        public string Ntf { get; set; }

        /// <summary>
        /// 텍스/유류할증료 자동 업데이트 여부
        /// </summary>
        [XmlAttribute(AttributeName = "tau")]
        public string Tau { get; set; }

        /// <summary>
        /// 텍스/유류할증료 자동 업데이트 일시
        /// </summary>
        [XmlAttribute(AttributeName = "taud")]
        public string Taud { get; set; }

        /// <summary>
        /// 2017-05-19 추가 이권태
        /// </summary>
        [XmlAttribute(AttributeName = "pcs")]
        public string Pcs { get; set; }

        /// <summary>
        /// 스마일클럽여부
        /// </summary>
        //[XmlAttribute(AttributeName = "scInd")]
        //public string ScInd { get; set; }

        /// <summary>
        /// 스마일클럽아이템할인쿠폰사용여부 (실제 수납적용된 쿠폰)
        /// </summary>
        [XmlAttribute(AttributeName = "scCouponInd")]
        public string ScCouponInd { get; set; }

        /// <summary>
        /// 스마일클럽회원여부
        /// </summary>
        [XmlAttribute(AttributeName = "smileClubYN")]
        public string SmileClubYN { get; set; }

        /// <summary>
        /// 예약시 스마일클럽쿠폰 적용여부
        /// </summary>
        [XmlAttribute(AttributeName = "smileClubCouponYN")]
        public string SmileClubCouponYN { get; set; }
    }



    public class LocationModel
    {
        /// <summary>
        /// 현지연락처
        /// </summary>
        [XmlElement(ElementName = "tel")]
        public string Tel { get; set; }

        /// <summary>
        /// 현지주소
        /// </summary>
        [XmlElement(ElementName = "address")]
        public string Address { get; set; }
    }
    #region 탑승객 정보
    [XmlType("paxData")]
    public class TravellerModel
    {
        /// <summary>
        /// 탑승객정보
        /// </summary>
        [XmlElement(ElementName = "pax")]
        public PaxModel Pax { get; set; }

        /// <summary>
        /// 요금정보
        /// </summary>
        [XmlElement(ElementName = "fare")]
        public PaxFareModel Fare { get; set; }

        /// <summary>
        /// 결제정보
        /// </summary>
        [XmlElement(ElementName = "payment")]
        public PaxPaymentModel Payment { get; set; }

        /// <summary>
        /// 여권정보
        /// </summary>
        [XmlElement(ElementName = "passport")]
        public PaxPassportModel Passport { get; set; }

        /// <summary>
        /// 티켓정보
        /// </summary>
        [XmlElement(ElementName = "ticket")]
        public PaxTicketModel Ticket { get; set; }

        /// <summary>
        /// 항공사 마일리지
        /// </summary>
        [XmlElement(ElementName = "membership")]
        public PaxMembershipModel Membership { get; set; }


        /// <summary>
        /// 투어마일리지카드정보
        /// </summary>
        [XmlElement(ElementName = "tourMileage")]
        public TourMileageModel TourMileage { get; set; }

        /// <summary>
        /// 환불정보
        /// </summary>
        [XmlElement(ElementName = "refund")]
        public RefundModel Refund { get; set; }
    }

    [XmlType("refund")]
    public class RefundModel
    {
        /// <summary>
        /// 진행상태정보
        /// </summary>
        [XmlAttribute(AttributeName = "stateDesc")]
        public string stateDesc { get; set; }

        /// <summary>
        /// 진행상태코드(defulat:OK)
        /// </summary>
        [XmlAttribute(AttributeName = "stateCode")]
        public string StateCode { get; set; }

        /// <summary>
        /// 취소사유
        /// </summary>
        [XmlAttribute(AttributeName = "cancelDesc")]
        public string cancelDesc { get; set; }

        /// <summary>
        /// 취소사유코드(defulat:00)
        /// </summary>
        [XmlAttribute(AttributeName = "cancelCode")]
        public string CancelCode { get; set; }
    }

    public class PaxModel
    {
        /// <summary>
        /// 참조번호
        /// </summary>
        [XmlAttribute(AttributeName = "ref")]
        public short REF { get; set; }

        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public string NSI { get; set; }

        /// <summary>
        /// 탑승객 PTID
        /// </summary>
        [XmlAttribute(AttributeName = "pid")]
        public string PID { get; set; }
        /// <summary>
        /// 탑승객 한글이름
        /// </summary>
        [XmlAttribute(AttributeName = "phn")]
        public string PHN { get; set; }

        /// <summary>
        /// 탑승객 영문성
        /// </summary>
        [XmlAttribute(AttributeName = "psn")]
        public string PSN { get; set; }

        /// <summary>
        /// 탑승객 영문이름
        /// </summary>
        [XmlAttribute(AttributeName = "pfn")]
        public string PFN { get; set; }

        /// <summary>
        /// 탑승객 유형(ADT/CHD/INF)
        /// </summary>
        [XmlAttribute(AttributeName = "ptc")]
        public string PTC { get; set; }

        /// <summary>
        /// 탑승객 타이틀(MR/MRS/MS/MSTR/MISS)
        /// </summary>
        [XmlAttribute(AttributeName = "ptl")]
        public string PTL { get; set; }

        /// <summary>
        /// 탑승객 생년월일
        /// </summary>
        [XmlAttribute(AttributeName = "pbd")]
        public string PBD { get; set; }

        /// <summary>
        /// 탑승객 이메일
        /// </summary>
        [XmlAttribute(AttributeName = "pea")]
        public string PEA { get; set; }

        /// <summary>
        /// 탑승객 전화번호
        /// </summary>
        [XmlAttribute(AttributeName = "ptn")]
        public string PTN { get; set; }

        /// <summary>
        /// 탑승객 휴대폰번호
        /// </summary>
        [XmlAttribute(AttributeName = "pmn")]
        public string PMN { get; set; }

        /// <summary>
        /// 보호자 참조번호(유아일 경우)
        /// </summary>
        [XmlAttribute(AttributeName = "gni")]
        public string GNI { get; set; }

        /// <summary>
        /// 2017-05-19 추가 이권태
        /// </summary>
        [XmlAttribute(AttributeName = "cancel")]
        public string Cancel { get; set; }
    }

    public class PaxFareModel
    {
        /// <summary>
        /// 항공판매가
        /// </summary>
        [XmlAttribute(AttributeName = "price")]
        public string Price { get; set; }

        /// <summary>
        /// 2017-05-19 추가 이권태
        /// </summary>
        [XmlAttribute(AttributeName = "subPrice")]
        public string subPrice { get; set; }

        /// <summary>
        /// 항공요금
        /// </summary>
        [XmlAttribute(AttributeName = "fare")]
        public string Fare { get; set; }

        /// <summary>
        /// TAX
        /// </summary>
        [XmlAttribute(AttributeName = "tax")]
        public string Tax { get; set; }

        /// <summary>
        /// 유류할증료
        /// </summary>
        [XmlAttribute(AttributeName = "fsc")]
        public string Fsc { get; set; }

        /// <summary>
        /// 파트너 할인요금
        /// </summary>
        [XmlAttribute(AttributeName = "disPartner")]
        public string DisPartner { get; set; }

        /// <summary>
        /// 2017-05-19 추가 이권태
        /// </summary>
        [XmlAttribute(AttributeName = "tasf")]
        public string Tasf { get; set; }

        /// <summary>
        /// 투어마일리지
        /// </summary>
        [XmlAttribute(AttributeName = "tourMileage")]
        public string TourMileage { get; set; }

    }

    public class PaxPaymentModel
    {
        /// <summary>
        /// 총결제금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public string Gross { get; set; }

        /// <summary>
        /// 카드결제금액
        /// </summary>
        [XmlAttribute(AttributeName = "card")]
        public string Card { get; set; }

        /// <summary>
        /// 계좌이체금액
        /// </summary>
        [XmlAttribute(AttributeName = "bank")]
        public string Bank { get; set; }

        /// <summary>
        /// 미결제금액(잔액)
        /// </summary>
        [XmlAttribute(AttributeName = "balance")]
        public string Balance { get; set; }

        /// <summary>
        /// 결제일
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }

    public class PaxPassportModel
    {
        /// <summary>
        /// 여권번호
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string ID { get; set; }

        /// <summary>
        /// 여권만료일
        /// </summary>
        [XmlAttribute(AttributeName = "expireDate")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 여권발행국(국가코드)
        /// </summary>
        [XmlAttribute(AttributeName = "issueCountry")]
        public string IssueCountry { get; set; }

        /// <summary>
        /// 국적(국가코드) 
        /// </summary>
        [XmlAttribute(AttributeName = "holderNationality")]
        public string HolderNationality { get; set; }

        /// <summary>
        /// 작성일
        /// </summary>
        [XmlAttribute(AttributeName = "writeDate")]
        public string WriteDate { get; set; }
    }

    public class PaxTicketModel
    {
        /// <summary>
        /// 티켓번호
        /// </summary>
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }

    public class PaxMembershipModel
    {
        /// <summary>
        /// 마일리지 회원번호
        /// </summary>
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// 마일리지 항공사코드
        /// </summary>
        [XmlAttribute(AttributeName = "carrier")]
        public string Carrier { get; set; }
    }

    public class TourMileageModel
    {
        /// <summary>
        /// 회원구분(01:정회원, 02:웹회원, 03:투어마일리지회원)
        /// </summary>
        [XmlAttribute(AttributeName = "memberClass")]
        public string MemberClass { get; set; }

        /// <summary>
        /// 투어마일리지 카드번호
        /// </summary>
        [XmlAttribute(AttributeName = "cardNumber")]
        public string CardNumber { get; set; }

        /// <summary>
        /// 투어마일리지 적립 요청여부 {Y|N}
        /// </summary>
        [XmlAttribute(AttributeName = "request")]
        public string Request { get; set; }

        /// <summary>
        /// 적립예정 투어마일리지
        /// </summary>
        [XmlAttribute(AttributeName = "mileage")]
        public string Mileage { get; set; }
    }

    #endregion

    #region 요금 정보(PNR Data)

    [XmlType("fare")]
    public class FareModel
    {
        /// <summary>
        /// Passenger Type
        /// </summary>
        [XmlAttribute(AttributeName = "ptc")]
        public string PTC { get; set; }

        /// <summary>
        /// 항공판매가1(disFare + tax + fsc)
        /// </summary>
        [XmlAttribute(AttributeName = "price")]
        public string Price { get; set; }

        /// <summary>
        /// 항공판매가2(fare + tax + fsc)
        /// </summary>
        [XmlAttribute(AttributeName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 항공요금
        /// </summary>
        [XmlAttribute(AttributeName = "fare")]
        public string Fare { get; set; }

        /// <summary>
        /// 항공할인요금
        /// </summary>
        [XmlAttribute(AttributeName = "disFare")]
        public string DisFare { get; set; }

        /// <summary>
        /// 제세공과금
        /// </summary>
        [XmlAttribute(AttributeName = "tax")]
        public string Tax { get; set; }

        /// <summary>
        /// 유류할증료
        /// </summary>
        [XmlAttribute(AttributeName = "fsc")]
        public string Fsc { get; set; }

        /// <summary>
        /// 발권수수료
        /// </summary>
        //[XmlAttribute(AttributeName = "tasf")]
        //public String Tasf { get; set; }


        /// <summary>
        /// Fare Basis
        /// </summary>
        [XmlAttribute(AttributeName = "basis")]
        public string Basis { get; set; }

        /// <summary>
        /// Ticket Designator
        /// </summary>
        [XmlAttribute(AttributeName = "tkd")]
        public string TKD { get; set; }

        /// <summary>
        /// Segment
        /// </summary>
        [XmlElement(ElementName = "seg")]
        public List<FareSegModel> FareSeg { get; set; }
    }

    public class FareSegModel
    {
        //참조번호
        [XmlAttribute(AttributeName = "ref")]
        public string REF { get; set; }

        /// <summary>
        /// 무료수하물
        /// </summary>
        [XmlAttribute(AttributeName = "baggage")]
        public string Baggage { get; set; }
    }

    #endregion

    #region 부가서비스
    public class SupplementaryServiceModel
    {
        [XmlElement(ElementName = "service")]
        public List<ServiceModel> Service { get; set; }

        /// <summary>
        /// HOT-LINE
        /// </summary>
        [XmlElement(ElementName = "hotLine")]
        public HotLineModel HotLine { get; set; }
    }

    public class ServiceModel
    {
        /// <summary>
        /// 서비스번호 
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public short Code { set; get; }

        /// <summary>
        /// 주문아이템번호
        /// </summary>
        [XmlAttribute(AttributeName = "ibn")]
        public long Ibn { set; get; }

        /// <summary>
        /// 예약상태코드(HK:예약완료, XX:취소)
        /// </summary>
        [XmlAttribute(AttributeName = "status")]
        public string Status { set; get; }

        /// <summary>
        /// 규정명칭
        /// </summary>
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 서비스요금
        /// </summary>
        [XmlElement(ElementName = "price")]
        public ServicePriceModel Price { get; set; }

        /// <summary>
        /// 서비스요약
        /// </summary>
        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 서비스설명
        /// </summary>
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }

    public class ServicePriceModel
    {
        /// <summary>
        /// 판매가(1인)(@cost - @discount)
        /// </summary>
        [XmlAttribute(AttributeName = "amount")]
        public long Amount { set; get; }

        /// <summary>
        /// 원가(1인)
        /// </summary>
        [XmlAttribute(AttributeName = "cost")]
        public long Cost { set; get; }

        /// <summary>
        /// 할인금액(1인)
        /// </summary>
        [XmlAttribute(AttributeName = "discount")]
        public long Discount { set; get; }

        /// <summary>
        /// 신청수량
        /// </summary>
        [XmlAttribute(AttributeName = "quantity")]
        public long Quantity { set; get; }

        /// <summary>
        /// 총판매가(@amount * @quantity)
        /// </summary>
        [XmlAttribute(AttributeName = "sellingPrice")]
        public long SellingPrice { set; get; }
    }

    public class HotLineModel
    {
        /// <summary>
        /// 부서명
        /// </summary>
        [XmlElement(ElementName = "department")]
        public string Department { get; set; }

        /// <summary>
        /// 담당직원명
        /// </summary>
        [XmlElement(ElementName = "incharge")]
        public string Incharge { get; set; }

        /// <summary>
        /// 휴대폰번호
        /// </summary>
        [XmlElement(ElementName = "hp")]
        public string HP { get; set; }

        /// <summary>
        /// 이메일주소
        /// </summary>
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
    }

    #endregion

    #region 담당 여행사 정보

    public class AgentModel
    {
        /// <summary>
        /// 사이트번호
        /// </summary>
        [XmlAttribute(AttributeName = "snm")]
        public long SNM { get; set; }

        /// <summary>
        /// 거래처번호
        /// </summary>
        [XmlAttribute(AttributeName = "anm")]
        public long ANM { get; set; }

        /// <summary>
        /// 거래처직원번호
        /// </summary>
        [XmlAttribute(AttributeName = "aen")]
        public long AEN { get; set; }

        /// <summary>
        /// 거래처명
        /// </summary>
        [XmlElement(ElementName = "company")]
        public string Company { get; set; }

        /// <summary>
        /// 거래처직원명
        /// </summary>
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 거래처직원 이메일주소
        /// </summary>
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// 거래처 전화번호
        /// </summary>
        [XmlElement(ElementName = "tel")]
        public string Tel { get; set; }

        /// <summary>
        /// 거래처 팩스번호
        /// </summary>
        [XmlElement(ElementName = "fax")]
        public string Fax { get; set; }

        /// <summary>
        /// 제휴거래처 - 2018.02.12 스카이스캐너정보 추가
        /// </summary>
        [XmlElement(ElementName = "share")]
        public ShareModel Share { get; set; }
    }

    public class ShareModel
    {
        /// <summary>
        /// 제휴거래처번호
        /// </summary>
        [XmlAttribute(AttributeName = "anm")]
        public string ShareAnm { get; set; }

    }

    #endregion

    #region 결제요청정보
    public class PaymentReqInfoModel
    {
        /// <summary>
        /// 카드결제요청
        /// </summary>
        [XmlArray(ElementName = "cards")]
        [XmlArrayItem(ElementName = "card")]
        public List<PaymentReqCardModel> Card { get; set; }

        /// <summary>
        /// 카드결제요청
        /// </summary>
        [XmlArray(ElementName = "banks")]
        [XmlArrayItem(ElementName = "bank")]
        public List<PaymentReqBankModel> Bank { get; set; }

    }

    public class PaymentReqCardModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 결제금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 카드사명
        /// </summary>
        [XmlAttribute(AttributeName = "cardName")]
        public string CardName { get; set; }

        /// <summary>
        /// 카드 번호
        /// </summary>
        [XmlAttribute(AttributeName = "cardNumber")]
        public string CardNumber { get; set; }

        /// <summary>
        /// 소유자명
        /// </summary>
        [XmlAttribute(AttributeName = "holder")]
        public string Holder { get; set; }

        /// <summary>
        /// 유효기간
        /// </summary>
        [XmlAttribute(AttributeName = "validThru")]
        public string ValidThru { get; set; }

        /// <summary>
        /// 할부개월수
        /// </summary>
        [XmlAttribute(AttributeName = "installment")]
        public string Installment { get; set; }

        /// <summary>
        /// 결제일
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }
    public class PaymentReqBankModel
    {
        /// <summary>
        /// 결제금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 은행명
        /// </summary>
        [XmlAttribute(AttributeName = "bankName")]
        public string BankName { get; set; }

        /// <summary>
        /// 계좌 번호
        /// </summary>
        [XmlAttribute(AttributeName = "accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// 예금주
        /// </summary>
        [XmlAttribute(AttributeName = "holder")]
        public string Holder { get; set; }

        /// <summary>
        /// 결제일
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }
    #endregion

    #region 결제 정보

    public class PaymentModel
    {
        [XmlIgnore]
        public long Card { get; set; }

        [XmlIgnore]
        public long Cash { get; set; }

        /// <summary>
        /// 총결제금액
        /// </summary>
        [XmlElement(ElementName = "gross")]
        public PaymentGrossModel Gross { get; set; }

        /// <summary>
        /// 카드결제정보
        /// </summary>
        [XmlArray(ElementName = "cards")]
        [XmlArrayItem(ElementName = "card")]
        public List<PaymentCardModel> Cards { get; set; }

        /// <summary>
        /// 온라인입금정보
        /// </summary>
        [XmlArray(ElementName = "banks")]
        [XmlArrayItem(ElementName = "bank")]
        public List<PaymentBankModel> Banks { get; set; }

        /// <summary>
        /// 상품권결제정보
        /// </summary>
        [XmlArray(ElementName = "giftCertificates")]
        [XmlArrayItem(ElementName = "giftCertificate")]
        public List<PaymentGiftCertificatesModel> GiftCertificates { get; set; }

        /// <summary>
        /// 투어마일리지결제정보
        /// </summary>
        [XmlArray(ElementName = "tourMileages")]
        [XmlArrayItem(ElementName = "tourMileage")]
        public List<PaymentTourMileagesModel> TourMileages { get; set; }

        /// <summary>
        /// 쿠폰결제정보
        /// </summary>
        [XmlArray(ElementName = "coupons")]
        [XmlArrayItem(ElementName = "coupon")]
        public List<PaymentCouponsModel> Coupons { get; set; }

        /// <summary>
        /// 쿠폰결제정보
        /// </summary>
        [XmlArray(ElementName = "etcs")]
        [XmlArrayItem(ElementName = "etc")]
        public List<PaymentEtcsModel> Etcs { get; set; }

        /// <summary>
        /// 가상계좌번호정보
        /// </summary>
        [XmlElement(ElementName = "virtualAccountNumber")]
        public VirtualAccountNumberModel VirtualAccount { get; set; }

        /// <summary>
        /// 현금영수증요청정보
        /// 휴대폰번호 또는 사업자번호 등
        /// </summary>
        [XmlElement(ElementName = "cashReceipt")]
        public string CashReceipt { get; set; }

    }

    public class PaymentGrossModel
    {
        /// <summary>
        /// 발권(결제)요청일
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// 총결제금액
        /// </summary>
        [XmlText]
        public long Price { get; set; }
    }

    public class PaymentCardModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 결제금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 결제일
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// 할부개월수
        /// </summary>
        [XmlAttribute(AttributeName = "installment")]
        public short Installment { get; set; }

        /// <summary>
        /// 카드사명
        /// </summary>
        [XmlAttribute(AttributeName = "cardName")]
        public string CardName { get; set; }

        /// <summary>
        /// 승인번호
        /// </summary>
        [XmlAttribute(AttributeName = "approvalNumber")]
        public string ApprovalNumber { get; set; }

        /// <summary>
        /// 거래번호
        /// </summary>
        [XmlAttribute(AttributeName = "transactionNumber")]
        public string TransactionNumber { get; set; }


    }

    public class PaymentBankModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 입금금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 입금일(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// 입금자
        /// </summary>
        [XmlAttribute(AttributeName = "remitter")]
        public string Remitter { get; set; }

        /// <summary>
        /// 은행명
        /// </summary>
        [XmlAttribute(AttributeName = "bankName")]
        public string BankName { get; set; }
    }

    public class PaymentGiftCertificatesModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 입금금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 입금일(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }

    public class PaymentTourMileagesModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 마일리지 결제금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 마일리지 적용일(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }

    public class PaymentCouponsModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 쿠폰번호
        /// </summary>
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// 쿠폰금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 쿠폰적용일(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }

    public class PaymentEtcsModel
    {
        /// <summary>
        /// 판매명세번호
        /// </summary>
        [XmlAttribute(AttributeName = "nsi")]
        public long NSI { get; set; }

        /// <summary>
        /// 쿠폰적용일(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// 쿠폰금액
        /// </summary>
        [XmlAttribute(AttributeName = "gross")]
        public long Gross { get; set; }

        /// <summary>
        /// 쿠폰번호
        /// </summary>
        [XmlAttribute(AttributeName = "item")]
        public string Item { get; set; }
    }

    public class VirtualAccountNumberModel
    {
        /// <summary>
        /// 은행명
        /// </summary>
        [XmlElement(ElementName = "bank")]
        public string Bank { get; set; }

        /// <summary>
        /// 계좌번호
        /// </summary>
        [XmlElement(ElementName = "accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// 예금주
        /// </summary>
        [XmlElement(ElementName = "holder")]
        public string Holder { get; set; }
    }

    #endregion

    #region 증빙서류
    public class ProofModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Explain { get; set; }

        [XmlElement(ElementName = "Proof")]
        public List<Proof> proof { get; set; }
    }

    /// <summary>
    /// 증빙서류 리스트
    /// </summary>
    public class Proof
    {
        /// <summary>
        /// 증빙서류번호
        /// </summary>
        public long FileNo { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 제출방법
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// 파일명
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 파일경로
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 이메일전송예정일
        /// </summary>
        public string EmailDate { get; set; }

        /// <summary>
        /// 이메일전송예정시간
        /// </summary>
        public string EmailTime { get; set; }

        /// <summary>
        /// 팩스
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 팩스전송예정일
        /// </summary>
        public string FaxDate { get; set; }

        /// <summary>
        /// 팩스전송예정시간
        /// </summary>
        public string FaxTime { get; set; }
    }

    #endregion

}
