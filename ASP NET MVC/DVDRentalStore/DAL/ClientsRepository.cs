using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.DAL
{
    public class ClientsRepository : RepositoryBase<ClientsModel>
    {
        public ClientsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
