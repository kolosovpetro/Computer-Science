using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.Repositories
{
    public class RentalsRepository : RepositoryBase<RentalsModel>
    {
        public RentalsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
