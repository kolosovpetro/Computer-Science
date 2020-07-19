using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.Repositories
{
    public class CopiesRepository : RepositoryBase<CopiesModel>
    {
        public CopiesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
