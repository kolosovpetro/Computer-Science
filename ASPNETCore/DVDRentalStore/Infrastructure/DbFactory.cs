using DVDRentalStore.DAL;

namespace DVDRentalStore.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        public RentalContext Init()
        {
            return new RentalContext();
        }
    }
}
