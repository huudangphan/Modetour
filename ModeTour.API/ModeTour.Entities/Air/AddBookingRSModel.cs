using System.Xml.Serialization;

namespace ModeTour.Entities.Air
{
    [Serializable]
    [XmlRoot(ElementName = "ResponseDetails")]
    public class AddBookingRSModel
    {
        [XmlAttribute(AttributeName = "version")]
        public String Version { get; set; }

        [XmlAttribute(AttributeName = "timeStamp")]
        public String TimeStamp { get; set; }

        /// <summary>
        /// 기본정보
        /// </summary>
        [XmlElement(ElementName = "bookingInfo")]
        public AddBookingInfoModel BookingInfo { get; set; }

        [XmlElement(ElementName = "attn")]
        public OrderModel Order { get; set; }
    }

    public class AddBookingInfoModel
    {
        /// <summary>
        /// 모두투어 예약번호
        /// </summary>
        [XmlElement(ElementName = "modeBookingNo")]
        public Int64 OrderNo { get; set; }

        ///// <summary>
        ///// 예약자번호
        ///// </summary>
        //[XmlElement(ElementName = "reserveByNo")]
        //public Int64 OrderPTID { get; set; }

        /// <summary>
        /// 예약일시 YYYY-MM-DD HH:MM:SS
        /// </summary>
        [XmlElement(ElementName = "bookingCreationDate")]
        public String BookingCreationDate { get; set; }
    }
}
