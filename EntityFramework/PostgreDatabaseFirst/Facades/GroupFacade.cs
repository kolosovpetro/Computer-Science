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
            _groupQueries.Task9().ForEach(x =>
                Console.WriteLine($"Year: {x.Item1}, Avg movie price: {x.Item2}"));
            Console.WriteLine($"Average rental time of Ronin: {_groupQueries.Task10()} days");
            _groupQueries.Task11().ForEach(x =>
                Console.WriteLine($"Title: {x.Item1}, Min {x.Item2}, Max: {x.Item3}, Avg: {x.Item4}, Count: {x.Item5} "));
            _groupQueries.Task12().ForEach(x =>
                Console.WriteLine($"Name: {x.Item1}, Surname: {x.Item2}, Rents: {x.Item3}"));
            _groupQueries.Task13().ForEach(x =>
                Console.WriteLine($"Surname: {x.Item1}, Mov. count: {x.Item2}"));
            _groupQueries.Task14().ForEach(x =>
                Console.WriteLine($"Cl. Surname: {x.LastName}, Total spent: {x.Sum}"));
        }
    }
}
