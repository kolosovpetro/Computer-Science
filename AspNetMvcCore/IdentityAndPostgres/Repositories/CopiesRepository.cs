using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.Repositories
{
    public class CopiesRepository : RepositoryBase<CopiesModel>
    {
        public CopiesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
