using System;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst.Facades
{
    class JoinFacade
    {
        private readonly JoinQueries _joinQueries = new JoinQueries();

        public void ExecuteAll()
        {
            _joinQueries.Task1().ForEach(x => Console.WriteLine($"Id: {x.Item1}, Title: {x.Item2}"));
            _joinQueries.Task2().ForEach(Console.WriteLine);
            _joinQueries.Task3().ForEach(Console.WriteLine);
        }
    }
}
