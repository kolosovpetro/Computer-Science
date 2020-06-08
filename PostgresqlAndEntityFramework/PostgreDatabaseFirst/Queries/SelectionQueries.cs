using System;
using System.Collections.Generic;
using System.Linq;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;

namespace PostgreDatabaseFirst.Queries
{
    internal class SelectionQueries
    {
        private readonly RentalContext _rentalContext = new RentalContext();

        // Task 1: Fetch titles of all movies produced in 1998 or 1999
        public List<string> Task1()
        {
            var titles = _rentalContext.Movies
                .Where(x => x.Year == 1998 || x.Year == 1999)
                .Select(t => t.Title)
                .ToList();

            return titles;
        }

        // Task 2: Fetch title and price of all movies with price exceeding 9. 
        // Order results ascending by price.
        public List<Movies> Task2()
        {
            var movies = _rentalContext.Movies
                .Where(x => x.Price > 9)
                .Select(t => new Movies
                {
                    MovieId = t.MovieId,
                    Title = t.Title,
                    Price = t.Price,
                    Year = t.Year,
                    AgeRestriction = t.AgeRestriction
                })
                .OrderBy(s => s.Price)
                .ToList();

            return movies;
        }

        // Task 3: Fetch last names of all clients with first name ’Lisa’
        public List<string> Task3()
        {
            var clients = _rentalContext.Clients
                .Where(x => x.FirstName == "Gary")
                .Select(t => t.LastName)
                .ToList();

            return clients;
        }

        // Task 4: Fetch first and last names of all clients with last name longer by 
        // at least three characters than first name
        public List<Clients> Task4()
        {
            var clients = _rentalContext.Clients
                .Where(x => x.LastName.Length - x.FirstName.Length > 2)
                .Select(t => new Clients
                {
                    Birthday = t.Birthday,
                    ClientId = t.ClientId,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                })
                .ToList();

            return clients;
        }

        // Task 5: Display last names of all actors with first names Arnold, Tom and Jodie.
        // Results should be presented in descending order
        public List<string> Task5()
        {
            var names = new[] { "Arnold", "Tom", "Jodie" };
            var actors = _rentalContext.Actors
                .Where(x => names.Contains(x.FirstName))
                .Select(t => t.LastName)
                .OrderByDescending(j => j)
                .ToList();

            return actors;
        }

        // Task 6: Display IDs of all movies with copies available for rent. 
        // Eliminate duplicates. Present the results in ascending order
        public List<int?> Task6()
        {
            var ids = _rentalContext.Copies
                .Where(x => (bool)x.Available)
                .Select(t => t.MovieId)
                .OrderBy(j => j)
                .Distinct()
                .ToList();

            return ids;
        }

        // Task 7: Display the IDs of all copies, that were rented between 2005-07-15 and
        // 2005 - 07 - 22. 
        // Eliminate duplicates. Present the results in ascending order
        public List<int> Task7()
        {
            var date1 = Convert.ToDateTime("2005-07-15");
            var date2 = Convert.ToDateTime("2005-07-22");

            var ids = _rentalContext.Rentals
                .Where(x => x.DateOfRental > date1 && x.DateOfReturn < date2)
                .Select(t => t.CopyId)
                .OrderBy(j => j)
                .Distinct()
                .ToList();

            return ids;
        }

        // Task 8: Display IDs and rent time (in days) of all copies, that were rented for
        // more than one day
        public List<Rentals> Task8()
        {
            var rentals = _rentalContext.Rentals
                .AsEnumerable()
                .Where(x => (x.DateOfReturn - x.DateOfRental).Value.TotalDays > 0)
                .ToList();
            return rentals;
        }

        // Task 9: Display all actors in the following form: first letter of first name, dot,
        // space, last name
        public List<string> Task9()
        {
            var actors = _rentalContext.Actors
                .AsEnumerable()
                .Select(x => $"{x.FirstName[0]}. {x.LastName}")
                .OrderBy(t => t)
                .ToList();

            return actors;
        }

        // Task 10: Display titles of all movies, ordered from shortest to longest title
        public List<string> Task10()
        {
            var titles = _rentalContext.Movies
                .AsEnumerable()
                .Select(x => x.Title)
                .OrderBy(t => t.Length)
                .ToList();

            return titles;
        }

        // Task 11: Display title and price of three newest movies
        public List<Movies> Task11()
        {
            var movies = _rentalContext.Movies
                .AsEnumerable()
                .OrderByDescending(x => x.Year)
                .Take(3)
                .ToList();

            return movies;
        }

        // Task 12: For all clients display: first name, first letter of first name, last letter of
        // first name. Columns should have titles as below
        public List<string> Task12()
        {
            var clients = _rentalContext.Clients
                .AsEnumerable()
                .Select(x => $"{x.FirstName} {x.FirstName[0]} {x.FirstName[^1]}")
                .ToList();

            return clients;
        }

        // Task 13: Display the names of clients, whose first and last letter of name are the
        // same. Ignore the case, eliminate duplicates
        public List<string> Task13()
        {
            var names = _rentalContext.Clients
                .AsEnumerable()
                .Where(x => x.FirstName.ToLower()[0] == x.FirstName.ToLower()[^1])
                .Select(t => t.FirstName)
                .Distinct()
                .ToList();

            return names;
        }

        // Task 14: Display movie titles, with second to last letter ’o’
        public List<string> Task14()
        {
            var titles = _rentalContext.Movies
                .AsEnumerable()
                .Where(x => x.Title.ToLower()[^2] == 'o')
                .Select(t => t.Title)
                .ToList();

            return titles;
        }

        // Task 15: For every client display its email address constructed in the following
        // way: lowercase first name, dot, lowercase last name, ’@wsb.pl’
        public List<string> Task15()
        {
            var emails = _rentalContext.Clients
                .AsEnumerable()
                .Select(x => $"{x.FirstName.ToLower()}.{x.LastName.ToLower()}@wsb.pl")
                .ToList();

            return emails;
        }
    }
}
