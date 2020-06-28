using System;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst.Facades
{
    internal class JoinFacade
    {
        private readonly JoinQueries _joinQueries = new JoinQueries();

        public void ExecuteAll()
        {
            _joinQueries.Task1().ForEach(x => Console.WriteLine($"Id: {x.Item1}, Title: {x.Item2}"));
            _joinQueries.Task2().ForEach(Console.WriteLine);
            _joinQueries.Task3().ForEach(Console.WriteLine);
            _joinQueries.Task4().ForEach(x => Console.WriteLine($"Rent date: {x.Item1}, Return date: {x.Item2}, Client name: {x.Item3}"));
            _joinQueries.Task5().ForEach(x => Console.WriteLine($"{x.Item1}, {x.Item2}, {x.Item3}"));
            _joinQueries.Task6().ForEach(Console.WriteLine);
            Console.WriteLine(_joinQueries.Task7());
            _joinQueries.Task8().ForEach(Console.WriteLine);
            _joinQueries.Task9().ForEach(Console.WriteLine);
            Console.WriteLine(_joinQueries.Task10());
            _joinQueries.Task11().ForEach(Console.WriteLine);
            _joinQueries.Task12().ForEach(Console.WriteLine);
            _joinQueries.Task13().ForEach(x =>
                Console.WriteLine($"Shared firstname: {x.Item1}, Act. lastname: {x.Item2}, Cl. lastname {x.Item3}"));
        }
    }
}
