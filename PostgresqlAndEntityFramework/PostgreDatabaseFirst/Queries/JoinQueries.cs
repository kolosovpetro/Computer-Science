using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;

namespace PostgreDatabaseFirst.Queries
{
    internal class JoinQueries
    {
        private readonly RentalContext _rentalContext = new RentalContext();
        private readonly DbSet<Movies> _movies;
        private readonly DbSet<Copies> _copies;
        private readonly DbSet<Rentals> _rentals;
        private readonly DbSet<Clients> _clients;
        private readonly DbSet<Starring> _starring;
        private readonly DbSet<Actors> _actors;

        public JoinQueries()
        {
            _movies = _rentalContext.Movies;
            _copies = _rentalContext.Copies;
            _rentals = _rentalContext.Rentals;
            _clients = _rentalContext.Clients;
            _starring = _rentalContext.Starring;
            _actors = _rentalContext.Actors;
        }

        // Task 1: For every copy display it’s ID and title of the movie. Order the results by
        // copy ID
        public List<Tuple<int, string>> Task1()
        {
            var result = (from mov in _movies
                          join cop in _copies on mov.MovieId equals cop.MovieId
                          select new Tuple<int, string>(cop.CopyId, mov.Title))
                .ToList();

            return result;
        }

        // Task 2: Display the titles of all the movies with copies 
        // available in the rental store.
        // Eliminate duplicates
        public List<string> Task2()
        {
            var result = (from movie in _movies
                          join copy in _copies on movie.MovieId equals copy.MovieId
                          select new
                          {
                              copy.Available,
                              movie.Title
                          })
                .Where(t => (bool)t.Available)
                .Select(j => j.Title)
                .Distinct()
                .ToList();

            return result;
        }

        // Task 3: Display IDs of copies of movies produced in 1984
        public List<int> Task3()
        {
            var obj = (from movie in _movies
                       join copy in _copies on movie.MovieId equals copy.MovieId
                       select new
                       {
                           copy.CopyId,
                           movie.Year
                       })
                .Where(x => x.Year == 1984)
                .Select(t => t.CopyId)
                .OrderBy(h => h)
                .ToList();

            return obj;
        }

        // Task 4: For every rental display date of rental, date of return 
        // and name of client that made the rental
        public List<(DateTime?, DateTime?, string)> Task4()
        {
            var obj = (from rent in _rentals
                       join client in _clients on rent.ClientId equals client.ClientId
                       select new ValueTuple<DateTime?, DateTime?, string>(rent.DateOfRental, rent.DateOfReturn,
                           client.FirstName))
                .ToList();

            return obj;
        }

        // Task 5: For every rental display name of the client that made the rental and title
        // of the rented movie
        public List<(string, string, string)> Task5()
        {
            var obj = (from rent in _rentals
                       join client in _clients on rent.ClientId equals client.ClientId
                       join copy in _copies on rent.CopyId equals copy.CopyId
                       join movie in _movies on copy.MovieId equals movie.MovieId
                       select new ValueTuple<string, string, string>(client.FirstName, client.LastName, movie.Title))
                .ToList();

            return obj;
        }

        // Task 6: Display titles and years of production of all the movies rented 
        // by Gary Goodspeed
        public List<string> Task6()
        {
            var obj = (from rent in _rentals
                       join cl in _clients on rent.ClientId equals cl.ClientId
                       join cop in _copies on rent.CopyId equals cop.CopyId
                       join mov in _movies on cop.MovieId equals mov.MovieId
                       select new
                           ValueTuple<string, string, string, int>(cl.FirstName, cl.LastName, mov.Title, mov.Year))
                .AsEnumerable()
                .Where(x => x.Item1 == "Gary" && x.Item2 == "Goodspeed")
                .Select(x => $"{x.Item3}, {x.Item4}")
                .ToList();

            return obj;
        }

