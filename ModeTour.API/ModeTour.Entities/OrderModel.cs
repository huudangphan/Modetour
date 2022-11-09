using System.Xml.Serialization;

namespace ModeTour.Entities
{
    [XmlType("attn")]
    public class OrderModel
    {
        /// <summary>
        /// 예약자 PTID
        /// </summary>
        [XmlAttribute(AttributeName = "rid")]
        public Int64 RID { set; get; }

        /// <summary>
        /// 예약자 타이틀(MR/MS)
        /// </summary>
        [XmlAttribute(AttributeName = "rtl")]
        public String RTL { get; set; }

        /// <summary>
        /// 예약자 한글이름
        /// </summary>
        [XmlAttribute(AttributeName = "rhn")]
        public String RHN { get; set; }


        /// <summary>
        /// 예약자 생년월일
        /// </summary>
        [XmlAttribute(AttributeName = "rdb")]
        public String RDB { get; set; }


        /// <summary>
        /// 예약자 이메일
        /// </summary>
        [XmlAttribute(AttributeName = "rea")]
        public String REA { get; set; }

        /// <summary>
        /// 예약자 전화번호
        /// </summary>
        [XmlAttribute(AttributeName = "rtn")]
        public String RTN { get; set; }

        /// <summary>
        /// 예약자 모바일번호
        /// </summary>
        [XmlAttribute(AttributeName = "rmn")]
        public String RMN { get; set; }

        /// <summary>
        /// 요청단말기RQT
        /// </summary>
        [XmlElement(ElementName = "terminal")]
        public String Terminal { get; set; }

        /// <summary>
        /// 현지연락처(비상연락망)
        /// </summary>
        [XmlElement(ElementName = "localTel")]
        public String LocalTel { get; set; }

        /// <summary>
        /// 현지주소
        /// </summary>
        [XmlElement(ElementName = "localAddress")]
        public String LocalAddress { get; set; }

        /// <summary>
        /// 체류지우편번호
        /// </summary>
        [XmlElement(ElementName = "localZipcode")]
        public String LocalZipcode { get; set; }

        /// <summary>
        /// 요청사항
        /// </summary>
        [XmlElement(ElementName = "remark")]
        public String Remark { get; set; }

        /// <summary>
        /// 제휴회원사번호
        /// </summary>
        [XmlElement(ElementName = "partnerMemberID")]
        public string PartnerMemberID { get; set; }
    }
}
