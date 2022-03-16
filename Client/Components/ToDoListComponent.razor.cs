using BlazorSampleDB.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSampleDB.Client.Components
{
    
    public partial class ToDoListComponent
    {
        [Inject]
        public HttpClient http { get; set; }

        [Parameter]
        public List<ToDo> toDoList { get; set; }

        [Parameter]
        public EventCallback<List<ToDo>> toDoListChanged { get; set; }

        private bool startFakeservice = true;

        protected override async Task<Task> OnInitializedAsync()
        {
            if (startFakeservice)
            {
                toDoList = initFakeService();
            }

            return Task.CompletedTask;
        }

        private List<ToDo> initFakeService()
        {
            var result = new List<ToDo>
            {
                new ToDo{title="Geschirrspüler reparieren", deadline= System.DateTime.Today, description = "ganz wichtige Aufgabe"},
                new ToDo{title="Blazokomponente bauen", deadline = System.DateTime.Today, description = "Blazorkomponente mit ToDoListe bauen"},
            };
            return result;
        }
    }
}
