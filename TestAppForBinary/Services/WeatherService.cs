using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAppForBinary.DB;
using TestAppForBinary.Interfaces;
using TestAppForBinary.Models;

namespace TestAppForBinary.Services
{
    public class WeatherService:IWeatherService
    {
        private readonly DBContext dbContext;

        public WeatherService(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            var result = await dbContext.Manufacturers.ToListAsync();

            return result;
        }

        public async Task<Manufacturer> GetManufacturer(int id)
        {
            var result = await dbContext.Manufacturers.FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }

        public async Task DeleteManufacturer(Manufacturer manufacturer)
        {
            dbContext.Manufacturers.Remove(manufacturer);
            await dbContext.SaveChangesAsync();
        }
    }
}