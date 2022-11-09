using Modetour.Services.Interfaces.Flight;

namespace ModeTour.Services
{
    public interface IUnitOfWorks : IDisposable
    {
        //Itest TestRepository { get; }
        //IAuth AuthRepository { get; }
        IAirBooking AirBooking { get; }

    }
}
