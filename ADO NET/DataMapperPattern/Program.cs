using System;
using DataMapperPattern.ClientRecordEntity;
using DataMapperPattern.CopyListRecordEntity;

namespace DataMapperPattern
{
    internal class Program
    {
        private static void Main()
        {
            // rental of movie by client

            var clientDbContext = ClientMapper.Instance;
            var client = clientDbContext.Select(9);
            Console.WriteLine("Client introduce yourself: ");
            Console.WriteLine(client);
            Console.WriteLine("Chosen movie id: 6");

            var copyListDbContext = CopyListMapper.Instance;
            Console.WriteLine("Do we have available copies ?");
            var copiesAvailable = copyListDbContext.Select(6).CopiesList;

            foreach (var copyRecord in copiesAvailable)
            {
                Console.WriteLine(copyRecord);
            }

            Console.WriteLine("Client tries to rent movie id 6");

            client.Rent(6);

            Console.WriteLine("Check if rental was okay ... ");

            copiesAvailable = copyListDbContext.Select(6).CopiesList;

            foreach (var copyRecord in copiesAvailable)
            {
                Console.WriteLine(copyRecord);
            }
        }
    }
}
