using System;
using System.Collections.Generic;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepository<CopiesModel> _copiesRepository;
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;
        private readonly IRepository<MoviesModel> _moviesRepository;

        public RentalsController()
        {
            _dbFactory = new DbFactory();
            _copiesRepository = new RepositoryBase<CopiesModel>(_dbFactory);
            _clientsRepository = new RepositoryBase<ClientsModel>(_dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(_dbFactory);
            _moviesRepository = new RepositoryBase<MoviesModel>(_dbFactory);
        }

        [HttpGet]
        public IActionResult Rent()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            var client = _clientsRepository.GetById(clientId);
            var movies = _moviesRepository.GetAll();
            ViewData["Client"] = client;

            HttpContext.Session.SetInt32("userId", clientId);

            return View(movies);
        }

        [HttpGet]
        public IActionResult OrderId(int id)
        {
            // movie client want to order by movie id
            var movie = _moviesRepository.GetById(id);

            // check if there available copies of movie by movie id
            var availableCopy = _copiesRepository
                .GetMany(x => (bool)x.Available && x.MovieId == id);

            if (availableCopy == null)
                return NotFound($"There is no available copies of {movie?.Title}");

            // pass movie instance to view
            ViewData["Movie"] = movie;

            // get client id from session 
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            // get instance of client by id
            var client = _clientsRepository.GetById(clientId);

            // set instance of client to view data of view
            ViewData["Client"] = client;

            // set client id for next session
            HttpContext.Session.SetInt32("clientId", clientId);

            return View();
        }

        [HttpPost]
        public IActionResult OrderId(int id, IFormCollection collection)
        {
            // get available copy of movie by movie id
            var availableCopy = _copiesRepository
                .Get(x => (bool)x.Available && x.MovieId == id);

            // get client id from session
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("clientId");

            // get date of rental
            var dateOfRental = Convert.ToDateTime(collection["DateOfRental"]);

            // get date of return
            var dateOfReturn = Convert.ToDateTime(collection["DateOfReturn"]);

            // instance of new rental
            if (availableCopy != null)
            {
                var newRental = new RentalsModel
                {
                    ClientId = clientId,
                    CopyId = availableCopy.CopyId,
                    DateOfRental = dateOfRental,
                    DateOfReturn = dateOfReturn
                };

                // add new rental to database
                _rentalsRepository.Add(newRental);
            }

            // save changes in db
            _rentalsRepository.Save();

            // redirect to user's dashboard
            return RedirectToAction("Dashboard", "UserLogin", new { id = clientId });

        }

        [HttpGet]
        public IActionResult RentHistory()
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