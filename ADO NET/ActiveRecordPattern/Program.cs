using ActiveRecordPattern.ClientRecordEntity;
using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.MovieRecordEntity;
using System;

namespace ActiveRecordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieRecordDbContext<MovieRecord> MovieDbContext = new MovieRecordDbContext<MovieRecord>();
            MovieRecord mov = MovieDbContext.Select(10);
            Console.WriteLine(mov);

            //mov.ChangePrice(20);
            //Console.WriteLine(mov);
            //MovieDbContext.Update(mov);

            var CopyListDbEngine = new CopyListDbContext<CopyListRecord>();

            var CopyList = CopyListDbEngine.Select(11);

            foreach (var item in CopyList.CopiesList)
            {
                Console.WriteLine(item);
            }

            var CopyRecordDb = new CopyDbContext<CopyRecord>();

            //CopyRecord newCopy = new CopyRecord(21, true, 11);
            //CopyRecordDb.Insert(newCopy);

            var particularCopy = CopyRecordDb.Select(11);
            Console.WriteLine(particularCopy);
            particularCopy.ChangeAvailable(true);
            CopyRecordDb.Update(particularCopy);
            Console.WriteLine(particularCopy);

            var clientDbCont = new ClientDbContext<ClientRecord>();
            var clnt = clientDbCont.Select(5);
            Console.WriteLine(clnt);
            var newClnt = new ClientRecord(9, "Aska", "Tao", new DateTime(1980, 3, 5));
            Console.WriteLine(newClnt);
            clientDbCont.Insert(newClnt);
        }
    }
}
