using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;

namespace PostgreDatabaseFirst.Queries
{
    class JoinQueries
    {
        private readonly RentalContext _rentalContext = new RentalContext();
        private readonly DbSet<Movies> _movies;
        private readonly DbSet<Copies> _copies;

        public JoinQueries()
        {
            _movies = _rentalContext.Movies;
            _copies = _rentalContext.Copies;
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
        public object Task4()
        {
            return null;
        }
    }
}
