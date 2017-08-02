using Microsoft.EntityFrameworkCore;
using TestAppForBinary.Models;

namespace TestAppForBinary.DB
{
    public class DBContext:DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DBContext(DbContextOptions<DBContext> options):base(options)
        {
            
        }
    }
}