using ActiveRecordPattern.MovieRecordEntity;
using System;

namespace ActiveRecordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mov = new MovieRecord(5);
            Console.WriteLine(mov.ToString());
            mov.ChangePrice(8);
            mov.Update();
            Console.WriteLine("After change: ");
            Console.WriteLine(mov);

            var newMovie = new MovieRecord(11);
            Console.WriteLine(newMovie.ToString());


            //CopyListRecord copies = new CopyListRecord(10);

            //foreach (var item in copies.Copies)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}
