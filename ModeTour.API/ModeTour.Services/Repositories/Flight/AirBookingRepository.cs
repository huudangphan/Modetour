using Modetour.Services.Interfaces.Flight;
using ModeTour.Commons;
using ModeTour.Commons.Helper;
using ModeTour.Entities;
using ModeTour.Entity;
using ModeTour.Services;
using ModeTour.Services.Repositories;
using System.Data;
using System.Xml;
using static ModeTour.Entity.SearchFareAvailSimpleRSModel;

namespace Modetour.Services.Repositories.Flight
{
    public class AirBookingRepository : GenericRepository<SearchFareAvailSimpleRSModel>, IAirBooking
    {
        public AppDbContext context;
        public SearchFareAvailSimpleRSModel.PriceIndexModel NewPriceIndex = null;
        public AirBookingRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public HttpResult GetBanner()
        {
            try
            {
                XmlDocument xmlDocument = XmlHelper.Load("http://xmlfile.modetour.com/XMLInclude/Banner/Modetour/Air/OverseasAirPromotion.xml");
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlDocument.WriteTo(xw);
                PromotionWebRSModel pmodel = XmlHelper.ConvertObject(sw.ToString(), typeof(PromotionWebRSModel)) as PromotionWebRSModel;
                return new HttpResult
                {
                    messageCode = MessageCode.Success,
                    message = "",
                    content = pmodel
                };
            }
            catch (Exception ex)
            {

                return new HttpResult
                {
                    messageCode = MessageCode.Exception,
                    message = null,
                    content = Functions.ToString(ex.Message)
                };
            }
        }

