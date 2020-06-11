using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;

namespace PostgreDatabaseFirst.Queries
{
    internal class SubQueries
    {
        private readonly RentalContext _rentalContext = new RentalContext();
        private readonly DbSet<Movies> _movies;
        private readonly DbSet<Copies> _copies;
        private readonly DbSet<Rentals> _rentals;
        private readonly DbSet<Clients> _clients;
        private readonly DbSet<Starring> _starring;
        private readonly DbSet<Actors> _actors;

        public SubQueries()
        {
            _movies = _rentalContext.Movies;
            _copies = _rentalContext.Copies;
            _rentals = _rentalContext.Rentals;
            _clients = _rentalContext.Clients;
            _starring = _rentalContext.Starring;
            _actors = _rentalContext.Actors;
        }

        // Task 1: Display the title of the most expensive movie. Do not use keyword LIMIT.
        public Movies Task1()
        {
            var maxPrice = _movies.Max(p => p.Price);
            var mostExpansive = _movies
                .Single(x => x.Price == maxPrice);
            return mostExpansive;
        }

        // Task 2: Display the name of the client that made the first rental in the history.
        // Do not use keyword LIMIT.
        public class FirstRentalModel
        {
            public string FirstName { get; }
            public string LastName { get; }

            public FirstRentalModel(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        public FirstRentalModel Task2()
        {
            var firstRental = _rentals.Min(x => x.DateOfRental);
            var clientModel =
                from rental in _rentals
                join client in _clients on rental.ClientId equals client.ClientId
                where rental.DateOfRental == firstRental
                select new FirstRentalModel(client.FirstName, client.LastName);

            return clientModel.FirstOrDefault();
        }

        // Task 3: Display movie titles that are available for rental. Do not use JOINs.
        public List<string> Task3()
        {
            var availableCopies = _copies
                .Where(x => (bool)x.Available)
                .Select(t => t.MovieId);
            var availableMovies = _movies
                .Where(x => availableCopies.Contains(x.MovieId))
                .Select(t => t.Title)
                .ToList();

            return availableMovies;
        }

        // Task 4: Display titles of movies, with price greater than price of movie ’Frantic’.
        public List<string> Task4()
        {
            var franticPrice = _movies
                .Where(x => x.Title == "Frantic")
                .Select(t => t.Price)
                .FirstOrDefault();

            var titles = _movies
                .Where(x => x.Price > franticPrice)
                .Select(t => t.Title)
                .ToList();

            return titles;
        }

        // Task 5: Display titles of movies, with price greater than
        // price of all the movies produced before 1980.
        public List<string> Task5()
        {
            var maxPrice = _movies
                .Where(x => x.Year < 1980)
                .Max(t => t.Price);

            var titles = _movies
                .Where(x => x.Price > maxPrice)
                .Select(t => t.Title)
                .ToList();

            return titles;
        }

        // Task 6: For each client display it’s last name, count of all the rentals
        // he or she made and total number of rentals in the whole rental store.
        // Order results by lastname.
    }
}
