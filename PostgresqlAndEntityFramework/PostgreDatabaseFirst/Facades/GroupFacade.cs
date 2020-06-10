using System;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst.Facades
{
    internal class GroupFacade
    {
        private readonly GroupQueries _groupQueries = new GroupQueries();

        public void ExecuteAll()
        {
            _groupQueries.Task1().ForEach(x =>
                Console.WriteLine($"First name: {x.Item1}, Lastname: {x.Item2}"));
            Console.WriteLine(_groupQueries.Task2().Count == 0);
            _groupQueries.Task2().ForEach(Console.WriteLine);
            _groupQueries.Task3().ForEach(Console.WriteLine);
            _groupQueries.Task4().ForEach(Console.WriteLine);
            _groupQueries.Task5().ForEach(x =>
                Console.WriteLine($"First name: {x.Item1}, Lastname: {x.Item2}"));
            Console.WriteLine($"Maximal movie price: {_groupQueries.Task6()}");
            Console.WriteLine($"Movies produced in 1984: {_groupQueries.Task7()}");
            Console.WriteLine($"Movie Taxi driver rented times: {_groupQueries.Task8()}");
        }
    }
}