        public HttpResult GetMajorCities()
        {
            try
            {
                XmlDocument xmlDocument = XmlHelper.Load("http://airservice2.modetour.com/AirService.asmx/MajorCities");
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlDocument.WriteTo(xw);
                MajorCitiesRSModel pmodel = XmlHelper.ConvertObject(sw.ToString(), typeof(MajorCitiesRSModel)) as MajorCitiesRSModel;
                return new HttpResult
                {
                    messageCode = MessageCode.Success,
                    message = "",
                    content = pmodel
                };
            }
            catch (Exception ex)
            {

                return new HttpResult
                {
                    messageCode = MessageCode.Exception,
                    message = "",
                    content = Functions.ToString(ex.Message)
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"> parameter search flight list</param>
        /// <returns></returns>
        public HttpResult GetFlightList(SearchFareAvailSimpleRQModel model)
        {
            try
            {
                var objectResult = APIHelper.PostData(model, GlobalData.baseUrlService3 + "SearchFareAvailSimpleRS");
                SearchFareAvailSimpleRSModel tmp = (SearchFareAvailSimpleRSModel)APIHelper.ConvertJsonToObject(Functions.ToString(objectResult), typeof(SearchFareAvailSimpleRSModel));
                ///////////////
                #region fake data
                //***************** Fake data ********************
                #region FLIGHTINFOR
                List<StopOverModel> stopOverFake = new List<StopOverModel>();
                stopOverFake.Add(new StopOverModel { DLC = "DAD", ALC = "CSC", DDT = "", ARDT = "", EFT = "", GWT = "" });
                stopOverFake.Add(new StopOverModel { DLC = "GHD", ALC = "IRM", DDT = "", ARDT = "", EFT = "", GWT = "" });
                stopOverFake.Add(new StopOverModel { DLC = "YEH", ALC = "RUM", DDT = "", ARDT = "", EFT = "", GWT = "" });
                List<NewSegModel> segModel = new List<NewSegModel>();
                segModel.Add(new NewSegModel
                {
                    REF = "",
                    DLC = "KR",
                    ALC = "DAD",
                    DDT = "2022/11/11",
                    ARDT = "",
                    EFT = "7 hours",
                    ETT = "1hour",
                    GWT = "10 minutes",
                    MCC = "A63",
                    OCC = "V8",
                    CDS = "Y",
                    EQT = "Y",
                    STN = "1",
                    ETC = "N",
                    AIF = "",
                    StopOver = stopOverFake
                });
                segModel.Add(new NewSegModel
                {
                    REF = "",
                    DLC = "GK",
                    ALC = "JR",
                    DDT = "2022/11/11",
                    ARDT = "",
                    EFT = "4 hours",
                    ETT = "1hour",
                    GWT = "50 minutes",
                    MCC = "A43",
                    OCC = "45",
                    CDS = "Y",
                    EQT = "N",
                    STN = "2",
                    ETC = "N",
                    AIF = "",
                    StopOver = stopOverFake
                });
                segModel.Add(new NewSegModel
                {
                    REF = "",
                    DLC = "KJR",
                    ALC = "DRD",
                    DDT = "2022/11/11",
                    ARDT = "",
                    EFT = "10 hours",
                    ETT = "2hour",
                    GWT = "40 minutes",
                    MCC = "H33",
                    OCC = "V65",
                    CDS = "N",
                    EQT = "N",
                    STN = "14",
                    ETC = "Y",
                    AIF = "",
                    StopOver = stopOverFake
                });
                List<PriceSummaryModel> priceSummaryFake = new List<PriceSummaryModel>();
                priceSummaryFake.Add(new PriceSummaryModel { Airline = "China airline", Price = "10000 won" });
                priceSummaryFake.Add(new PriceSummaryModel { Airline = "Korea airline", Price = "70000 won" });
                priceSummaryFake.Add(new PriceSummaryModel { Airline = "VietNam airline", Price = "12000 won" });

                List<NewSegGroupModel> segGroupFake = new List<NewSegGroupModel>();


                segGroupFake.Add(new NewSegGroupModel
                {
                    REF = "",
                    EJT = "8 hours",
                    EFT = "7 hours",
                    EWT = "30 minutes",
                    MJC = "ABC",
                    CDS = "Yes",
                    NOSP = 0,
                    ITI = "4 pilots and 7 flight attendants",
                    RTG = "From A to B",
                    GroupAIF = "",
                    FiRef = "001",
                    Seg = segModel
                });
                NewFlightInfoModel flightInfoFake = new NewFlightInfoModel() { PTC = "", ROT = "", OPN = "", SegGroup = segGroupFake };
                #endregion
                #region PriceIndex
                #region PriceSeg
                List<REFModel> refModelFake = new List<REFModel>();
                refModelFake.Add(new REFModel { sgRef = "001", Baggage = "A-91", RTG = "ICN", ITI = "" });
                refModelFake.Add(new REFModel { sgRef = "002", Baggage = "H-42", RTG = "TPE", ITI = "" });
                refModelFake.Add(new REFModel { sgRef = "001", Baggage = "I-23", RTG = "BKK", ITI = "" });
                List<PriceSegModel> priceSegModelFake = new List<PriceSegModel>();
                priceSegModelFake.Add(new PriceSegModel { REF = refModelFake });
                PriceSegGroupModel priceSegGroupModelFake = new PriceSegGroupModel() { Seg = priceSegModelFake };
                #endregion
                #region PaxFareGroup
                List<SegFareModel> SegFareModelFake = new List<SegFareModel>();
                SegFareModelFake.Add(new SegFareModel { REF = "01", Text = "AJ" });
                SegFareModelFake.Add(new SegFareModel { REF = "01", Text = "AJ" });
                SegFareModelFake.Add(new SegFareModel { REF = "01", Text = "AJ" });
                List<NewPaxFareModel> newPaxFareModelFake = new List<NewPaxFareModel>();
                newPaxFareModelFake.Add(new NewPaxFareModel { PTC = "", Price = 100000, SubPrice = 8000, Fare = 4793, DisFare = 8533, Tax = 4433, Fsc = 7439, DisPartner = 44238, Tasf = 4533, MTasf = 4343, ATasf = 4343, Count = 434, SegFare = SegFareModelFake });
                newPaxFareModelFake.Add(new NewPaxFareModel { PTC = "", Price = 50000, SubPrice = 4000, Fare = 45493, DisFare = 8543, Tax = 6423, Fsc = 5839, DisPartner = 4238, Tasf = 4323, MTasf = 6743, ATasf = 7543, Count = 464, SegFare = SegFareModelFake });
                newPaxFareModelFake.Add(new NewPaxFareModel { PTC = "", Price = 700000, SubPrice = 9000, Fare = 4393, DisFare = 8853, Tax = 4753, Fsc = 9239, DisPartner = 64238, Tasf = 7833, MTasf = 7333, ATasf = 4543, Count = 634, SegFare = SegFareModelFake });
                List<NewPaxFareGroupModel> NewPaxFareGroupModelFake = new List<NewPaxFareGroupModel>();
                SummaryModel summaryModelFake = new SummaryModel() { Price = 5776, SubPrice = 4334, Fare = 4348, DisFare = 6767, Tax = 5345, Fsc = 4545, DisPartner = 56755, Tasf = 864, MTasf = 435, ATasf = 384234, PVC = "MNG", MAS = "DFH", Cabin = "JO", Ttl = "JK", CDS = "KL", UCF = "HI", NTF = "JO", CFF = "JK", TTF = "IY", Sutf = "KJ", Pmtl = "IW", Pmsc = "JK", Pmsn = "IO", Sscd = "JO", Sstl = "KP" };
                NewPaxFareGroupModelFake.Add(new NewPaxFareGroupModel { Ref = "98", PaxGDS = "", PTC = "JJ", Mode = "A", Summary = summaryModelFake, PaxFare = newPaxFareModelFake, PromotionInfo = "" });
                List<PriceIndexModel> priceIndexModelsFake = new List<PriceIndexModel>();
                priceIndexModelsFake.Add(new PriceIndexModel { REF = 2, PTC = "JF", PVC = "LK", Mode = "JD", Cabin = "", MinPrice = "5000", FareCount = 79, PriceSeg = priceSegGroupModelFake, PaxFareGroup = NewPaxFareGroupModelFake });

                #endregion
                #endregion
                //************************************************
                #endregion             
                var result = new SearchFareAvailSimpleRSModel()
                {
                    Version = "1.0.1",
                    TimeStamp = "",
                    Ref = "",
                    GUID = "GUID",
                    PriceSummary = priceSummaryFake.OrderByDescending(x => x.Airline.Contains("OZ") || x.Airline.Contains("KE")).ThenBy(x => x.Price).ToList(),
                    FlightInfo = flightInfoFake,
                    PriceIndex = priceIndexModelsFake.OrderByDescending(p => p.PVC.Contains("OZ") || p.PVC.Contains("KE")).ThenBy(p => p.MinPrice).ToList()
                };
                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = result,
                    message = ""
                };

            }
            catch (Exception ex)
            {
                return new HttpResult()
                {
                    messageCode = MessageCode.Exception,
                    content = "",
                    message = Functions.ToString(ex.Message)

                };
            }
        }
        public HttpResult GetNotice(int gbn, int count)
        {
            DBHelper db = new DBHelper(GlobalData.connectionStrModeWeb3, true);
            try
            {
                List<GetNoticeDSModel> result = new List<GetNoticeDSModel>();
                db.SetProcedureName("MODEWEB3.DBO.WSP_S_CMN_게시판리스트_항공");
                db.SetParameter("@구분", gbn);
                db.SetParameter("@갯수", count);

                DataSet ds = new DataSet();
                db.Execute(out ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        GetNoticeDSModel item = new GetNoticeDSModel();

                        item.ItemNo = Convert.ToInt32(dr["일련번호"]);
                        item.Step1 = Convert.ToInt32(dr["스텝1"]);
                        item.Writer = Convert.ToString(dr["작성자"]);
                        item.Title = Convert.ToString(dr["제목"]);
                        item.Views = Convert.ToInt32(dr["조회수"]);
                        item.WriteDate = Convert.ToDateTime(dr["등록일"]);
                        item.Notice = Convert.ToString(dr["공지"]);
                        result.Add(item);
                    }
                }
                db.Close();
                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = result,
                    message = ""
                };
            }
            catch (Exception ex)
            {
                db.Close();
                return new HttpResult()
                {
                    messageCode = MessageCode.Exception,
                    content = "",
                    message = Functions.ToString(ex.Message)

                };
            }
        }

