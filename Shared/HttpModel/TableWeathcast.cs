using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSampleDB.Shared.HttpModel
{
    public class TableWeathcast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public TableWeathcast(WeatherForecast cast)
        {
            TemperatureC = cast.TemperatureC;
            Summary = cast.Summary;
            Id = cast.Id;
            Date = cast.Date;
        }

    }

    public class TableWeathcastCollection
    {
        public List<TableWeathcast> list { get; set; }

        public TableWeathcastCollection()
        {
            list = new List<TableWeathcast>();
        }

        public TableWeathcastCollection( IEnumerable<TableWeathcast> WeathCasts)
        {
            list = WeathCasts.ToList();
        }
    }
}
