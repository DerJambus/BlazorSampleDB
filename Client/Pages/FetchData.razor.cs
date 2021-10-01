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
        private List<WeatherForecast> forecasts;
        private bool _showdialog = false;
        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
        }
        private async Task Add()
        {
            _showdialog = !_showdialog;
            forecasts = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
        }

    }
}
