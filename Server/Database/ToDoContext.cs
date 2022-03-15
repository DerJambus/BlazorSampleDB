using BlazorSampleDB.Shared;
using Microsoft.EntityFrameworkCore;
namespace BlazorSampleDB.Server.Database
{
    public class ToDoContext:DbContext
    {

        public DbSet<ToDo> todolist { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=ToDoDB");
        }

    }
}
