using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PostgreCodeFirst
{
    class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["PersonsDb"].ConnectionString);
        }
    }
}
