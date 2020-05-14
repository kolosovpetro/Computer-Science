using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Migrations;

namespace PostgreCodeFirst
{
    class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        private DbMigrationsConfiguration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Username=postgres;Password=postgres;Database=PersonCodeFirst2;");
        }
    }
}
