using System.Data;
using System.Net.Mail;
using System.Text;

namespace ModeTour.Commons.Helper
{
    public class MailHelper
    {
        private readonly string _smtp_server_domain = "mailsender.modetour.com";
        private readonly int _smtp_server_port = 25;
        private readonly string _smtp_server_account = "ModeMailClient";
        private readonly string _smtp_server_password = "Mode##6#WebDev0#1%";

        private MailMessage _message = new MailMessage();
        private ResultModel _result = new ResultModel();
        private APIHelper api = new APIHelper();

        private string _default_from_name = "모두투어";
        private string _default_from_address = "mailsender@modetour.com";

        private string _from_name = string.Empty;
        private string _from_address = string.Empty;
        private string _body_html = string.Empty;
        private bool _savehistory = true;

        private int _file_size = 1024 * 1024 * 10;  //첨부파일 사이즈 제한(10MB)
        private string _file_ext = "jpg,gif,png,tif,tiff,pdf,txt,hwp,doc,docx,xls,xlsx,ppt,pptx";  //허용 파일확장자
        private bool _nate_check = false;
        private APIRequestType _request_type = APIRequestType.GET;
        private bool _use_body_url = false;

        /// <summary>
        /// 에러 메세지
        /// </summary>
        public string ErrorMsg = string.Empty;

        /// <summary>
        /// 에러 메세지
        /// </summary>
        public ResultModel ErrorModel { get { return _result; } }

        /// <summary>
        /// 보내는사람 이름
        /// </summary>
        public string FromName { get { return _from_name; } set { _from_name = value; } }

        /// <summary>
        /// 보내는사람 Email Address
        /// </summary>
        public string FromAddress { get { return _from_address; } set { _from_address = value; } }

        /// <summary>
        /// 받는사람 Email Address
        /// 다중입력 예) 홍길동<hong@modetour.com>;아무게<amogae@modetour.co.kr>;
        /// </summary>
        public string ToAddress { set { AddAddress(value, _message.To); } }

        /// <summary>
        /// 참조 Email Address
        /// 다중입력 예) 홍길동<hong@modetour.com>;아무게<amogae@modetour.co.kr>;
        /// </summary>
        public string CcAddress { set { AddAddress(value, _message.CC); } }

        /// <summary>
        /// 숨은참조 Email Address
        /// 다중입력 예) 홍길동<hong@modetour.com>;아무게<amogae@modetour.co.kr>;
        /// </summary>
        public string BccAddress { set { AddAddress(value, _message.Bcc); } }

        /// <summary>
        /// Email 제목
        /// </summary>
        public string Subject { set { _message.Subject = value; } }

        /// <summary>
        /// Email 내용 (메일 최상단에 멘트로 들어감)
        /// </summary>
        public string BodyText { set { _message.Body = value; } }

        /// <summary>
        /// Html로 만들어진 Email 내용
        /// </summary>
        public string BodyHtml { set { _body_html = value; } }

        /// <summary>
        /// URL로 만들어진 Email 내용
        /// </summary>
        public string BodyURL { set { GetHtmlBody(value); } }

        /// <summary>
        /// 첨부파일 허용 파일확장자 변경
        /// ex) jpg,gif,png
        /// </summary>
        public string FileExt { set { _file_ext = value; } }

        /// <summary>
        /// 첨부파일 크기 변경(단위:MB)
        /// ex) "10" -> 10MB
        /// </summary>
        public int FileSize { set { _file_size = 1024 * 1024 * value; } }

        /// <summary>
        /// 첨부파일 추가 [HttpPostedFile 형식]
        /// </summary>
        //public bool AddFile(HttpPostedFile AttachFile)
        //{
        //    if (IsAttachAdd(AttachFile.FileName))
        //    {
        //        if (AttachFile.ContentLength < _file_size)
        //        {
        //            string[] _AttachFileName = AttachFile.FileName.Split('\\'); //파일명이 왜 풀경로로 들어가니!!

        //            Attachment att = new Attachment(AttachFile.InputStream, _AttachFileName[_AttachFileName.Length - 1]);
        //            _message.Attachments.Add(att);

        //            return true;
        //        }
        //        _result.Code = "45";
        //        _result.Msg = "첨부파일 크기는 " + (_file_size / (1024 * 1024)) + "MB 이하만 가능합니다.";
        //        _result.Data = _file_size;
        //        return false;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 첨부파일 추가 [Byte형식]
        /// </summary>
        public bool AddFile(byte[] AttachFile, string filename)
        {
            if (IsAttachAdd(filename))
            {
                if (AttachFile.Length < _file_size)
                {
                    Attachment att = new Attachment(new MemoryStream(AttachFile), filename);
                    _message.Attachments.Add(att);

                    return true;
                }
                _result.Code = "45";
                _result.Msg = "첨부파일 크기는 " + (_file_size / (1024 * 1024)) + "MB 이하만 가능합니다.";
                _result.Data = _file_size;
                return false;
            }
            return false;
        }

