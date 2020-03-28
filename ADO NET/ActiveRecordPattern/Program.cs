using ActiveRecordPattern.ClientRecordEntity;
using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.MovieRecordEntity;
using System;
using System.Collections.Generic;

namespace ActiveRecordPattern
{
    internal class Program
    {
        private static void Main()
        {
            // rental process, it works 

            var clientDbContext = new ClientDbContext();
            var client = clientDbContext.Select(9);
            Console.WriteLine("Client introduce yourself: ");
            Console.WriteLine(client);
            Console.WriteLine("Chosen movie id: 3");

            var copyListDbContext = new CopyListDbContext();
            Console.WriteLine("Do we have available copies ?");
            IEnumerable<ICopyRecord> copiesAvailable = copyListDbContext.Select(3).CopiesList;

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
