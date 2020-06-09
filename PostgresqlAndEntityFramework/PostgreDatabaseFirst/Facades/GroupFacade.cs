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
        }
    }
}
