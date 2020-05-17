using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Misc;
using DVDRentalStore.Models;
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

        private IEnumerable<MoviesModel> GetHistory(int clientId)
        {
            // mapper config
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<ClientHistoryQueryObject, MoviesModel>());

            // create new mapper instance
            var mapper = new Mapper(config);

            // get collection collection
            var query = (from r in _rentalsRepository.GetAll()
                         join c in _clientsRepository.GetAll()
                             on r.ClientId equals c.ClientId
                         join cop in _copiesRepository.GetAll()
                             on r.CopyId equals cop.CopyId
                         join mov in _moviesRepository.GetAll()
                             on cop.MovieId equals mov.MovieId
                         select new ClientHistoryQueryObject()
                         {
                             Title = mov.Title,
                             Year = mov.Year,
                             AgeRestriction = mov.AgeRestriction,
                             MovieId = mov.MovieId,
                             Price = mov.Price,
                             ClientId = c.ClientId
                         })
                .Where(x => x.ClientId == clientId)
                .OrderBy(x => x.MovieId)
                .Distinct()
                .ToList();

            return mapper.Map<IEnumerable<MoviesModel>>(query);
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