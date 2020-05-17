using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.DAL
{
    public class MoviesRepository : RepositoryBase<MoviesModel>
    {
        public MoviesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
