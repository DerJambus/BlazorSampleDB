using System;

namespace BlazorSampleDB.Shared
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string toString()
        {
            string result = "";
            result += this.Date + " " + this.TemperatureC + " " + this.TemperatureF + " " + this.Summary; 
            return result;
        }
    }
}
