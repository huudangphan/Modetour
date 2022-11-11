namespace ModeTour.Entities
{
    public class BookingRequestModel
    {
        public int RID { get; set; }
        /// <summary>
        /// passenger title(MR/MS)
        /// </summary>
        public string RTL { get; set; }
        /// <summary>
        /// Korea name
        /// </summary>
        public string RHN { get; set; }
        /// <summary>
        /// English Name(Sur name)
        /// </summary>
        public string RSN { get; set; }
        /// <summary>
        /// English Name(First name)
        /// </summary>
        public string RFN { get; set; }
        /// <summary>
        /// Date of birth yyyyMMdd
        /// </summary>
        public string RDB { get; set; }
        /// <summary>
        /// Sex (M/F)
        /// </summary>
        public string RGD { get; set; }
        /// <summary>
        /// The person making the reservation is a domestic/foreigner (L: Korean, F: Foreigner)
        /// </summary>
        public string RLF { get; set; }
        /// <summary>
        /// Reservation phone number
        /// </summary>
        public string RTN { get; set; }
        /// <summary>
        /// mobile phone reservation
        /// </summary>
        public string RMN { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string REA { get; set; }

        public string FXL { get; set; }
        /// <summary>
        /// 선택한 여정을 <itinerary>~</itinerary>노드에 삽입한 XmlNode  --selected itinerary
        /// </summary>
        public string SXl { get; set; }
        /// <summary>
        ///   Fare rules
        /// </summary>
        public string RXl { get; set; }
        /// <summary>
        /// --    Selected for discount airlines
        /// </summary>
        public string DXL { get; set; }
        /// <summary>
        /// 제휴정보   --link information
        /// </summary>
        public string AKY { get; set; }
        /// <summary>
        /// web number
        /// </summary>
        public string SNM { get; set; }
        /// <summary>
        ///  account number
        /// </summary>
        public string ANM { get; set; }
        /// <summary>
        /// Segment(OW: one-way, RT: round trip, DT: two-way to and from, MD: multiple segments)
        /// </summary>
        public string ROT { get; set; }
        public List<OccupantInformationModel> occupantInformation { get; set; }
    }
}
