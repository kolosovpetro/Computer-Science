using System.Collections.Generic;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using DVDRentalStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientRentalHistoryController : Controller
    {
        private readonly IDbFactory _dbFactory;
        private readonly CopiesRepository _copiesRepository;
        private readonly ClientsRepository _clientsRepository;
        private readonly RentalsRepository _rentalsRepository;
        private readonly MoviesRepository _moviesRepository;

        public ClientRentalHistoryController()
        {
            _dbFactory = new DbFactory();
            _copiesRepository = new CopiesRepository(_dbFactory);
            _clientsRepository = new ClientsRepository(_dbFactory);
            _rentalsRepository = new RentalsRepository(_dbFactory);
            _moviesRepository = new MoviesRepository(_dbFactory);
        }

        private IEnumerable<ClientHistoryViewModel> GetHistory(int clientId)
        {
            return (from r in _rentalsRepository.GetAll()
                    join c in _clientsRepository.GetAll()
                        on r.ClientId equals c.ClientId
                    join cop in _copiesRepository.GetAll()
                        on r.CopyId equals cop.CopyId
                    join mov in _moviesRepository.GetAll()
                        on cop.MovieId equals mov.MovieId
                    select new ClientHistoryViewModel()
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

        public IActionResult ClientRentalHistory()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            var client = _dbFactory.Init().Clients
                .FirstOrDefault(x => x.ClientId == clientId);   // we access this way since of 2-pkey

            ViewData["Client"] = client;

            return View(GetHistory(clientId));
        }
    }
}