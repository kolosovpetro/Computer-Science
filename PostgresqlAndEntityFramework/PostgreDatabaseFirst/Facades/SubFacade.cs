using System;
using System.Collections.Generic;
using System.Text;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst.Facades
{
    class SubFacade
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
        }
    }
}
