using Microsoft.EntityFrameworkCore;

namespace PostgreCodeFirst
{
    class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Username=postgres;Password=postgres;Database=PersonCodeFirst2;");
        }
    }
}
