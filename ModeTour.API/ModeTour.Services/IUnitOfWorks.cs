using Modetour.Services.Interfaces.Flight;

namespace ModeTour.Services
{
    public interface IUnitOfWorks : IDisposable
    {
        IAirBooking AirBooking { get; }

    }
}
