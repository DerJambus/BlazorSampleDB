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
    public partial class AddWeatherForecast
    {
        [Inject]
        public HttpClient http { get; set; }

        [Parameter]
        public bool ShowDialog { get; set; }
        [Parameter]
        public List<WeatherForecast> WeatherForecasts { get; set; }
        [Parameter]
        public EventCallback<bool> ShowDialogChanged { get; set; }
        [Parameter]
        public EventCallback<List<WeatherForecast>> WeatherForeCastsChanged { get; set; }

        public WeatherForecast WeathCast { get; set; }

        protected override Task OnInitializedAsync()
        {
            WeathCast = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 20
            };
            return Task.CompletedTask;
        }

        public void Reset()
        {
            WeathCast = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 20
            };
        }

        
        public void Close()
        {
            ShowDialog = !ShowDialog;
           ShowDialogChanged.InvokeAsync(ShowDialog);
            Reset();
        }

        public async Task HandleValidSubmit()
        {
            var result = await http.PostAsJsonAsync("WeatherForecast", WeathCast);
            WeatherForecasts.Add(await result.Content.ReadFromJsonAsync<WeatherForecast>());
            await WeatherForeCastsChanged.InvokeAsync();
            Close();
        }
    }
}
