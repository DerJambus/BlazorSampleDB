﻿using BlazorSampleDB.Shared;
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
        private bool _showdialogEdit = false;
        public WeatherForecast _weathCast;
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

        public Task Edit(WeatherForecast cast)
        {
            _weathCast = cast;
            _showdialogEdit = !_showdialogEdit;
            return Task.CompletedTask;
        }

        protected async Task Delete(WeatherForecast cast)
        {            
            var result = await Http.PostAsJsonAsync("WeatherForecast/Delete", cast);
            forecasts.Remove(cast);
            return;
        }
    }
}