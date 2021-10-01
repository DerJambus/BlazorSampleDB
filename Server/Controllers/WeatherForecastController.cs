using BlazorSampleDB.Server.Database;
using BlazorSampleDB.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSampleDB.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static WeatherForecastContext _context = new WeatherForecastContext();
       
       

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _context.WeatherForecasts.ToList();
        }

        // erweitern um ein Delete

        [HttpPost]
        public ActionResult<WeatherForecast> Push(WeatherForecast weather)
        {
            _context.WeatherForecasts.Add(weather);
            _context.SaveChanges();
            return Ok(weather);
        }

    }
}
