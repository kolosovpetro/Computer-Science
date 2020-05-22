using IdentityAndPostgres.Data;

namespace IdentityAndPostgres.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        public RentalContext Init()
        {
            return new RentalContext();
        }
    }
}
