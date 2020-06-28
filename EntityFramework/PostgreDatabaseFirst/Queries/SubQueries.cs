using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PostgreDatabaseFirst.Comparers;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;
using PostgreDatabaseFirst.ViewModels;

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

        public class GroupRentals
        {
            public string LastName { get; }
            public int RentalsCount { get; }
            public int TotalRentals { get; }

            public GroupRentals(string lastName, int rentalsCount, int totalRentals)
            {
                LastName = lastName;
                RentalsCount = rentalsCount;
                TotalRentals = totalRentals;
            }
        }

        public List<GroupRentals> Task6()
        {
            var totalRentals = _rentals.Count();
            var rentalsGroup =
                from rental in _rentals
                join client in _clients on rental.ClientId equals client.ClientId
                group client by new { client.ClientId, client.LastName }
                into groupRentals
                orderby groupRentals.Key.LastName
                select new GroupRentals(groupRentals.Key.LastName, groupRentals.Count(), totalRentals);

            return rentalsGroup.ToList();
        }

        // Task 7: Display names of actors and titles of movies, that starred also Jean Reno.
        // Order by movie titles
        public class MovieActorModel
        {
            public string Title { get; }
            public string FirstName { get; }
            public string LastName { get; }

            public MovieActorModel(string title, string firstName, string lastName)
            {
                Title = title;
                FirstName = firstName;
                LastName = lastName;
            }
        }

        public List<MovieActorModel> Task7()
        {
            var joinActors =
                from actor in _actors
                join star in _starring on actor.ActorId equals star.ActorId
                join movie in _movies on star.MovieId equals movie.MovieId
                select new MovieActorModel(movie.Title, actor.FirstName, actor.LastName);

            var renoMovies = joinActors
                .AsEnumerable()
                .Where(x => x.FirstName == "Jean" && x.LastName == "Reno")
                .Select(t => t.Title)
                .ToList();

            var moviesWithReno = joinActors
                .AsEnumerable()
                .Where(x => renoMovies.Contains(x.Title))
                .OrderBy(t => t.Title)
                .ToList();

            return moviesWithReno.ToList();
        }

        // Task 8: Display names and birthdays of clients with age greater than the average age.
        // Age can be calculated by subtracting birthday from NOW().
        public class ClientSelect
        {
            public string FirstName { get; }
            public string LastName { get; }
            public DateTime? Birthday { get; }

            public ClientSelect(string firstName, string lastName, DateTime? birthday)
            {
                FirstName = firstName;
                LastName = lastName;
                Birthday = birthday;
            }
        }

        public List<ClientSelect> Task8()
        {
            var avgAge = _clients.Average(x => DateTime.Today.Year - x.Birthday.Value.Year);
            var clients = _clients
                .Where(x => DateTime.Today.Year - x.Birthday.Value.Year > avgAge)
                .Select(t => new ClientSelect(t.FirstName, t.LastName, t.Birthday))
                .ToList();

            return clients;
        }

        // Task 9: Display names of clients that rented the same copies of movies as Brian Griffin
        
        public List<ClientViewModel> Task9()
        {
            var collection =
                from rental in _rentals
                join client in _clients on rental.ClientId equals client.ClientId
                select new ClientModel(rental.CopyId, client.FirstName, client.LastName);

            var enumCollection = collection.AsEnumerable().ToList();

            var griffinCopies = enumCollection
                .Where(x => x.FirstName == "Brian" && x.LastName == "Griffin")
                .Select(t => t.CopyId);

            List<ClientViewModel> res = enumCollection
                .Where(x => griffinCopies.Contains(x.CopyId))
                .Select(t => new ClientViewModel(t.FirstName, t.LastName))
                .Distinct(new ClientNameComparer())
                .ToList();

            return res;
        }
    }
}