using Microsoft.AspNetCore.Mvc;
using ModeTour.Commons;
using ModeTour.Commons.Helper;
using ModeTour.Entities;
using ModeTour.Entity;
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
            unitOfWork = GetUnitOfWork();
        }
        [HttpGet]
        public HttpResult GetBanner()
        {
            return unitOfWork.AirBooking.GetBanner();

        }
        [HttpPost]
        public HttpResult GetFightList([FromBody] SearchFareAvailSimpleRQModel model)
        {
            return unitOfWork.AirBooking.GetFlightList(model);
        }
        [HttpPost]
        public HttpResult Test([FromBody] SearchFareAvailSimpleRQModel model)
        {
            var objectResult = APIHelper.PostData(model, "https://localhost:7271/api/v1/Flight/AirBooking/GetFightList");
            HttpResult m = new HttpResult();
            var oMyclass = APIHelper.ConvertJsonToObject(Functions.ToString(objectResult));
            SearchFareAvailSimpleRSModel tmp = (SearchFareAvailSimpleRSModel)APIHelper.ConvertJsonToObject(Functions.ToString(oMyclass.content), typeof(SearchFareAvailSimpleRSModel));
            return new HttpResult
            {
                message = "",
                messageCode = MessageCode.None,
                content = tmp

            };
        }
        [HttpGet]
        public HttpResult GetMajorCity()
        {
            return unitOfWork.AirBooking.GetMajorCities();
        }
        [HttpPost]
        public HttpResult ChooseFlight([FromBody] ChooseFlightModel model)
        {
            return unitOfWork.AirBooking.ChooseFlight(model);
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
        [HttpPost]
        public HttpResult SearchRule([FromBody] SearchRule3RQModel model)
        {
            return unitOfWork.AirBooking.SearchRule(model);
        }
    }
}
