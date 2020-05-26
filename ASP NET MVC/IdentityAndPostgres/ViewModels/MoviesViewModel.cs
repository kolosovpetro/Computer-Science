using System.Linq;
using IdentityAndPostgres.Data;
using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.ViewModels
{
    public class MoviesViewModel : MoviesModel
    {
        private readonly RentalContext _rentalContext = new RentalContext();

        public int CopiesCount => AllCopiesNumber();
        public int AvailableCopiesCount => AvailableCopiesNumber();

        public bool? Available { get; set; }

        private int AllCopiesNumber()
        {
            return _rentalContext.Copies.Count(x => x.MovieId == MovieId);
        }

        private int AvailableCopiesNumber()
        {
            return _rentalContext.Copies.Count(x => x.MovieId == MovieId && (bool)x.Available);
        }
    }
}
