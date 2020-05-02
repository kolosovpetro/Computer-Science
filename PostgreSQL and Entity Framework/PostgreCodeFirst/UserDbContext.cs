using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PostgreCodeFirst
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["UsersDb"].ConnectionString);
        }
    }
}
