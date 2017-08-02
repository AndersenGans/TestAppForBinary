using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppForBinary.Models;

namespace TestAppForBinary.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<Manufacturer>> GetManufacturers();
        Task<Manufacturer> GetManufacturer(int id);
        Task DeleteManufacturer(Manufacturer manufacturer);
    }
}