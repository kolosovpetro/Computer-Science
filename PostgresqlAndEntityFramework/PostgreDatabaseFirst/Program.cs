using System;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SelectionQueries

            var selectionQueries = new SelectionQueries();

            // Task 1: Fetch titles of all movies produced in 1998 or 1999
            selectionQueries.Task1().ForEach(Console.WriteLine);

            // Task 2: Fetch title and price of all movies with price exceeding 9. 
            // Order results ascending by price.
            selectionQueries.Task2().ForEach(x => Console.WriteLine($"Title: {x.Title}, Price: {x.Price}"));

            // Task 3: Fetch last names of all clients with first name ’Lisa’
            selectionQueries.Task3().ForEach(Console.WriteLine);

            // Task 4: Fetch first and last names of all clients with last name longer by 
            // at least three characters than first name
            selectionQueries.Task4()
                .ForEach(x => Console.WriteLine($"Firstname: {x.FirstName}, Lastname: {x.LastName}"));

            // Task 5: Display last names of all actors with first names Arnold, Tom and Jodie.
            // Results should be presented in descending order
            selectionQueries.Task5().ForEach(Console.WriteLine);

            // Task 6: Display IDs of all movies with copies available for rent. 
            // Eliminate duplicates.
            // Present the results in ascending order
            selectionQueries.Task6().ForEach(x =>
            {
                if (x != null) Console.WriteLine((int)x);
            });

            // Task 7: Display the IDs of all copies, that were rented between 2005-07-15 and 2005-07-22. 
            // Eliminate duplicates.
            // Present the results in ascending order
            selectionQueries.Task7().ForEach(Console.WriteLine);

            // Task 8: Display IDs and rent time (in days) of all copies, that were rented for
            // more than one day
            selectionQueries.Task8()
                .ForEach(x =>
                {
                    if (x.DateOfReturn != null)
                        Console.WriteLine(
                            $"Copy Id: {x.CopyId}, Rent time: {(x.DateOfReturn - x.DateOfRental).Value.TotalDays}");
                });

            // Task 9: Display all actors in the following form: first letter of first name, dot,
            // space, last name
            selectionQueries.Task9().ForEach(Console.WriteLine);

            // Task 10: Display titles of all movies, ordered from shortest to longest title
            selectionQueries.Task10().ForEach(Console.WriteLine);

            // Task 11: Display title and price of three newest movies
            selectionQueries.Task11().ForEach(x => Console.WriteLine($"Title: {x.Title}, Price: {x.Price}"));

            // Task 12: For all clients display: first name, first letter of first name, last letter of
            // first name. Columns should have titles as below
            selectionQueries.Task12().ForEach(Console.WriteLine);

            // Task 13: Display the names of clients, whose first and last letter of name are the
            // same. Ignore the case, eliminate duplicates
            selectionQueries.Task13().ForEach(Console.WriteLine);

            // Task 14: Display movie titles, with second to last letter ’o’
            selectionQueries.Task14().ForEach(Console.WriteLine);

            // Task 15: For every client display its email address constructed in the following
            // way: lowercase first name, dot, lowercase last name, ’@wsb.pl’
            selectionQueries.Task15().ForEach(Console.WriteLine);

            #endregion


            // Task 1: For every copy display it’s ID and title of the movie. Order the results by
            // copy ID

            // Task 2: Display the titles of all the movies with copies 
            // available in the rental store.
            // Eliminate duplicates

            // Task 3: Display IDs of copies of movies produced in 1984

            // Task 4: For every rental display date of rental, date of return 
            // and name of client that made the rental

            // Task 5: For every rental display name of the client that made the rental and title
            // of the rented movie

            // Task 6: Display titles and years of production of all the movies rented 
            // by Gary Goodspeed

        }
    }
}
