using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.DAL
{
    public class CopiesRepository : RepositoryBase<CopiesModel>
    {
        public CopiesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
