using BlazorSampleDB.Shared;
using Microsoft.EntityFrameworkCore;

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
