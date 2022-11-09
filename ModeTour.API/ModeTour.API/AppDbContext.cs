using Microsoft.EntityFrameworkCore;

namespace QTS.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {

        }
        //public DbSet<TestEntity> TestEntities;
    }

}
