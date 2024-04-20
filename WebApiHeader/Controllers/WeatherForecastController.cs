using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WebApiHeader.Controllers
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
        [HttpPost]
        public IActionResult Post([FromBody]WeatherForecast model)
        {
            // Header bilgisi sayfanýn üst bilgisidir. 
            // Mesaj içerisinde gönderilmeyen datalar üst bilgi olarak gönderilir.
            // Bu apiye postman tarafýndan yada baþka bir uygulamadan gönderilen tüm header bilgileri aþaðýdaki þekilde yakalabilir.
            string ustBilgi = Request.Headers["HeaderField"].ToString();
            return Ok();
        }
    }
}
