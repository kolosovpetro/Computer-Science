using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;

namespace PostgreDatabaseFirst.Queries
{
    internal class GroupQueries
    {
        private readonly RentalContext _rentalContext = new RentalContext();
        private readonly DbSet<Movies> _movies;
        private readonly DbSet<Copies> _copies;
        private readonly DbSet<Rentals> _rentals;
        private readonly DbSet<Clients> _clients;
        private readonly DbSet<Starring> _starring;
        private readonly DbSet<Actors> _actors;

        public GroupQueries()
        {
            _movies = _rentalContext.Movies;
            _copies = _rentalContext.Copies;
            _rentals = _rentalContext.Rentals;
            _clients = _rentalContext.Clients;
            _starring = _rentalContext.Starring;
            _actors = _rentalContext.Actors;
        }

        // Task 1: Display the names of all clients and actors. Order the results by last name.
        public List<(string, string)> Task1()
        {
            var clients = _clients
                .Select(x => new ValueTuple<string, string>(x.FirstName, x.LastName))
                .AsEnumerable();
            var actors = _actors
                .Select(x => new ValueTuple<string, string>(x.FirstName, x.LastName))
                .AsEnumerable();
            var obj = clients.Union(actors)
                .OrderBy(x => x.Item2)
                .ToList();

            return obj;
        }

        // Task 2: Display titles of movies in which both De Niro and Reno played.
        public List<string> Task2()
        {
            var obj =
                from mov in _movies
                join star in _starring on mov.MovieId equals star.MovieId
                join actor in _actors on star.ActorId equals actor.ActorId
                select new ValueTuple<string, string>(mov.Title, actor.LastName);

            var deNiroMovies = obj
                .AsEnumerable()
                .Where(x => x.Item2 == "De Niro")
                .Select(t => t.Item1);

            var renoMovies = obj
                .AsEnumerable()
                .Where(x => x.Item2 == "Reno")
                .Select(t => t.Item1);

            var query = renoMovies
                .Intersect(deNiroMovies)
                .ToList();

            return query;
        }

        // Task 3: Display titles of movies that were rented by both Gary Goodspeed and Brian Griffin
        public List<string> Task3()
        {
            var obj =
                from rent in _rentals
                join copy in _copies on rent.CopyId equals copy.CopyId
                join movie in _movies on copy.MovieId equals movie.MovieId
                join client in _clients on rent.ClientId equals client.ClientId
                select new ValueTuple<string, string, string>(movie.Title, client.FirstName, client.LastName);

            var goodspeed = obj
                .AsEnumerable()
                .Where(x => x.Item2 == "Gary" && x.Item3 == "Goodspeed")
                .Select(t => t.Item1);

            var griffin = obj
                .AsEnumerable()
                .Where(x => x.Item2 == "Brian" && x.Item3 == "Griffin")
                .Select(t => t.Item1);

            var result = goodspeed.Intersect(griffin).ToList();

            return result;
        }

        // Task 4: Display titles of movies that were rented by Gary Goodspeed and were never rented by Brian Griffin
        public List<string> Task4()
        {
            var obj =
                from rent in _rentals
                join copy in _copies on rent.CopyId equals copy.CopyId
                join movie in _movies on copy.MovieId equals movie.MovieId
                join client in _clients on rent.ClientId equals client.ClientId
                select new ValueTuple<string, string, string>(movie.Title, client.FirstName, client.LastName);

            var goodspeed = obj
                .AsEnumerable()
                .Where(x => x.Item2 == "Gary" && x.Item3 == "Goodspeed")
                .Select(t => t.Item1);

            var griffin = obj
                .AsEnumerable()
                .Where(x => x.Item2 == "Brian" && x.Item3 == "Griffin")
                .Select(t => t.Item1);

            var result = goodspeed.Except(griffin).ToList();

            return result;
        }

        // Task 5: Display names of actors that played in 'Terminator' but never played in 'Ghostbusters'
        public List<(string, string)> Task5()
        {
            var obj =
                from mov in _movies
                join star in _starring on mov.MovieId equals star.MovieId
                join actor in _actors on star.ActorId equals actor.ActorId
                select new ValueTuple<string, string, string>(mov.Title, actor.FirstName, actor.LastName);

            var terminator = obj
                .AsEnumerable()
                .Where(x => x.Item1 == "Terminator")
                .Select(t => new ValueTuple<string, string>(t.Item2, t.Item3));

            var ghostbusters = obj
                .AsEnumerable()
                .Where(x => x.Item1 == "Ghostbusters")
                .Select(t => new ValueTuple<string, string>(t.Item2, t.Item3));

            var result = terminator.Except(ghostbusters).ToList();
            return result;
        }

        // Task 6: Display the price of the most expensive movie in the store
        public float? Task6()
        {
            var obj = _movies.Max(x => x.Price);
            return obj;
        }

