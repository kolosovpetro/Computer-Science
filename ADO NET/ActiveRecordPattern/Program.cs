using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.MovieRecordEntity;
using System;

namespace ActiveRecordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var MovieDbContext = new MovieRecordDbEngine();
            MovieRecord mov = (MovieRecord)MovieDbContext.Select(10);
            Console.WriteLine(mov);

            //mov.ChangePrice(20);
            //Console.WriteLine(mov);
            //MovieDbContext.Update(mov);

            var CopyDbEngine = new CopyListRecordDbEngine();
            var CopyList = (CopyListRecord)CopyDbEngine.Select(10);

            foreach (var item in CopyList.CopiesList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
