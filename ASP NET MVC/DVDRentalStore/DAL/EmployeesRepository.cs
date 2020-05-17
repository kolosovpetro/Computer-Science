using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;

namespace DVDRentalStore.DAL
{
    public class EmployeesRepository : RepositoryBase<EmployeesModel>
    {
        public EmployeesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
