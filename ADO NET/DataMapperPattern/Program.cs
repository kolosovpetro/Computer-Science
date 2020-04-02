using System;
using System.Collections.Generic;
using DataMapperPattern.ClientRecordEntity;
using DataMapperPattern.CopyListRecordEntity;
using DataMapperPattern.CopyRecordEntity;

namespace DataMapperPattern
{
    internal class Program
    {
        private static void Main()
        {
            // rental of movie by client

            var clientDbContext = new ClientDbContext();
            var client = clientDbContext.Select(9);
            Console.WriteLine("Client introduce yourself: ");
            Console.WriteLine(client);
            Console.WriteLine("Chosen movie id: 3");

            var copyListDbContext = new CopyListDbContext();
            Console.WriteLine("Do we have available copies ?");
            var copiesAvailable = copyListDbContext.Select(3).CopiesList;

            foreach (var copyRecord in copiesAvailable)
            {
                Console.WriteLine(copyRecord);
            }

            Console.WriteLine("Client tries to rent movie 3");

            client.Rent(3);

            Console.WriteLine("Check if rental was okay ... ");

            copiesAvailable = copyListDbContext.Select(3).CopiesList;

            foreach (var copyRecord in copiesAvailable)
            {
                Console.WriteLine(copyRecord);
            }
        }
    }
}
