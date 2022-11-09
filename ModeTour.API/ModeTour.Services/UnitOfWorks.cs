using Microsoft.EntityFrameworkCore;
using Modetour.Services.Interfaces.Flight;
using Modetour.Services.Repositories.Flight;
using ModeTour.Commons;
namespace ModeTour.Services
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private AppDbContext _appDbContext;
        private bool _disposed;
        public UnitOfWorks()
        {
            DbContextOptionsBuilder option = new DbContextOptionsBuilder();
            option.UseSqlServer(GlobalData.connectionStrModeWeb3);
            option.UseSqlServer(GlobalData.connectionStrModeWare3);
            _appDbContext = new AppDbContext(option);
        }

        public IAirBooking AirBooking
        {
            get { return new AirBookingRepository(_appDbContext); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }
            }
            _disposed = true;
        }

    }
}
