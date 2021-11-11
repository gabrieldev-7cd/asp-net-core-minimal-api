using Microsoft.EntityFrameworkCore;

namespace MinAPITest.Data
{
    public class AppdbContext : DbContext
    {
        public DbSet<Todo> Todos {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}