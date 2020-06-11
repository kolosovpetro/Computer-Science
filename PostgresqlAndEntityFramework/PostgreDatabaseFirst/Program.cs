using PostgreDatabaseFirst.Facades;

namespace PostgreDatabaseFirst
{
    internal class Program
    {
        private static void Main()
        {
            //var selectionFacade = new SelectionFacade();
            //selectionFacade.ExecuteAll();

            //var joinFacade = new JoinFacade();
            //joinFacade.ExecuteAll();

            //GroupFacade groupFacade = new GroupFacade();
            //groupFacade.ExecuteAll();

            SubFacade subFacade = new SubFacade();
            subFacade.ExecuteAll();

            //FluentSearcher fluentSearcher = new FluentSearcher();
            //fluentSearcher.SearchName("A").Query.ToList().ForEach(x =>
            //    Console.WriteLine($"{x.FirstName}, {x.LastName}"));
            //fluentSearcher.SearchName("Garry").SearchName("Hank").Query.ToList()
            //    .ForEach(x => Console.WriteLine($"{x.FirstName}, {x.LastName}"));

        }
    }
}
