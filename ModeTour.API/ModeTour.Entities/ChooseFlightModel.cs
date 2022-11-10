using static ModeTour.Entity.SearchFareAvailSimpleRSModel;

namespace ModeTour.Entities
{
    public class ChooseFlightModel
    {
        public PriceIndexModel priceIndexModel { get; set; }
        public SearchFareAvailSimpleRQModel searchFare { get; set; }

    }
    public class ChooseFlightModelx
    {
        public UserModel user { get; set; }
        public SearchRule3RQModel rule { get; set; }
        public SearchFareAvailSimpleRQModel searchFare { get; set; }
    }
}
