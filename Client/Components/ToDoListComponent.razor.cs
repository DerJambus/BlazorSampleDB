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
        HttpClient http { get; set; }

        private bool adding { get; set; } = false;

        private bool editing { get; set; } = false;

        public List<ToDo> toDoList { get; set; }

        private bool startFakeservice = false;

        private ToDo currentToDo { get; set; } = new ToDo();

        protected override async Task OnInitializedAsync()
        {
            if (startFakeservice)
            {
                toDoList = initFakeService();
                return;
            }


            toDoList = new List<ToDo>();
            toDoList = await http.GetFromJsonAsync<List<ToDo>>("ToDo/Load");
            currentToDo = new ToDo();
            return;
        }

        private List<ToDo> initFakeService()
        {
            var result = new List<ToDo>
            {
                new ToDo{Title="Geschirrspüler reparieren", Deadline= System.DateTime.Today, Description = "ganz wichtige Aufgabe"},
                new ToDo{Title="Blazokomponente bauen", Deadline = System.DateTime.Today, Description = "Blazorkomponente mit ToDoListe bauen"},
            };

            return result;
        }

        protected async Task Delete(ToDo t)
        {
            if (!startFakeservice)
            {
                var result = await http.PostAsJsonAsync("ToDo/Delete", t);
            }
            toDoList.Remove(t);
            return;
        }

        protected Task Add()
        {
            adding = true;
            return Task.CompletedTask;
        }

        protected Task ToDoCreated(ToDo t)
        {
            currentToDo = t;
            toDoList.Add(currentToDo);
            return Task.CompletedTask;
        }

        protected Task Change(ToDo t)
        {
            currentToDo = t;
            editing = true;
            return Task.CompletedTask;
        }
    }
}
