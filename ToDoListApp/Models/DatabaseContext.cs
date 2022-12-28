using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<ToDoModel>ToDoLists{ get; set; }
    }
}
