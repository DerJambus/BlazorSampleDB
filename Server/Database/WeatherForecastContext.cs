using BlazorSampleDB.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSampleDB.Server.Database
{
    public class WeatherForecastContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=WeatherForecastDB");
        }
    }
}
