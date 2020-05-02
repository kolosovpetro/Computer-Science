using System;
using System.Linq;

namespace PostgreDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var rentalInstance = new rentalContext();
            var movies = rentalInstance.Movies.ToList();

            // Task 1: Fetch titles of all movies produced in 1998 or 1999

            var task1 = from i in movies
                        where i.Year == 1998 || i.Year == 1999
                        select i;

            // Task 2: Fetch title and price of all movies with price exceeding 9. 
            // Order results ascending by price.

            var task2 = (from i in movies
                         where i.Price > 9
                         select i).OrderBy(t => t.Title);

            // Task 3: Fetch last names of all clients with first name ’Lisa’

            var clients = rentalInstance.Clients.ToList();

            var task3 = from i in clients
                        where i.FirstName == "Lisa"
                        select i;

            // Task 4: Fetch first and last names of all clients with last name longer by 
            // at least three characters than first name

            var task4 = from i in clients
                        where i.LastName.Length - i.FirstName.Length > 2
                        select i;

            // Task 5: Display last names of all actors with first names Arnold, Tom and Jodie.
            // Results should be presented in descending order

            var actors = rentalInstance.Actors.ToList();

            //var task5 = from i in actors
            //            where new string[] { "Arnold", "Jodie", "Tom" }.Contains(i.FirstName)
            //            select i;

            var task5 = actors.Where(x => new string[] { "Arnold", "Jodie", "Tom" }.Contains(x.FirstName));

            // Task 6: Display IDs of all movies with copies available for rent. 
            // Eliminate duplicates.Present the results in ascending order

            var copies = rentalInstance.Copies.ToList();

            var task6 = copies.Where(x => (bool)x.Available);

            // Task 7: Display the IDs of all copies, that were rented between 2005-07-15 and
            // 2005 - 07 - 22. 
            // Eliminate duplicates.Present the results in ascending order

            var rentals = rentalInstance.Rentals.ToList();

            var task7 = rentals
                .Where(x =>
                x.DateOfRental >= Convert.ToDateTime("2005-07-15") &&
                x.DateOfRental <= Convert.ToDateTime("2005-07-22"))
                .OrderByDescending(x => x.DateOfRental);

            // Task 8: Display IDs and rent time (in days) of all copies, that were rented for
            // more than one day

            var task8 = rentals.Where(x => (x.DateOfReturn - x.DateOfRental).Value.TotalHours > 24);

            // Task 9: Display all actors in the following form: first letter of first name, dot,
            // space, last name

            var task9 = actors.Select(x => $"{x.FirstName[0]}. {x.LastName}");

            // Task 10: Display titles of all movies, ordered from shortest to longest title

            var task10 = movies.Select(x => x.Title).OrderBy(x => x.Length);

            // Task 11: Display title and price of three newest movies

            var task11 = movies.Select(x => new { x.Title, x.Price, x.Year }).OrderBy(x => x.Year).Take(3);

            // Task 12: For all clients display: first name, first letter of first name, last letter of
            // first name. Columns should have titles as below

            var task12 = clients.Select(x => new
            {
                name = x.FirstName,
                first = x.FirstName[0],
                last = x.FirstName[^1]
            });

            // Task 13: Display the names of clients, whose first and last letter of name are the
            // same. Ignore the case, eliminate duplicates

            var task13 = clients
                .Where(x => x.FirstName[0].ToString().ToLower() == x.FirstName[^1].ToString());

            // Task 14: Display movie titles, with second to last letter ’o’

            var task14 = movies.Where(x => x.Title[^2] == 'o');

            // Task 15: For every client display its email address constructed in the following
            // way: lowercase first name, dot, lowercase last name, ’@wsb.pl’

            var task15 = clients
                .Select(x => $"{x.FirstName.ToLower()}.{x.LastName.ToLower()}@wsb.pl");


            foreach (var client in task15)
            {
                Console.WriteLine(client);
            }
        }
    }
}
