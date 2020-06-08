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
            List<string> titles = _rentalContext.Movies
                .Where(x => x.Year == 1998 || x.Year == 1999)
                .Select(t => t.Title)
                .ToList();

            return titles;
        }

        // Task 2: Fetch title and price of all movies with price exceeding 9. 
        // Order results ascending by price.
        public List<Movies> Task2()
        {
            List<Movies> movies = _rentalContext.Movies
                .Where(x => x.Price > 9)
                .Select(t => new Movies
                {
                    MovieId = t.MovieId,
                    Title = t.Title,
                    Price = t.Price,
                    Year = t.Year,
                    AgeRestriction = t.AgeRestriction
                })
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
            List<Clients> clients = _rentalContext.Clients
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
            List<string> actors = _rentalContext.Actors
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
            List<int?> ids = _rentalContext.Copies
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

            List<int> ids = _rentalContext.Rentals
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
            List<Rentals> rentals = _rentalContext.Rentals
                .AsEnumerable()
                .Where(x => (x.DateOfReturn - x.DateOfRental).Value.TotalDays > 0)
                .ToList();
            return rentals;
        }

        // Task 9: Display all actors in the following form: first letter of first name, dot,
        // space, last name
        public List<string> Task9()
        {
            List<string> actors = _rentalContext.Actors
                .AsEnumerable()
                .Select(x => $"{x.FirstName[0]}. {x.LastName}")
                .OrderBy(t => t)
                .ToList();

            return actors;
        }
    }
}
