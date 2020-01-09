using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Jan", "Tomek", "Bartek", "Wojtek", "Oskar", "Michal", "Maciek", "Mateusz", "Jakub", "Jhon"
        };

        private static readonly string[] Summaries2 = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Rezerwacja> Get()
        {

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Rezerwacja
            {
                Id_Rezerwacji = index,
                _Klient = new Klient() { Id_Klient = rng.Next(-20, 55), Imie = Summaries[rng.Next(Summaries.Length)], Nazwisko = Summaries[rng.Next(Summaries2.Length)] },
                _Pokoj = new Pokoj() { Nr_Pokoju = index + rng.Next(100), Wolny = false },
                Data_Rozpoczecia_Rezerwacji = new DateTime().AddDays(rng.Next(5)),
                Data_Zakonczenia_Rezerwacji = new DateTime().AddDays(rng.Next(5))
            })
            .ToArray();
        }
    }
}
