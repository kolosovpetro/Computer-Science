using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.Repositories
{
    public class EmployeesRepository : RepositoryBase<EmployeesModel>
    {
        public EmployeesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
