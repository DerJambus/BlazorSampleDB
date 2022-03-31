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
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        
        private WeatherForecastContext _context = new WeatherForecastContext();



        [HttpGet("UseWrapper")]
        public async Task<ActionResult<Shared.HttpModel.TableWeathcastCollection>> GetWithWrapper()
        {
            var casts = new List<Shared.HttpModel.TableWeathcast>();

            foreach (var weather in _context.WeatherForecasts)
            {
                var temp = new Shared.HttpModel.TableWeathcast(weather);
                casts.Add(temp);
            }

            return new Shared.HttpModel.TableWeathcastCollection(casts);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _context.WeatherForecasts.ToList();
        }

        [HttpPost]
        public ActionResult<WeatherForecast> Push(WeatherForecast weather)
        {
            _context.WeatherForecasts.Add(weather);
            _context.SaveChanges();
            return Ok(weather);
        }

        [HttpPost("Delete")]
        public ActionResult<WeatherForecast> Remove(WeatherForecast cast)
        {
            var temp = _context.WeatherForecasts.First(x => x.Id == cast.Id);
            _context.WeatherForecasts.Remove(temp);
            _context.SaveChanges();
            return Ok(cast);
        }

        [HttpPost("Change")]
        public ActionResult<WeatherForecast> Edit(WeatherForecast cast)
        {
            WeatherForecast obj = _context.WeatherForecasts.First(x => x.Id == cast.Id);
            obj.Date = cast.Date;
            obj.Summary = cast.Summary;
            obj.TemperatureC = cast.TemperatureC;
            _context.SaveChanges();
            return Ok(cast);
        }
    }
}
