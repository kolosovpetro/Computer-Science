using System.Collections.Generic;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using DVDRentalStore.ViewModels;

namespace DVDRentalStore.Services
{
    public class ClientHistoryService
    {
        private readonly CopiesRepository _copiesRepository;
        private readonly ClientsRepository _clientsRepository;
        private readonly RentalsRepository _rentalsRepository;
        private readonly MoviesRepository _moviesRepository;

        public ClientHistoryService()
        {
            IDbFactory dbFactory = new DbFactory();
            _copiesRepository = new CopiesRepository(dbFactory);
            _clientsRepository = new ClientsRepository(dbFactory);
            _rentalsRepository = new RentalsRepository(dbFactory);
            _moviesRepository = new MoviesRepository(dbFactory);
        }

        public IEnumerable<ClientHistoryViewModel> GetHistory(int clientId)
        {
            return (from r in _rentalsRepository.GetAll()
                    join c in _clientsRepository.GetAll()
                        on r.ClientId equals c.ClientId
                    join cop in _copiesRepository.GetAll()
                        on r.CopyId equals cop.CopyId
                    join mov in _moviesRepository.GetAll()
                        on cop.MovieId equals mov.MovieId
                    select new ClientHistoryViewModel
                    {
                        Title = mov.Title,
                        Year = mov.Year,
                        AgeRestriction = mov.AgeRestriction,
                        MovieId = mov.MovieId,
                        Price = mov.Price,
                        Client = c
                    })
                .Where(x => x.Client.ClientId == clientId)
                .OrderBy(x => x.MovieId)
                .Distinct();
        }
    }
}
