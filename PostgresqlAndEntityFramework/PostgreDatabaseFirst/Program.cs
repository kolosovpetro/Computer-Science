using PostgreDatabaseFirst.Facades;

namespace PostgreDatabaseFirst
{
    internal class Program
    {
        private static void Main()
        {
            var selectionFacade = new SelectionFacade();
            selectionFacade.ExecuteAll();

            var joinFacade = new JoinFacade();
            joinFacade.ExecuteAll();

        }
    }
}
