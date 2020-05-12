using DataAccess;
using DataAccess.Interfaces;

namespace ConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            IDatabase database = new Database("family data");
            IConnection connection = new Connection("dfdfdf", "4545", database);
            IConnection oldConnection = new Connection("dfdfdf", "4545", database);
            connection.Open();
            database.GetData(connection);
            database.GetData(oldConnection);
        }
    }
}