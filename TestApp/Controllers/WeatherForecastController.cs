using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            // var data = await _context.Forecasts.ToListAsync();

            var data = new List<Product>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Code = "Test One",
                    Name = "Test"
                },
                new() {
                    Id = Guid.NewGuid(),
                    Code = "Test Two",
                    Name = "Test Two"
                }
            };

            return Ok(data);
        }

        [HttpPost(Name = "CreateWeatherForecast")]
        public async Task<IActionResult> Create(WeatherForecast forcast)
        {
            _context.Forecasts.Add(forcast);
            _context.SaveChanges();
            return Ok(forcast);
        }
    }
}
