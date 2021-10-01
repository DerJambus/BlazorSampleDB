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
        public EventCallback<List<WeatherForecast>> CastListChanged { get; set; }

        public WeatherForecast WeathCast { get; set; } = new WeatherForecast();


        public void Reset()
        {
            WeathCast = new WeatherForecast { };
        }

        public void Show()
        {
            Reset();
            ShowDialog = !ShowDialog;
        }

        public void Close()
        {
            ShowDialog = !ShowDialog;
            Reset();
            ShowDialogChanged.InvokeAsync(ShowDialog);
        }

        public async Task HandleValidSubmit()
        {
            var result = await http.PostAsJsonAsync("WeatherForecast", WeathCast);
            WeatherForecasts.Add(await result.Content.ReadFromJsonAsync<WeatherForecast>());
            CastListChanged.InvokeAsync(WeatherForecasts);
            Close();
        }
    }
}
