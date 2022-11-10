using ModeTour.Commons;
using ModeTour.Entities;

namespace Modetour.Services.Interfaces.Flight
{
    public interface IAirBooking
    {
        public HttpResult GetBanner();
        public HttpResult GetMajorCities();
        public HttpResult GetFlightList(SearchFareAvailSimpleRQModel model);
        public HttpResult GetNotice(int gbn, int count);
        public HttpResult ChooseFlight(ChooseFlightModel model);
        public HttpResult GetTodayList(int count);
        public HttpResult SearchRule(SearchRule3RQModel model);
        public HttpResult GetCardCode(BookingPaxType pax);
        public HttpResult GetCoupon(ChooseFlightModelx model);
        //public HttpResult LoadPrice(SearchRule3RQModel model);
    }
}
