using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSampleDB.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorSampleDB.Client.Pages
{
    public partial class ToDoList
    {
        [Inject]
        HttpClient http { get; set; }
        private List<ToDo> todos;

        private bool showdialog;

        protected override async Task OnInitializedAsync()
        {
            todos = await http.GetFromJsonAsync<List<ToDo>>("ToDo");
        }
    }
}
