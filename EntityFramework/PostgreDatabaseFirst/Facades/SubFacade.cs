using System;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst.Facades
{
    internal class SubFacade
    {
        private readonly SubQueries _subQueries = new SubQueries();

        public void ExecuteAll()
        {
            Console.WriteLine($"Most expansive movie title: {_subQueries.Task1().Title}");
            Console.WriteLine($"First rental client: {_subQueries.Task2().FirstName}, {_subQueries.Task2().LastName}");
            Console.WriteLine("Titles of available movies: ");
            _subQueries.Task3().ForEach(Console.WriteLine);
            Console.WriteLine("Titles of movies with price greater then movie Frantic: ");
            _subQueries.Task4().ForEach(Console.WriteLine);
            Console.WriteLine("Titles of all movies price greater then max of before 1980 year");
            _subQueries.Task5().ForEach(Console.WriteLine);
            Console.WriteLine("Clients and rentals count: ");
            _subQueries.Task6().ForEach(x =>
                Console.WriteLine($"Surname: {x.LastName}, Rentals count: {x.RentalsCount}, Total rentals: {x.TotalRentals}"));
            Console.WriteLine("Movies starred also Jean Reno");
            _subQueries.Task7().ForEach(x =>
                Console.WriteLine($"Firstname: {x.FirstName}, Lastname: {x.LastName}, Title: {x.Title}"));
            Console.WriteLine("Clients older then average age: ");
            _subQueries.Task8().ForEach(x =>
                Console.WriteLine($"Firstname: {x.FirstName}, Lastname:{x.LastName}, Birthday: {x.Birthday}"));
            Console.WriteLine("Clients that rented same copies as Brian Griffin");
            _subQueries.Task9().ForEach(x =>
                Console.WriteLine($"Firstname: {x.FirstName}, Lastname: {x.LastName}"));
        }
    }
}
