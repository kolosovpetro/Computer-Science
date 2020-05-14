using DVDRentalStore.DAL;

namespace DVDRentalStore.Infrastructure
{
    public interface IDbFactory
    {
        RentalContext Init();
    }
}