        // Task 7: Display the number of movies produced in 1984
        public int Task7()
        {
            var obj = _movies
                .Where(j => j.Year == 1984)
                .GroupBy(x => x.Year)
                .Select(t => t.Count()).FirstOrDefault();

            return obj;
        }

        // Task 8: How many time movie 'Taxi Driver' was rented?
        public int Task8()
        {
            var obj =
                from rental in _rentals
                join copy in _copies on rental.CopyId equals copy.CopyId
                join movie in _movies on copy.MovieId equals movie.MovieId
                select new ValueTuple<string>(movie.Title);

            var result = obj
                .AsEnumerable()
                .Where(x => x.Item1 == "Taxi Driver")
                .GroupBy(t => t.Item1)
                .Select(j => j.Count())
                .FirstOrDefault();

            return result;
        }

        // Task 9: For every year of production, display the average price of the movie.
        // Order the results by year
        public List<(int, float?)> Task9()
        {
            var obj = _movies
                .AsEnumerable()
                .GroupBy(x => x.Year)
                .Select(t =>
                    new ValueTuple<int, float?>(t.Key, t.Average(p => p.Price)))
                .OrderBy(j => j.Item1)
                .ToList();

            return obj;
        }

        // Task 10: What was the average rental time of 'Ronin'?
        public double Task10()
        {
            var collection =
                from rental in _rentals
                join copy in _copies on rental.CopyId equals copy.CopyId
                join movie in _movies on copy.MovieId equals movie.MovieId
                select new ValueTuple<string, DateTime?, DateTime?>(movie.Title, rental.DateOfRental,
                    rental.DateOfReturn);

            var obj = collection
                .AsEnumerable()
                .Where(g => g.Item1 == "Ronin")
                .GroupBy(x => x.Item1)
                .Select(t => t.Average(p => (p.Item3 - p.Item2).Value.TotalDays))
                .FirstOrDefault();

            return obj;
        }

        // Task 11. For each movie display its title, minimum, maximum and average rental
        // time, as well as number of times it was rented.
        // Order the results from most popular movie to least one.
        public List<(string, double, double, double, int)> Task11()
        {
            var collection =
                from rental in _rentals
                join copy in _copies on rental.CopyId equals copy.CopyId
                join movie in _movies on copy.MovieId equals movie.MovieId
                select new ValueTuple<string, DateTime?, DateTime?>(movie.Title, rental.DateOfRental,
                    rental.DateOfReturn);

            var obj = collection
                .AsEnumerable()
                .GroupBy(x => x.Item1)
                .Select(t => new ValueTuple<string, double, double, double, int>
                (t.Key,
                    t.Min(p => (p.Item3 - p.Item2).Value.TotalDays),
                    t.Max(p => (p.Item3 - p.Item2).Value.TotalDays),
                    t.Average(p => (p.Item3 - p.Item2).Value.TotalDays),
                    t.Count()
                ))
                .OrderBy(x => x.Item3)
                .ToList();

            return obj;
        }

        // Task 12: For every client display its first, last name and number of rentals.
        // Order the results by last names
        public List<(string, string, int)> Task12()
        {
            var collection =
                from rental in _rentals
                join client in _clients on rental.ClientId equals client.ClientId
                group client by new
                {
                    client.FirstName,
                    client.LastName
                }
                into clientGroup
                orderby clientGroup.Key.LastName
                select new ValueTuple<string, string, int>
                (
                    clientGroup.Key.FirstName,
                    clientGroup.Key.LastName,
                    clientGroup.Count()
                );

            return collection.ToList();
        }

        // Task 13: For every actor display the number of movies in which he/she played.
        // Skip actors, that played in only one movie
        public List<(string, int)> Task13()
        {
            var collection =
                from movie in _movies
                join star in _starring on movie.MovieId equals star.MovieId
                join actor in _actors on star.ActorId equals actor.ActorId
                group actor by actor.LastName
                into actorGroup
                where actorGroup.Count() > 1
                select new ValueTuple<string, int>
                (
                    actorGroup.Key,
                    actorGroup.Count()
                );

            return collection.ToList();
        }

        // Task 14: For every client display the total amount of money he or she spent on renting movies
        public class ClientMovieGroup
        {
            public string LastName { get; }
            public float? Sum { get; }

            public ClientMovieGroup(string lastName, float? sum)
            {
                LastName = lastName;
                Sum = sum;
            }
        }

        public List<ClientMovieGroup> Task14()
        {
            var obj =
                from rental in _rentals
                join copy in _copies on rental.CopyId equals copy.CopyId
                join movie in _movies on copy.CopyId equals movie.MovieId
                join client in _clients on rental.ClientId equals client.ClientId
                group new { rental, movie } by new
                {
                    client.LastName,
                    movie.Price
                }
                into clientMovieGroup
                select new ClientMovieGroup(clientMovieGroup.Key.LastName, clientMovieGroup.Sum(x => x.movie.Price));

            return obj.ToList();
        }
    }
}