        /// <summary>
        /// URL로 넘어온 Body를 Html로 넘겨받음
        /// </summary>
        /// <param name="URL">URL주소 값</param>
        private void GetHtmlBody(string URL)
        {
            _use_body_url = true;
            api.Url = URL;
            api.RequestType = _request_type;   //API Helper 기본 RequestType인 Post로 전송시 HTML파일은 405 Server Error가 발생하여 Get방식 Fix (2015-04-09:김우승)
            api.Call();

            if (api.Result.Code == "0") //정상적으로 Data를 받아옴
            {
                _body_html = api.Result.Data.ToString(); //2015-04-13 김우승
            }
            else //정상적으로 Data를 받아오지 못함
            {
                _result.Code = "46";
                _result.Msg = "API로 Data를 정상적으로 호출하지 못했습니다.";
                _result.Data = api.Result.Data;
            }
        }

        /// <summary>
        /// 이메일 전송시 DB 메시지 Table에 이력을 남길지 여부를 반환합니다
        /// Default : true
        /// </summary>
        public bool IsHistoryInDB { set { _savehistory = value; } }

        /// <summary>
        /// 파일의 확장자를 체크하여 메일에 파일 첨부 유무를 반환
        ///  - 허용 파일확장자명 : jpg, gif, png, tif, tiff, pdf, txt, hwp, doc, docx, xls, xlsx, ppt, pptx
        /// </summary>
        /// <param name="FileName">첨부파일명</param>
        private bool IsAttachAdd(string FileName)
        {
            string[] _SplitArr = FileName.ToLower().Split('.');
            string _ExtName = _SplitArr[_SplitArr.Length - 1];

            if (System.Text.RegularExpressions.Regex.IsMatch(_ExtName, _file_ext.Replace(',', '|')))
            {
                return true;
            }
            _result.Code = "47";
            _result.Msg = "허용된 첨부파일 확장자가 아닙니다.";
            _result.Data = FileName;
            return false;
        }

