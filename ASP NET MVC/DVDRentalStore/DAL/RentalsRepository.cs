using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.DAL
{
    public class RentalsRepository : RepositoryBase<RentalsModel>
    {
        public RentalsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