        public HttpResult ChooseFlight(ChooseFlightModel model)
        {
            try
            {

                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = "",
                    message = ""
                };
            }
            catch (Exception ex)
            {

                return new HttpResult()
                {
                    messageCode = MessageCode.Exception,
                    content = null,
                    message = Functions.ToString(ex.Message)

                };
            }
        }
        public List<AirportDSModel> GetAirportList(string codes)
        {
            var result = new List<AirportDSModel>();
            DBHelper db = new DBHelper(GlobalData.connectionStrNewAegle3, true);
            db.SetProcedureName("dbo.WSP_S_공항명");
            db.SetParameter("@공항코드리스트", codes);

            DataSet ds = new DataSet();
            db.Execute(out ds);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = new List<AirportDSModel>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AirportDSModel airport = new AirportDSModel();

                    airport.AirportCode = Functions.ToString(dr["공항코드"]);
                    airport.AirportName = Functions.ToString(dr["공항명"]);
                    airport.AirportName2 = Functions.ToString(dr["공항명2"]);
                    airport.AirportKorName = Functions.ToString(dr["공항명_한글"]);
                    airport.CityCode = Functions.ToString(dr["도시코드"]);
                    airport.CityName = Functions.ToString(dr["도시명"]);
                    airport.CityKorName = Functions.ToString(dr["도시명_한글"]);
                    airport.NationCode = Functions.ToString(dr["국가코드"]);
                    airport.AreaCode = Functions.ToString(dr["지역코드"]);

                    result.Add(airport);
                }
            }
            return result;
        }
        public HttpResult GetTodayList(int count)
        {
            DBHelper db = new DBHelper(GlobalData.connectionStrModeWare3, true);
            try
            {
                GetTodayListDSModel result = null;
                db.SetProcedureName("WSP_S_웹구역_단체리스트_다구역");
                db.SetParameter("@구역번호", "8895,8896,8897,8898,8899,8900");
                db.SetParameter("@게시물수", count);
                DataSet ds = new DataSet();
                db.Execute(out ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    result = new GetTodayListDSModel();
                    result.TodayList = new List<TodayModel>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        TodayModel data = new TodayModel();
                        data.Vnum = Functions.ParseInt(row["재고번호"]);
                        data.GroupNM = Functions.ToString(row["단체명"]);
                        data.ItemCD = Functions.ToString(row["상품코드"]);
                        data.Normal = Functions.ParseInt(row["이전가격"]);
                        data.disFare = Functions.ParseInt(row["가격"]);
                        data.Tax2 = Functions.ParseInt(row["제세공과금"]);
                        data.Tax = Functions.ParseInt(row["TAX"]);
                        data.AirCD = Functions.ToString(row["항공코드"]);
                        data.AirNM = Functions.ToString(row["항공사명"]);
                        data.SDate = Convert.ToDateTime(row["출발일"]);
                        data.EDate = Convert.ToDateTime(row["도착일"]);
                        data.STime = Functions.ToString(row["출발시간"]);
                        data.ETime = Functions.ToString(row["도착시간"]);
                        data.Day = Functions.ParseInt(row["기간"]);
                        data.RSeatWeb = Functions.ParseInt(row["웹판매가능좌석"]);
                        data.LeftOverSeat = Functions.ParseInt(row["잔여좌석수"]);
                        data.LeftOverSeat2 = Functions.ParseInt(row["잔여좌석수2"]);
                        data.AreaNum = Functions.ToString(row["구역번호"]);
                        result.TodayList.Add(data);
                    }
                }
                db.Close();
                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = result,
                    message = ""
                };
            }
            catch (Exception ex)
            {

                db.Close();
                return new HttpResult()
                {
                    messageCode = MessageCode.Exception,
                    content = "",
                    message = Functions.ToString(ex.Message)

                };
            }
        }
        /// <summary>
        /// Term and condition flight
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResult SearchRule(SearchRule3RQModel model)
        {
            try
            {
                var objectResult = APIHelper.PostData(model, GlobalData.baseUrlService3 + "SearchRuleRS");
                ResultModel modelResult = (ResultModel)APIHelper.ConvertJsonToObject(Functions.ToString(objectResult), typeof(ResultModel));
                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    message = "",
                    content = modelResult != null ? modelResult.Data : null
                };
            }
            catch (Exception ex)
            {

                return new HttpResult()
                {
                    messageCode = MessageCode.Exception,
                    content = "",
                    message = Functions.ToString(ex.Message)
                };
            }
        }
        public static List<CodeModel> GetList(string group)
        {
            DBHelper db = new DBHelper(GlobalData.connectionStrModeWare3, true);
            List<CodeModel> result = new List<CodeModel>();
            try
            {
                db.SetProcedureName("WSP_S_CMN_코드");
                db.SetParameter("@종류", group);

                DataSet ds = new DataSet();
                db.Execute(out ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CodeModel data = new CodeModel();

                    data.Name = Functions.ToString(dr["코드명"]);
                    data.Code = Functions.ToString(dr["코드"]);
                    data.Status = new Dictionary<string, string>();

                    foreach (DataColumn item in ds.Tables[0].Columns)
                    {
                        if (item.ColumnName.StartsWith("상태"))
                        {
                            data.Status.Add(item.ColumnName, dr[item.ColumnName].ToString());
                        }
                    }

                    result.Add(data);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                db.Close();
            }

            return result;
        }
        /// <summary>
        /// Get card code company
        /// </summary>
        /// <param name="pax"></param>
        /// <returns></returns>
        public HttpResult GetCardCode(BookingPaxType pax)
        {
            try
            {
                List<CodeModel> result = new List<CodeModel>();
                if (!string.IsNullOrWhiteSpace(pax.Card)) //프로모션운임
                {
                    switch (pax.Code)
                    {
                        case "ADT140":
                            result.Add(new CodeModel() { Name = "삼성2V3카드" });
                            break;
                        default:
                            result.Add(new CodeModel() { Name = pax.Card });
                            break;
                    }
                }
                else
                {
                    List<CodeModel> list = GetList("RH").ToList();
                    list.Insert(0, new CodeModel() { Code = "0", Name = "선택" });
                    list.RemoveAll(item => item.Name == "특가" || item.Name == "기타");
                    result = list;
                }

                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = result,
                    message = ""
                };
            }
            catch (Exception ex)
            {
                return new HttpResult()
                {
                    messageCode = MessageCode.Error,
                    content = null,
                    message = Functions.ToString(ex.Message)
                };
            }
        }
        /// <summary>
        /// Get coupon when user login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResult GetCoupon(ChooseFlightModelx model, string userId)
        {
            try
            {
                CouponBookingGroupListRSModel data = null;
                List<AirportDSModel> AirportModel = null;
                PriceIndexModel newPriceIndex = new PriceIndexModel();
                String DLC = "", DTD = "", ACTC = "";
                var FXL = XmlHelper.ConvertObject(System.Net.WebUtility.HtmlDecode(model.rule.FXL), typeof(NewPaxFareGroupModel)) as NewPaxFareGroupModel;
                Dictionary<string, int> _pax_type = new Dictionary<string, int>() { { "ADT", 1 }, { "CHD", 0 }, { "INF", 0 } };
                _pax_type["ADT"] = Functions.ParseInt(model.searchFare.ADC);
                _pax_type["CHD"] = Functions.ParseInt(model.searchFare.CHC);
                _pax_type["INF"] = Functions.ParseInt(model.searchFare.IFC);
                ItineraryModel SXL = XmlHelper.ConvertObject(System.Net.WebUtility.HtmlDecode(model.rule.SXL), typeof(ItineraryModel)) as ItineraryModel;
                if (SXL != null)
                {
                    Dictionary<string, string> _airport_list = new Dictionary<string, string>();
                    _airport_list =
                             (from f in SXL.SegGroup.SelectMany(s => s.Seg)
                              select f.DLC)
                                 .Union
                                 (from f in SXL.SegGroup.SelectMany(s => s.Seg)
                                  select f.ALC)
                                  //기착정보
                                  .Union
                                  (from f in SXL.SegGroup.SelectMany(s => s.Seg.SelectMany(t => t.StopOver)) select f.DLC)
                                  .Union
                                  (from f in SXL.SegGroup.SelectMany(s => s.Seg.SelectMany(t => t.StopOver)) select f.ALC)
                                 .ToDictionary(s => s);
                    if (FXL != null && _airport_list != null)
                    {
                        #region Get coupon
                        AirportModel = GetAirportList(string.Join(",", _airport_list.Keys.ToArray()));
                        if (AirportModel != null)
                        {
                            var q = AirportModel;
                            ACTC = AirportModel.Where(w => w.AirportCode.Equals(SXL.SegGroup.FirstOrDefault().Seg.Last().ALC)).First().NationCode.Trim();
                            _airport_list.Keys.ToList().ForEach(key =>
                            {
                                _airport_list[key] = q.FirstOrDefault(f => f.AirportCode == key) == null ? key : q.FirstOrDefault(f => f.AirportCode == key).CityKorName;
                                if (key == "ICN") _airport_list[key] = "인천";
                                if (key == "GMP") _airport_list[key] = "김포";
                                if (key == "SEL") _airport_list[key] = "인천/김포";
                            });
                            CouponBookingGroupListXRQModel.CouponBookingGroupListXModel requestModel = new CouponBookingGroupListXRQModel.CouponBookingGroupListXModel
                            {
                                useOid = 0,
                                usePid = Functions.ParseInt(userId),
                                PCode = "IA",
                                GDS = FXL.PaxGDS,
                                CountryCode = ACTC,
                                CityCode = "",
                                ItemCode = "",
                                Price = FXL.Summary.Price,
                                Gross = FXL.Summary.DisFare,
                                DepartureDate = Convert.ToDateTime(DTD.Split(',').ToList().First().Replace(".", "-")),
                                Passenger = _pax_type.Sum(s => s.Value)
                            };
                            var temp = APIHelper.PostData(requestModel, "http://couponservice.modetour.com/coupon/couponBookingGroupListX");
                            ResultModel couponListRM = (ResultModel)(APIHelper.ConvertJsonToObjectx(Functions.ToString(temp))) as ResultModel;
                            if (couponListRM.Code == "0" && couponListRM.Data != null)
                            {
                                data = APIHelper.ConvertJsonToObject(Functions.ToString(couponListRM.Data), typeof(CouponBookingGroupListRSModel)) as CouponBookingGroupListRSModel;

                            }
                        }
                        #endregion
                    }
                }
                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = data,
                    message = ""
                };
            }
            catch (Exception ex)
            {
                return new HttpResult()
                {
                    messageCode = MessageCode.Error,
                    content = null,
                    message = Functions.ToString(ex.Message)
                };
            }

        }
        /// <summary>
        /// When select ticket, check this ticket increased in price
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResult CheckFare(CheckSelectFareRQModel model)
        {
            try
            {
                ResultModel tmp = (ResultModel)APIHelper.PostData(model, GlobalData.baseUrlService + "/CheckSelectFareRS");
                if (!tmp.Code.Equals("200"))
                {
                    return new HttpResult
                    {
                        messageCode = MessageCode.None,
                        message = "예약 불가 안내] 선택하신 운임은 항공료 변동(상향)으로 인해 해당운임으로 발권이 불가합니다. 다른 운임으로 재예약 부탁드립니다. 서비스이용에 불편을 드려 죄송합니다.",
                        content = null
                    };
                }
                else
                {
                    return new HttpResult()
                    {
                        messageCode = MessageCode.Success,
                        message = "예약 불가 안내] 선택하신 운임은 항공료 변동(상향)으로 인해 해당운임으로 발권이 불가합니다. 다른 운임으로 재예약 부탁드립니다. 서비스이용에 불편을 드려 죄송합니다.",
                        content = null
                    };
                }
            }
            catch (Exception ex)
            {

                return new HttpResult()
                {
                    messageCode = MessageCode.Error,
                    content = null,
                    message = Functions.ToString(ex.Message)
                };
            }
        }

        public HttpResult Booking(BookingRequestModel model)
        {
            try
            {

                return new HttpResult()
                {
                    messageCode = MessageCode.Success,
                    content = null,
                    message = ""
                };
            }
            catch (Exception ex)
            {

                return new HttpResult()
                {
                    messageCode = MessageCode.Error,
                    content = null,
                    message = Functions.ToString(ex.Message)
                };
            }
        }
    }

}
