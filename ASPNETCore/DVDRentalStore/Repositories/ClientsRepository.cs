using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.Repositories
{
    public class ClientsRepository : RepositoryBase<ClientsModel>
    {
        public ClientsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
