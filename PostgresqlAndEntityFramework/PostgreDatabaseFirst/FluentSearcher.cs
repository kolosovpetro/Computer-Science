using System.Linq;
using PostgreDatabaseFirst.DAL;
using PostgreDatabaseFirst.Models;

namespace PostgreDatabaseFirst
{
    internal class FluentSearcher
    {
        private readonly RentalContext _rentalContext = new RentalContext();
        public IQueryable<Clients> Query { get; set; }

        public FluentSearcher SearchName(string name)
        {
            Query = Query == null ? _rentalContext.Clients.Where(x => x.FirstName.ToLower().Contains(name.ToLower()))
                : Query.Where(x => x.FirstName.ToLower().Contains(name.ToLower()));

            return this;
        }

        public FluentSearcher SearchSurname(string surname)
        {
            Query = Query == null ? _rentalContext.Clients.Where(x => x.LastName.ToLower().Contains(surname.ToLower()))
                : Query.Where(x => x.LastName.ToLower().Contains(surname.ToLower()));

            return this;
        }
    }
}
