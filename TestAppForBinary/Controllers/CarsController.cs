using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAppForBinary.Services;

namespace TestAppForBinary.Controllers
{
    
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        private readonly WeatherServiceWithoutI weatherServiceWithoutI;
        private readonly ILogger<CarsController> logger;

        public CarsController(WeatherServiceWithoutI weatherServiceWithoutI,
            ILogger<CarsController> logger)
        {
            this.weatherServiceWithoutI = weatherServiceWithoutI;
            this.logger = logger;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var result = await weatherServiceWithoutI.GetCars();

            if (result == null)
            {
                logger.LogInformation("Table 'Car'is empty");

                return NotFound();
            }

            logger.LogInformation("Get list of cars ", result);

            return Json(result);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                logger.LogInformation("Bad request from user");

                return BadRequest(ModelState);
            }

            var result = await weatherServiceWithoutI.GetCar(id);
            

            if (result == null)
            {
                logger.LogInformation("Table 'Car' does'n contain row with id '"+ id +"'");

                return NotFound();
            }

            logger.LogInformation("Get car by id ", result);

            return Json(result);
        }
    }
}