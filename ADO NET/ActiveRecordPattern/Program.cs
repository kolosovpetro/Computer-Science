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

            //CopyListRecord copies = new CopyListRecord(10);

            //foreach (var item in copies.Copies)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}
