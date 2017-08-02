using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAppForBinary.Interfaces;

namespace TestAppForBinary.Controllers
{
    
    [Route("api/Manufacturers")]
    public class ManufacturersController : Controller
    {
        private readonly IWeatherService weatherService;
        private readonly ILogger<CarsController> logger;

        public ManufacturersController(IWeatherService weatherService,
            ILogger<CarsController> logger)
        {
            this.weatherService = weatherService;
            this.logger = logger;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<IActionResult> GetManufacturers()
        {
            var result = await weatherService.GetManufacturers();

            if (result == null)
            {
                logger.LogInformation("Table 'Manufacturer'is empty");

                return NotFound();
            }

            logger.LogInformation("Get list of manufacturers ", result);

            return Json(result);
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                logger.LogInformation("Bad request from user");

                return BadRequest(ModelState);
            }

            var result = await weatherService.GetManufacturer(id);


            if (result == null)
            {
                logger.LogInformation("Table 'Manufacturer' does'n contain row with id '" + id + "'");

                return NotFound();
            }

            logger.LogInformation("Get manufacturer by id ", result);

            return Json(result);
        }
    }
}
