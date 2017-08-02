using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAppForBinary.DB;
using TestAppForBinary.Models;

namespace TestAppForBinary.Services
{
    public class WeatherServiceWithoutI
    {
        private readonly DBContext dbContext;

        public WeatherServiceWithoutI(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            var result = await dbContext.Cars.ToListAsync();

            return result;
        }

        public async Task<Car> GetCar(int id)
        {
            var result = await dbContext.Cars.FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }

        public async Task DeleteCar(Car car)
        {
            dbContext.Cars.Remove(car);
            await dbContext.SaveChangesAsync();
        }
    }
}