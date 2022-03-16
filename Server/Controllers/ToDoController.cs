using BlazorSampleDB.Server.Database;
using BlazorSampleDB.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorSampleDB.Server.Controllers
{
    [ApiController]
    [Route("ToDo")]
    public class ToDoController : ControllerBase
    {
        private ToDoContext _todos = new ToDoContext();

        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _todos.todolist;
        }

        [HttpPost]
        public ActionResult<ToDo> Push(ToDo t)
        {
            _todos.todolist.Add(t);
            _todos.SaveChanges();
            return Ok(t);
        }

        [HttpPost("Delete")]
        public ActionResult<ToDo> Remove(ToDo t)
        {
            var temp = _todos.todolist.First(x => x.id == t.id);
            _todos.todolist.Remove(temp);
            _todos.SaveChanges();
            return Ok(t);
        }

        [HttpPost("Edit")]
        public ActionResult<ToDo> Edit(ToDo t)
        {
            var temp = _todos.todolist.First(x => x.id == t.id);
            temp.title = t.title;
            temp.description = t.description;
            temp.deadline = t.deadline;
            _todos.SaveChanges();
            return Ok(t);
        }
    }
}
