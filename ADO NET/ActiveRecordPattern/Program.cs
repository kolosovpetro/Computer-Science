using ActiveRecordPattern.ClientRecordEntity;
using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.MovieRecordEntity;
using ActiveRecordPattern.RentalsRecordEntity;
using System;

namespace ActiveRecordPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var movieDbContext = new MovieDbContext();
            var mov = movieDbContext.Select(10);
            Console.WriteLine(mov);

            //mov.ChangePrice(20);
            //Console.WriteLine(mov);
            //MovieDbContext.Update(mov);

            var copyListDbEngine = new CopyListDbContext();

            var copyList = copyListDbEngine.Select(11);

            foreach (var item in copyList.CopiesList)
            {
                Console.WriteLine(item);
            }

            var copyRecordDb = new CopyDbContext();

            //CopyRecord newCopy = new CopyRecord(21, true, 11);
            //CopyRecordDb.Insert(newCopy);

            var particularCopy = copyRecordDb.Select(11);
            Console.WriteLine(particularCopy);
            particularCopy.SetAvailable(true);
            copyRecordDb.Update(particularCopy);
            Console.WriteLine(particularCopy);

            var clientDbContext = new ClientDbContext();
            var client = clientDbContext.Select(5);
            Console.WriteLine(client);
            client.SetFirstName("Vasya");
            clientDbContext.Update(client);
            var newClient = new ClientRecord(9, "Aska", "Tao", new DateTime(1980, 3, 5));
            Console.WriteLine(newClient);
            //clientDbCont.Insert(newClnt);
            //clnt.Rent(10);

            var rentDbCont = new RentalsDbContext();
            var rentals = rentDbCont.Select(clientId: 2);

            foreach (var rental in rentals)
            {
                Console.WriteLine(rental);
            }
        }
    }
}
