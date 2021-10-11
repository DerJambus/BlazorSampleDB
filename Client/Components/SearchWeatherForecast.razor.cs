using BlazorSampleDB.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSampleDB.Client.Components
{
    partial class SearchWeatherForecast
    {

        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public string SearchString { get; set; }

        [Parameter]
        public List<WeatherForecast> CastList { get; set; }

        [Parameter]
        public EventCallback<List<WeatherForecast>> CastListChanged { get; set; }

        public void Search()
        {
            CastList = CastList
                .FindAll(cast => cast.Summary == SearchString || 
                cast.Date.ToShortDateString().Equals(SearchString) || 
                cast.TemperatureC.Equals(SearchString))
                .ToList();
            SubmitSearch();
       }

        public void SubmitSearch()
        {
            CastListChanged.InvokeAsync(CastList);
        }

        public async Task Reset()
        {
            CastList = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
            SearchString = "";
            SubmitSearch();
        }
    }
}
