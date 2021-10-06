using BlazorSampleDB.Shared;
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
    public partial class EditWeatherForecast
    {
        [Inject]
        public HttpClient http { get; set; }

        [Parameter]
        public bool ShowDialog { get; set; }

        [Parameter]
        public WeatherForecast WeathCast { get; set; }


        [Parameter]
        public EventCallback<bool> ShowDialogChanged { get; set; }

        [Parameter]
        public EventCallback<WeatherForecast> WeathCastChanged { get; set; }

        public void Close()
        {
            ShowDialog = false;
            ShowDialogChanged.InvokeAsync(ShowDialog);
        }

        public async Task HandleValidSubmit()
        {
            var result = await http.PostAsJsonAsync("WeatherForecast/Change", WeathCast);
            await WeathCastChanged.InvokeAsync(WeathCast);
            Close();
        }

        public async void CloseWithKey(KeyboardEventArgs key)
        {
            String keyString = key.Code;
            if (keyString.Equals("Enter"))
            {
                await HandleValidSubmit();
            }

            if (keyString.Equals("Escape"))
            {
                Close();
            }
            //Console.WriteLine("Just testing: " + keyString);
        }
    }
}
