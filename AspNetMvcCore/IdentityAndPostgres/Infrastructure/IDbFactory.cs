using IdentityAndPostgres.Data;

namespace IdentityAndPostgres.Infrastructure
{
    public interface IDbFactory
    {
        RentalContext Init();
    }
}
