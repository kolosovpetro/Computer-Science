using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.Repositories
{
    public class MoviesRepository : RepositoryBase<MoviesModel>
    {
        public MoviesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
