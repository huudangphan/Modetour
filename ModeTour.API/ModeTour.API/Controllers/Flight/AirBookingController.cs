using Microsoft.AspNetCore.Mvc;
using ModeTour.Commons;
using ModeTour.Entities;
using ModeTour.Services;

namespace ModeTour.API.Controllers.Flight
{
    [Route("api/v1/Flight/[controller]/[action]")]
    [ApiController]
    public class AirBookingController : BaseAPIController
    {
        private UnitOfWorks unitOfWork;
        public AirBookingController()
        {
            /// Initalization function
            unitOfWork = GetUnitOfWork();
        }
        #region page Main
        [HttpGet]
        public HttpResult GetBanner()
        {
            return unitOfWork.AirBooking.GetBanner();

        }
        [HttpGet]
        public HttpResult GetMajorCity()
        {
            return unitOfWork.AirBooking.GetMajorCities();
        }
        [HttpGet]
        public HttpResult GetTodayList(int count)
        {
            return unitOfWork.AirBooking.GetTodayList(count);
        }
        [HttpGet]
        public HttpResult GetNotice(int gbn, int count)
        {
            return unitOfWork.AirBooking.GetNotice(gbn, count);
        }
        #endregion
        #region page List
        [HttpPost]
        public HttpResult GetFightList([FromBody] SearchFareAvailSimpleRQModel model)
        {
            return unitOfWork.AirBooking.GetFlightList(model);
        }
        /// <summary>
        /// Check ticket can be selected
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResult CheckFare([FromBody] CheckSelectFareRQModel model)
        {
            return unitOfWork.AirBooking.CheckFare(model);
        }
        #endregion
        #region page Input


        [HttpPost]
        public HttpResult SearchRule([FromBody] SearchRule3RQModel model)
        {
            return unitOfWork.AirBooking.SearchRule(model);
        }
        [HttpPost]
        public HttpResult GetCoupon([FromBody] ChooseFlightModelx model, string userId)
        {
            return unitOfWork.AirBooking.GetCoupon(model, userId);
        }
        [HttpPost]
        public HttpResult GetCompanyCardCode([FromBody] BookingPaxType pax)
        {
            return unitOfWork.AirBooking.GetCardCode(pax);
        }

        #endregion

    }
}
