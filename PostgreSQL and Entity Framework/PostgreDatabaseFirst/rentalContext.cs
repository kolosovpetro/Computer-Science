using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostgreDatabaseFirst
{
    public partial class rentalContext : DbContext
    {
        public rentalContext()
        {
        }

        public rentalContext(DbContextOptions<rentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Copies> Copies { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }
        public virtual DbSet<Starring> Starring { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=rental;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId)
                    .HasName("actors_pkey");

                entity.ToTable("actors");

                entity.Property(e => e.ActorId)
                    .HasColumnName("actor_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("clients_pkey");

                entity.ToTable("clients");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Copies>(entity =>
            {
                entity.HasKey(e => e.CopyId)
                    .HasName("copies_pkey");

                entity.ToTable("copies");

                entity.Property(e => e.CopyId)
                    .HasColumnName("copy_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Copies)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("copies_movie_id_fkey");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("employees_pkey");

                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("character varying");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("movies_pkey");

                entity.ToTable("movies");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeRestriction).HasColumnName("age_restriction");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Rentals>(entity =>
            {
                entity.HasKey(e => new { e.CopyId, e.ClientId })
                    .HasName("rentals_pkey");

                entity.ToTable("rentals");

                entity.Property(e => e.CopyId).HasColumnName("copy_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.DateOfRental)
                    .HasColumnName("date_of_rental")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DateOfReturn)
                    .HasColumnName("date_of_return")
                    .HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rentals_client_id_fkey");

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rentals_copy_id_fkey");
            });

            modelBuilder.Entity<Starring>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.MovieId })
                    .HasName("starring_pkey");

                entity.ToTable("starring");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Starring)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("starring_actor_id_fkey");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Starring)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("starring_movie_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
