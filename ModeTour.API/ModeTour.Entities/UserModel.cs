namespace ModeTour.Entities
{
    public class UserModel
    {
        private bool _is_login = false;
        /// <summary>
        /// 로그인여부
        /// </summary>
        public bool IsLogin { set { _is_login = value; } get { return _is_login; } }

        public string Auth { set; get; }

        public string SaNum { set; get; }

        /// <summary>
        /// 거래처_거래처직원(PTID)
        /// </summary>
        public Int32 PTID { set; get; }

        private string _id = string.Empty;
        /// <summary>
        /// 아이디
        /// </summary>
        public string ID { set { _id = value; } get { return _id; } }

        private string _name = string.Empty;
        /// <summary>
        /// 한글이름
        /// </summary>
        public string Name { set { _name = value; } get { return _name; } }

        private string _jumin = string.Empty;
        /// <summary>
        /// 주민번호
        /// </summary>
        public string Jumin
        {
            set
            {
                _jumin = value;
                _birthday = (!string.IsNullOrEmpty(_jumin) && _jumin.Length > 6) ? _jumin.Substring(0, 6) : "";
                _gender = (!string.IsNullOrEmpty(_jumin) && _jumin.Length > 6) ? _jumin.Substring(6, 1) : "";
            }
            get { return _jumin; }
        }

        private string _birthday = string.Empty;
        /// <summary>
        /// 생년월일
        /// </summary>
        public string Birthday
        {
            get
            {
                string result = string.Empty;

                if (!string.IsNullOrEmpty(_gender))
                {

                    switch (_gender)
                    {
                        case "1":
                        case "2":
                        case "5":
                        case "6": result = "19" + _birthday; break;
                        default: result = "20" + _birthday; break;
                    }
                    result = string.Format("{0}-{1}-{2}", result.Substring(0, 4), result.Substring(4, 2), result.Substring(6));
                }

                return result;
            }
        }

        private string _gender = string.Empty;
        /// <summary>
        /// 성별
        /// </summary>
        public string Gender
        {
            get
            {
                return _gender;
            }
        }

        /// <summary>
        /// 영문이름
        /// </summary>
        public string EName { set; get; }
        /// <summary>
        /// 전화
        /// </summary>
        public string Phone { set; get; }

        private string _hp = string.Empty;
        private string[] _hp_arr = new string[] { };
        /// <summary>
        /// 휴대폰
        /// </summary>
        public string Hp { set { _hp = value; _hp_arr = _hp.Split('-'); } get { return _hp; } }
        public string Hp1 { get { return _hp_arr.Length > 0 ? _hp_arr[0] : string.Empty; } }
        public string Hp2 { get { return _hp_arr.Length > 1 ? _hp_arr[1] : string.Empty; } }
        public string Hp3 { get { return _hp_arr.Length > 2 ? _hp_arr[2] : string.Empty; } }

        private string _email;
        private string[] _email_arr = new string[] { };
        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { set { _email = value; _email_arr = _email.Split('@'); } get { return _email; } }
        public string Email1 { get { return _email_arr.Length > 0 ? _email_arr[0] : string.Empty; } }
        public string Email2 { get { return _email_arr.Length > 1 ? _email_arr[1] : string.Empty; } }

        public int AgentPTID { set; get; }

        /// <summary>
        /// 수정일
        /// </summary>
        public string ModifyDate { get; set; }

        /// <summary>
        /// 가입일
        /// </summary>
        public string JoinDate { get; set; }


        /// <summary>
        /// MT번호
        /// </summary>
        public string MTNO { get; set; }

        /// <summary>
        /// DI(본인인증)
        /// </summary>
        public String DI { get; set; }

        /// <summary>
        /// CI(본인인증)
        /// </summary>
        public String CI { get; set; }

        /// <summary>
        /// 파트너여행사 ptid add by 2019.07.16(신지영)
        /// </summary>
        public String PartnerPtid { get; set; }

        /// <summary>
        /// 가라인증여부 추가 2019.12.13 (양영섭)
        /// </summary>
        public String FakeCI { get; set; }


        /// <summary>
        /// 멤버십 이용약관 
        /// </summary>
        public string MemShipUseAgree { get; set; }


        /// <summary>
        /// SMS 수신유무
        /// </summary>
        public string SMS_YN { get; set; }

        /// <summary>
        /// 회원 주소1
        /// </summary>
        public string MemAddr1 { get; set; }

        /// <summary>
        /// 회원 주소2
        /// </summary>
        public string MemAddr2 { get; set; }

        /// <summary>
        /// 우편번호
        /// </summary>
        public string MemZip { get; set; }
    }
}
