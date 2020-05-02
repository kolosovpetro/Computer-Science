using System;
using System.Linq;

namespace PostgreDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var rentalInstance = new rentalContext();
            var movie = rentalInstance.Movies.ToList().ElementAt(0);

            Console.WriteLine(movie.Title);

            movie.Title = "New title to check";
            rentalInstance.Update(movie);
            rentalInstance.SaveChanges();

            Console.WriteLine(movie.Title);
        }
    }
}
