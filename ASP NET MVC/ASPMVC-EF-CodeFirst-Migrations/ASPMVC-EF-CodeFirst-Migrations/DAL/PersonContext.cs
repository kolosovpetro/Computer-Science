using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ASPMVC_EF_CodeFirst_Migrations.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPMVC_EF_CodeFirst_Migrations.DAL
{
    public class PersonContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }

        public PersonContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["CodeFirst"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.Entity<Person>().HasData(
                new Person { FirstName = "Petro", LastName = "Kolosov" },
                new Person { FirstName = "Andrey", LastName = "Vasilyev" },
                new Person { FirstName = "Alex", LastName = "Ivanov" },
                new Person { FirstName = "Alla", LastName = "Velichko" },
                new Person { FirstName = "Valeriy", LastName = "Kramer" }
            );
        }
    }
}
