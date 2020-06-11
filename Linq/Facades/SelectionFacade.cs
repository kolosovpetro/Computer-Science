using System;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst.Facades
{
    class SelectionFacade
    {
        private readonly SelectionQueries _selectionQueries = new SelectionQueries();

        public void ExecuteAll()
        {
            // Task 1: Fetch titles of all movies produced in 1998 or 1999
            _selectionQueries.Task1().ForEach(Console.WriteLine);

            // Task 2: Fetch title and price of all movies with price exceeding 9. 
            // Order results ascending by price.
            _selectionQueries.Task2().ForEach(x => Console.WriteLine($"Title: {x.Title}, Price: {x.Price}"));

            // Task 3: Fetch last names of all clients with first name ’Lisa’
            _selectionQueries.Task3().ForEach(Console.WriteLine);

            // Task 4: Fetch first and last names of all clients with last name longer by 
            // at least three characters than first name
            _selectionQueries.Task4()
                .ForEach(x => Console.WriteLine($"Firstname: {x.FirstName}, Lastname: {x.LastName}"));

            // Task 5: Display last names of all actors with first names Arnold, Tom and Jodie.
            // Results should be presented in descending order
            _selectionQueries.Task5().ForEach(Console.WriteLine);

            // Task 6: Display IDs of all movies with copies available for rent. 
            // Eliminate duplicates.
            // Present the results in ascending order
            _selectionQueries.Task6().ForEach(x =>
            {
                if (x != null) Console.WriteLine((int)x);
            });

            // Task 7: Display the IDs of all copies, that were rented between 2005-07-15 and 2005-07-22. 
            // Eliminate duplicates.
            // Present the results in ascending order
            _selectionQueries.Task7().ForEach(Console.WriteLine);

            // Task 8: Display IDs and rent time (in days) of all copies, that were rented for
            // more than one day
            _selectionQueries.Task8()
                .ForEach(x =>
                {
                    if (x.DateOfReturn != null)
                        Console.WriteLine(
                            $"Copy Id: {x.CopyId}, Rent time: {(x.DateOfReturn - x.DateOfRental).Value.TotalDays}");
                });

            // Task 9: Display all actors in the following form: first letter of first name, dot,
            // space, last name
            _selectionQueries.Task9().ForEach(Console.WriteLine);

            // Task 10: Display titles of all movies, ordered from shortest to longest title
            _selectionQueries.Task10().ForEach(Console.WriteLine);

            // Task 11: Display title and price of three newest movies
            _selectionQueries.Task11().ForEach(x => Console.WriteLine($"Title: {x.Title}, Price: {x.Price}"));

            // Task 12: For all clients display: first name, first letter of first name, last letter of
            // first name. Columns should have titles as below
            _selectionQueries.Task12().ForEach(Console.WriteLine);

            // Task 13: Display the names of clients, whose first and last letter of name are the
            // same. Ignore the case, eliminate duplicates
            _selectionQueries.Task13().ForEach(Console.WriteLine);

            // Task 14: Display movie titles, with second to last letter ’o’
            _selectionQueries.Task14().ForEach(Console.WriteLine);

            // Task 15: For every client display its email address constructed in the following
            // way: lowercase first name, dot, lowercase last name, ’@wsb.pl’
            _selectionQueries.Task15().ForEach(Console.WriteLine);
        }
    }
}
