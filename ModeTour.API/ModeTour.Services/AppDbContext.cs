using Microsoft.EntityFrameworkCore;
using ModeTour.Commons;

namespace ModeTour.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptionsBuilder options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalData.connectionStrModeWeb3);
            options.UseSqlServer(GlobalData.connectionStrModeWare3);
        }

    }

}
