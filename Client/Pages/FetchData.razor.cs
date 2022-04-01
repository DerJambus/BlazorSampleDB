using BlazorSampleDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSampleDB.Client.Components;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using BlazorSampleDB.Shared.HttpModel;

namespace BlazorSampleDB.Client.Pages
{
    public partial class FetchData
    {
        [Inject]
        HttpClient Http { get; set; }
        private List<WeatherForecast> forecasts = new List<WeatherForecast>();
        private bool _showdialog = false;
        private string searchstring;
        private bool _showdialogEdit = false;
        public WeatherForecast _weathCast;
        protected override async Task OnInitializedAsync()
        {
            //forecasts = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
            var temp = new TableWeathcastCollection();

            temp = await Http.GetFromJsonAsync<TableWeathcastCollection>("WeatherForecast/UseWrapper");

            foreach (var weather in temp.WeathCasts)
            {
                forecasts.Add(new WeatherForecast
                {
                    Date = weather.Date,
                    Id = weather.Id,
                    Summary = weather.Summary,
                    TemperatureC = weather.TemperatureC,
                });
            }
            _weathCast = new WeatherForecast();
        }
        private Task Add()
        {
            _showdialog = !_showdialog;
            return Task.CompletedTask;
        }

        public Task ForeCastCreated(WeatherForecast cast)
        {
            forecasts.Add(cast);
            return Task.CompletedTask;
        }

        public Task Edit(WeatherForecast cast)
        {
            _weathCast = cast;
            _showdialogEdit = !_showdialogEdit;
            return Task.CompletedTask;
        }

        public void Search(string str)
        {

        }

        protected async Task Delete(WeatherForecast cast)
        {
            var result = await Http.PostAsJsonAsync("WeatherForecast/Delete", cast);
            forecasts.Remove(cast);
            return;
        }

        public void CloseWithKey(KeyboardEventArgs key)
        {
            if (key.Code == "ESC" || key.Code == "Esc")
            {
                Console.WriteLine("Esc key has triggered");

            }



        }

        public void Search()
        {
            string str = searchstring;
            List<WeatherForecast> result = forecasts.FindAll(cast => cast.Summary == str).ToList();
            Console.WriteLine(str);
            foreach (var element in result)
            {
                Console.WriteLine(element.toString());
            }
            Console.WriteLine(searchstring + " Just testing");
        }
    }
}
