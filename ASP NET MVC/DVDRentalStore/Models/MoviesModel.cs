using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVDRentalStore.ReverseEngineering;

namespace DVDRentalStore.Models
{
    // here we print lis of all movies in the store

    public class MoviesModel
    {
        private static readonly rentalContext rentalInstance = new rentalContext();

        public static IQueryable<Movies> GetList()
        {
            return rentalInstance.Movies.Select(x => x);
        }
    }
}
