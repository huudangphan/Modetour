using ModeTour.Commons;
using ModeTour.Entities.Air;

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
        public HttpResult GetCoupon(ChooseFlightModelx model, string userId);
        public HttpResult CheckFare(CheckSelectFareRQModel model);
        public HttpResult Booking(BookingRequestModel model);
        public void AirBookingEndMail(int OID, int PID, string reDomain);

    }
}
