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

        [HttpGet("Load")]
        public IEnumerable<ToDo> Get()
        {
            var result = _todos.Todos.ToList();
            return result;
        }
        
        [HttpPost("Add")]
        public ActionResult<ToDo> Push(ToDo t)
        {
            _todos.Todos.Add(t);
            _todos.SaveChanges();
            return Ok(t);
        }

        [HttpPost("Delete")]
        public ActionResult<ToDo> Remove(ToDo t)
        {
            var temp = _todos.Todos.First(x => x.Id == t.Id);
            _todos.Todos.Remove(temp);
            _todos.SaveChanges();
            return Ok(t);
        }

        [HttpPost("Edit")]
        public ActionResult<ToDo> Edit(ToDo t)
        {
            var temp = _todos.Todos.First(x => x.Id == t.Id);
            temp.Title = t.Title;
            temp.Description = t.Description;
            temp.Deadline = t.Deadline;
            _todos.SaveChanges();
            return Ok(t);
        }
    }
}
