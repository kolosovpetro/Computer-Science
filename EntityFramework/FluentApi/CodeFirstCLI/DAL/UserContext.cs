using CodeFirstCLI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstCLI.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=postgres;Database=CodeFirstCLI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_pkey");

                // configuring many to one Users, Team
                entity.HasOne(t => t.Team)
                    .WithMany(t => t.TeamMembers)
                    .HasForeignKey(t => t.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);

                // configure one to one User, Address
                entity.HasOne(user => user.Address)
                    .WithOne(adr => adr.User)
                    .HasForeignKey<User>(key => key.AddressId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.UserId)
                    .HasColumnName("user_id");
                entity.Property(e => e.FirstName)
                    .HasColumnName("firstname");
                entity.Property(e => e.LastName)
                    .HasColumnName("lastname");
                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id");
                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id");
                entity.ToTable("users");
                entity.HasData(
                    new User
                    {
                        UserId = 1,
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        AddressId = null,
                        TeamId = 1
                    },
                    new User
                    {
                        UserId = 2,
                        FirstName = "Alex",
                        LastName = "Ivanov",
                        AddressId = null,
                        TeamId = 1
                    },
                    new User
                    {
                        UserId = 3,
                        FirstName = "Georgii",
                        LastName = "Ivanov",
                        AddressId = null,
                        TeamId = 1
                    },
                    new User
                    {
                        UserId = 4,
                        FirstName = "Michail",
                        LastName = "Ivanov",
                        AddressId = 1,
                        TeamId = 1
                    }
                );
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("team_id");
                entity.Property(e => e.TeamName)
                    .HasColumnName("team_name");
                entity.ToTable("teams");
                entity.HasData(new Team
                {
                    Id = 1,
                    TeamName = "WSB Dream team"
                });
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId);
                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id");
                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("text");
                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("text");
                entity.Property(e => e.Street)
                    .HasColumnName("street");
                entity.Property(e => e.AptNumber)
                    .HasColumnName("apt_number");
                entity.Property(e => e.HouseNumber)
                    .HasColumnName("house_number");
                entity.Property(e => e.PostCode)
                    .HasColumnName("post_code");
                entity.ToTable("address");
                entity.HasData(new Address
                {
                    AddressId = 1,
                    Street = "Polweiska str.",
                    HouseNumber = 121,
                    AptNumber = 17,
                    City = "Poznan",
                    Country = "PL",
                    PostCode = 1337
                });
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("subscription_id");
                entity.Property(e => e.ResourceName)
                    .HasColumnName("resource_name");
                entity.Property(e => e.Yaer)
                    .HasColumnName("year");
                entity.ToTable("subscriptions");
            });

            modelBuilder.Entity<UserSubscription>(entity =>
            {
                // configure many to many, subscriptions, users
                entity.HasKey(sc => new {sc.UserId, sc.SubscriptionId});
                entity.Property(e => e.SubscriptionId)
                    .HasColumnName("subscription_id");
                entity.Property(e => e.UserId)
                    .HasColumnName("user_id");
                entity.ToTable("user_subscriptions");
            });
        }
    }
}