using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientRentalHistoryController : Controller
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepository<CopiesModel> _copiesRepository;
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;
        private readonly IRepository<MoviesModel> _moviesRepository;

        public ClientRentalHistoryController()
        {
            _dbFactory = new DbFactory();
            _copiesRepository = new RepositoryBase<CopiesModel>(_dbFactory);
            _clientsRepository = new RepositoryBase<ClientsModel>(_dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(_dbFactory);
            _moviesRepository = new RepositoryBase<MoviesModel>(_dbFactory);
        }
        public IActionResult ClientRentalHistory()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            // double primary key makes it necessary to access from dbFactory
            var client = _dbFactory.Init().Clients.FirstOrDefault(x => x.ClientId == clientId);

            var clientHistory = (from r in _rentalsRepository.GetAll()
                join c in _clientsRepository.GetAll()
                    on r.ClientId equals c.ClientId
                join cop in _copiesRepository.GetAll()
                    on r.CopyId equals cop.CopyId
                join mov in _moviesRepository.GetAll()
                    on cop.MovieId equals mov.MovieId
                select new
                {
                    mov.Title,
                    mov.Year,
                    mov.AgeRestriction,
                    mov.MovieId,
                    mov.Price,
                    c.ClientId
                }).Where(x => x.ClientId == clientId).Distinct();

            var clientMovies = new List<MoviesModel>();

            foreach (var element in clientHistory)
            {
                clientMovies.Add(new MoviesModel
                {
                    Title = element.Title,
                    MovieId = element.MovieId,
                    Year = element.Year,
                    Price = element.Price,
                    AgeRestriction = element.AgeRestriction
                });
            }

            ViewData["Client"] = client;

            return View(clientMovies);
        }
    }
}