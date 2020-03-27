using ActiveRecordPattern.MovieRecordEntity;
using System;

namespace ActiveRecordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var MovieDbContext = new MovieRecordDbEngine();
            var mov = MovieDbContext.Select(10);
            Console.WriteLine(mov);
        }
    }
}
