﻿using BlazorSampleDB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
        private WeatherForecast _weathCast { get; set; }
        [Inject]
        public HttpClient http { get; set; }
        [Parameter]
        public bool ShowDialog { get; set; }
        [Parameter]
        public EventCallback<bool> ShowDialogChanged { get; set; }

        [Parameter]
        public EventCallback<WeatherForecast> WeatherForecastCreated { get; set; }

        protected override Task OnInitializedAsync()
        {
            _weathCast = new WeatherForecast
            {
                Date = DateTime.Now,
            };
            return Task.CompletedTask;
        }

        public void Reset()
        {
            _weathCast = new WeatherForecast
            {
                Date = DateTime.Now
            };
        }


        public void Close()
        {
            ShowDialog = false;
            ShowDialogChanged.InvokeAsync(ShowDialog);
        }

        public async Task HandleValidSubmit()
        {
            var result = await http.PostAsJsonAsync("WeatherForecast", _weathCast);
            _weathCast = await result.Content.ReadFromJsonAsync<WeatherForecast>();
            await WeatherForecastCreated.InvokeAsync(_weathCast);
            Close();
        }


        public
            void CloseWithKey(KeyboardEventArgs key)
        {
            if(key.Code == "Escape")
            {
                Close();
            }
        }
    }
}