        // Task 7: Display name of the client, that made the first rental in the history
        public string Task7()
        {
            var obj = (from rent in _rentals
                       join cl in _clients on rent.ClientId equals cl.ClientId
                       select new ValueTuple<string, DateTime?>(cl.FirstName, rent.DateOfRental))
                .AsEnumerable()
                .OrderBy(t => t.Item2)
                .Select(j => j.Item1)
                .ToList()
                .FirstOrDefault();

            return obj;
        }

        // Task 8: Display last names of actors, that played in "Terminator"
        public List<string> Task8()
        {
            var obj = (from mov in _movies
                       join star in _starring on mov.MovieId equals star.MovieId
                       join act in _actors on star.ActorId equals act.ActorId
                       select new ValueTuple<string, string>(act.LastName, mov.Title))
                .AsEnumerable()
                .Where(x => x.Item2 == "Terminator")
                .Select(t => t.Item1)
                .ToList();

            return obj;
        }

        // Task 9: Display titles of all movies that starred Robert De Niro
        public List<string> Task9()
        {
            var obj = (from mov in _movies
                       join star in _starring on mov.MovieId equals star.MovieId
                       join act in _actors on star.ActorId equals act.ActorId
                       select new ValueTuple<string, string, string>(mov.Title, act.FirstName, act.LastName))
                .AsEnumerable()
                .Where(x => x.Item2 == "Robert" && x.Item3 == "De Niro")
                .Select(t => t.Item1)
                .ToList();

            return obj;
        }

        // Task 10: Display the movie title, that was rented for the longest time
        public string Task10()
        {
            var obj = (from rent in _rentals
                       join cop in _copies on rent.CopyId equals cop.CopyId
                       join mov in _movies on cop.MovieId equals mov.MovieId
                       select new ValueTuple<string, double>(mov.Title,
                           (rent.DateOfReturn - rent.DateOfRental).Value.TotalDays))
                .AsEnumerable()
                .OrderByDescending(t => t.Item2)
                .Select(j => j.Item1)
                .FirstOrDefault();

            return obj;
        }

        // Task 11: Display last names of clients that made rentals between ’2005-07-15’ and ’2005-07-20’.
        // Eliminate duplicates
        public List<string> Task11()
        {
            var date1 = Convert.ToDateTime("2005-07-15");
            var date2 = Convert.ToDateTime("2005-07-20");
            var obj = (from rent in _rentals
                       join cln in _clients on rent.ClientId equals cln.ClientId
                       select new ValueTuple<string, DateTime?>(cln.LastName, rent.DateOfRental))
                .AsEnumerable()
                .Where(x => x.Item2 >= date1 && x.Item2 <= date2)
                .Select(t => t.Item1)
                .Distinct()
                .ToList();

            return obj;
        }

        // Task 12: Display titles of movies rented between ’2005-07-15’ and ’2005-07-25’.
        // Eliminate duplicates
        public List<string> Task12()
        {
            var date1 = Convert.ToDateTime("2005-07-15");
            var date2 = Convert.ToDateTime("2005-07-25");
            var obj = (from rent in _rentals
                       join cop in _copies on rent.CopyId equals cop.CopyId
                       join movie in _movies on cop.MovieId equals movie.MovieId
                       select new ValueTuple<string, DateTime?>(movie.Title, rent.DateOfRental))
                .AsEnumerable()
                .Where(x => x.Item2 >= date1 && x.Item2 <= date2)
                .Select(t => t.Item1)
                .Distinct()
                .ToList();

            return obj;
        }

        // Task 13: For clients that have the same first name as one of the actors
        // display: shared first name, last name of actor, last name of client
        public List<(string, string, string)> Task13()
        {
            var obj = (from act in _actors
                       join client in _clients on act.FirstName equals client.FirstName
                       select new ValueTuple<string, string, string>(client.FirstName, act.LastName, client.LastName))
                .AsEnumerable()
                .ToList();

            return obj;
        }
    }
}
