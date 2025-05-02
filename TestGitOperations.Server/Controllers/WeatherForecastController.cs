using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

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

        [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetWeatherForecast")]
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

        // Action method to use the conversion
        public System.Web.Mvc.ActionResult ConvertToKelvin(double value, string scale)
        {
            try
            {
                double kelvin = ToKelvin(value, scale);
                return ActionResult($"Input: {value}°{scale.ToUpper()}, Kelvin: {kelvin} K");
            }
            catch (ArgumentException ex)
            {
                return new HttpStatusCodeResult(400, ex.Message);
            }
        }

        #region helper
        // Unified method to convert to Kelvin
        public double ToKelvin(double value, string scale)
        {
            scale = scale.ToLower();

            if (scale == "c")
            {
                return value + 273.15;
            }
            else if (scale == "f")
            {
                return (value - 32) * 5.0 / 9.0 + 273.15;
            }
            else
            {
                throw new ArgumentException("Invalid scale. Use 'c' for Celsius or 'f' for Fahrenheit.");
            }
        }
        #endregion



       public void Add()
        {
            int a = 10;
            int b = 10;
            int sum = a + b;
        }
    }
}
