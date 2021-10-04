using BlazorSampleDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSampleDB.Client.Components;

namespace BlazorSampleDB.Client.Pages
{
    public partial class FetchData
    {
        private List<WeatherForecast> forecasts = new List<WeatherForecast>();
        private bool _showdialog = false;
        private WeatherForecast _weathCast;
        
        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
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

    }
}