        /// <summary>
        /// 메일 수신자 주소록에 추가합니다
        /// </summary>
        /// <param name="Gubun">수신자, 참조, 숨은참조</param>
        /// <param name="To_Address_List"></param>
        private void ReceiveAddMail(string Gubun, string To_Address_List)
        {
            foreach (string Address in To_Address_List.ToLower().Split(';'))
            {
                if (!String.IsNullOrEmpty(Address))
                {
                    if (Address.Contains("@nate.com")) { _nate_check = true; } //수신자 목록중에 @nate.com이 있다면 true

                    switch (Gubun)
                    {
                        case "cc":
                            _message.CC.Add(new MailAddress(Address)); //우승닷컴<victore@modetour.com>;<vicon@naver.com>
                            break;
                        case "bcc":
                            _message.Bcc.Add(new MailAddress(Address));
                            break;
                        default:
                            _message.To.Add(new MailAddress(Address));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// To, Cc, Bcc 메일 수신자 주소에 추가합니다
        /// </summary>
        /// <param name="Address_list">수신자 메일 주소 리스트 (ex. a@mail.com;b@mail.com;@c@mail.com)</param>
        /// <param name="ReceivePath">추가될 메일주소 위치 (수신자, 참조, 숨은참조)</param>
        private void AddAddress(string Address_list, MailAddressCollection ReceivePath)
        {
            foreach (string Address in Address_list.Split(';'))
            {
                if (!String.IsNullOrEmpty(Address))
                {
                    if (Address.Contains("@nate.com")) { _nate_check = true; } //수신자 목록중에 @nate.com이 있다면 true
                    ReceivePath.Add(SetAddress(Address));
                }
            }
        }

        /// <summary>
        /// 메일 형식으로 만들어 반환합니다.
        /// </summary>
        /// <param name="Address">홍길동<a@mode.com></param>
        /// <returns></returns>
        private MailAddress SetAddress(string Address)
        {
            string name = "";
            string address = "";

            if (Address.Contains("<") && Address.Contains(">"))
            {
                name = Address.Substring(0, Address.IndexOf("<"));
                address = Address.Substring(Address.IndexOf("<") + 1, Address.IndexOf(">") - (Address.IndexOf("<") + 1));
            }
            else
            {
                address = Address.Replace("<", "").Replace(">", "");
            }

            return new MailAddress(address, name, Encoding.UTF8);
        }

        /// <summary>
        /// SMTP서버를 연결하여 Email 전송!
        /// </summary>
        /// <returns>정상 전송되면 True, 실패하면 False</returns>
        public bool EmailSend()
        {
            try
            {
                //발신자에 @nate.com이 존재 And 수신자에 @nate.com이 존재하면 발신전용메일로 발송!
                if (_from_address == null || String.IsNullOrEmpty(_from_address) || (_from_address.Contains("@nate.com") && _nate_check))
                    _message.From = SetAddress(string.Format("{0}<{1}>", _default_from_name, _default_from_address));
                else
                    _message.From = SetAddress(string.Format("{0}<{1}>", FromName, FromAddress));

                _message.SubjectEncoding = Encoding.UTF8;
                _message.BodyEncoding = Encoding.UTF8;
                _message.IsBodyHtml = true;
                _message.Body += "<br/><br/>" + _body_html;

                SmtpClient client = new SmtpClient(_smtp_server_domain, _smtp_server_port);  //메일서버 정보
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(_smtp_server_account, _smtp_server_password);  //메일서버 접근 정보
                //client.Timeout = 10000;
                if (_use_body_url)  //Html URL로 경로를 넘겼는지 확인!
                {
                    if (api.Result.Code == "0")
                    {
                        client.Send(_message);   //메일 전송!
                        if (_savehistory) SaveLogDB();  //전송 전 DB에 이력 저장
                        _result.Code = "99";
                        _result.Msg = "전송되었습니다.(APIHelper사용)";
                        _result.Data = "";
                        return true;
                    }
                    else
                    {
                        //_result.Code = "99";
                        //_result.Msg = "전송에 되었습니다.";
                        //_result.Data = "";
                        return false;
                    }
                }
                else
                {
                    client.Send(_message);   //메일 전송!
                    if (_savehistory) SaveLogDB();  //전송 전 DB에 이력 저장
                    _result.Code = "99";
                    _result.Msg = "전송되었습니다.(BodyHtml사용)";
                    _result.Data = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                _result.Code = "49";
                _result.Msg = "전송에 실패하였습니다.";
                _result.Data = ex;
                //ErrorMsg = ex.ToString();

                return false;
            }
        }

        /// <summary>
        /// 이메일 전송내역을 DB에 저장합니다.
        /// </summary>
        private void SaveLogDB()
        {
            try
            {
                string fileName = string.Empty;
                if (_message.Attachments.Count > 0) fileName = _message.Attachments[0].Name;

                foreach (MailAddress ToAddress in _message.To)
                {
                    //DBHelper 수정중
                    SetMailLog(_message.From.DisplayName, _message.From.Address, _message.Subject, _message.Body, 0, 0, fileName, ToAddress.DisplayName, ToAddress.Address);
                }
            }
            catch (Exception ex)
            {
                _result.Code = "48";
                _result.Msg = "DB에 전송내역 저장이 실패하였습니다.";
                _result.Data = ex;

            }
        }
        public void SetMailLog(string FromName, string FromAddress, string Subject, string Content, int Pnum, int OrderNum, string AttachFile, string ToName, string ToAddress)
        {
            DBHelper DB = new DBHelper(GlobalData.connectionStrModeWare3, true);
            try
            {
                DB.SetProcedureName("MODEWARE3.DBO.WSP_T_메시지");
                DB.SetParameter("@메시지종류", "05");
                DB.SetParameter("@발송자", 0);
                DB.SetParameter("@발송자명", FromName);
                DB.SetParameter("@발송자주소", FromAddress);
                DB.SetParameter("@제목", Subject);
                DB.SetParameter("@내용", Content);
                DB.SetParameter("@수신확인필요여부", "N");
                DB.SetParameter("@단체번호", Pnum);
                DB.SetParameter("@주문번호", OrderNum);
                DB.SetParameter("@첨부파일명", AttachFile);
                DB.SetParameter("@수신자", 0);
                DB.SetParameter("@수신자명", ToName);
                DB.SetParameter("@수신자주소", ToAddress);
                DB.SetParameter("@그룹수신가능여부", "N");
                DB.SetParameter("@그룹번호", 0);
                DB.SetParameter("@메세지발송번호", null, 10, ParameterDirection.Output);
                DB.SetParameter("@LMS종류", null);
                DB.Execute();
                int returnvalue = Convert.ToInt32(DB.GetParameter("@메세지발송번호"));

            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }
        }
    }
}
