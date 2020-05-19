using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.Repositories
{
    public class MoviesRepository : RepositoryBase<MoviesModel>
    {
        public MoviesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
