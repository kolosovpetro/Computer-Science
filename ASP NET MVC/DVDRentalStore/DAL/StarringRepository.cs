using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.DAL
{
    public class StarringRepository : RepositoryBase<StarringModel>
    {
        public StarringRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
