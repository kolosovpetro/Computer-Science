﻿// <auto-generated />

using System;
using IdentityAndPostgres.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IdentityAndPostgres.Migrations
{
    [DbContext(typeof(RentalContext))]
    [Migration("20200515012510_CascadeDeleteEnabled")]
    partial class CascadeDeleteEnabled
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DVDRentalStore.Models.ActorsModel", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnName("actor_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnName("birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("character varying");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("character varying");

                    b.HasKey("ActorId")
                        .HasName("actors_pkey");

                    b.ToTable("actors");
                });

            modelBuilder.Entity("DVDRentalStore.Models.ClientsModel", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnName("birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("character varying");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("character varying");

                    b.HasKey("ClientId")
                        .HasName("clients_pkey");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("DVDRentalStore.Models.CopiesModel", b =>
                {
                    b.Property<int>("CopyId")
                        .HasColumnName("copy_id")
                        .HasColumnType("integer");

                    b.Property<bool?>("Available")
                        .HasColumnName("available")
                        .HasColumnType("boolean");

                    b.Property<int?>("MovieId")
                        .HasColumnName("movie_id")
                        .HasColumnType("integer");

                    b.HasKey("CopyId")
                        .HasName("copies_pkey");

                    b.HasIndex("MovieId");

                    b.ToTable("copies");
                });

            modelBuilder.Entity("DVDRentalStore.Models.EmployeesModel", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("character varying");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("character varying");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("character varying");

                    b.Property<float?>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("real");

                    b.HasKey("EmployeeId")
                        .HasName("employees_pkey");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("DVDRentalStore.Models.MoviesModel", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnName("movie_id")
                        .HasColumnType("integer");

                    b.Property<int?>("AgeRestriction")
                        .HasColumnName("age_restriction")
                        .HasColumnType("integer");

                    b.Property<float?>("Price")
                        .HasColumnName("price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("character varying");

                    b.Property<int>("Year")
                        .HasColumnName("year")
                        .HasColumnType("integer");

                    b.HasKey("MovieId")
                        .HasName("movies_pkey");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("DVDRentalStore.Models.RentalsModel", b =>
                {
                    b.Property<int>("CopyId")
                        .HasColumnName("copy_id")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateOfRental")
                        .HasColumnName("date_of_rental")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfReturn")
                        .HasColumnName("date_of_return")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CopyId", "ClientId")
                        .HasName("rentals_pkey");

                    b.HasIndex("ClientId");

                    b.ToTable("rentals");
                });

            modelBuilder.Entity("DVDRentalStore.Models.StarringModel", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnName("actor_id")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnName("movie_id")
                        .HasColumnType("integer");

                    b.HasKey("ActorId", "MovieId")
                        .HasName("starring_pkey");

                    b.HasIndex("MovieId");

                    b.ToTable("starring");
                });

            modelBuilder.Entity("DVDRentalStore.Models.CopiesModel", b =>
                {
                    b.HasOne("DVDRentalStore.Models.MoviesModel", "Movie")
                        .WithMany("Copies")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("copies_movie_id_fkey");
                });

            modelBuilder.Entity("DVDRentalStore.Models.RentalsModel", b =>
                {
                    b.HasOne("DVDRentalStore.Models.ClientsModel", "Client")
                        .WithMany("Rentals")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("rentals_client_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DVDRentalStore.Models.CopiesModel", "Copy")
                        .WithMany("Rentals")
                        .HasForeignKey("CopyId")
                        .HasConstraintName("rentals_copy_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DVDRentalStore.Models.StarringModel", b =>
                {
                    b.HasOne("DVDRentalStore.Models.ActorsModel", "Actor")
                        .WithMany("Starring")
                        .HasForeignKey("ActorId")
                        .HasConstraintName("starring_actor_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DVDRentalStore.Models.MoviesModel", "Movie")
                        .WithMany("Starring")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("starring_movie_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
