using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.Repositories
{
    public class RentalsRepository : RepositoryBase<RentalsModel>
    {
        public RentalsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
