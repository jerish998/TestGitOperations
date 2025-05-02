using Microsoft.AspNetCore.Mvc;

namespace TestGitOperations.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public ActionResult ConvertToKelvin(double value, string scale)
        {
            double kelvin;

            if (scale.ToLower() == "c")
            {
                kelvin = CelsiusToKelvin(value);
            }
            else if (scale.ToLower() == "f")
            {
                kelvin = FahrenheitToKelvin(value);
            }
            else
            {
                return new HttpStatusCodeResult(400, "Invalid scale. Use 'c' or 'f'.");
            }

            return Content($"Input: {value}°{scale.ToUpper()}, Kelvin: {kelvin} K");
        }

        // Celsius to Kelvin
        public double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }


    }
}
