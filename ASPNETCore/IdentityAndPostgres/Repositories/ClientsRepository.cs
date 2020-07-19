using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.Repositories
{
    public class ClientsRepository : RepositoryBase<ClientsModel>
    {
        public ClientsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
