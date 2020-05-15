using System;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class MakeRentalController : Controller
    {
        private readonly IRepository<CopiesModel> _copiesRepository;
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;
        private readonly IRepository<MoviesModel> _moviesRepository;

        public MakeRentalController()
        {
            IDbFactory dbFactory = new DbFactory();
            _copiesRepository = new RepositoryBase<CopiesModel>(dbFactory);
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(dbFactory);
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult MakeRental(int id)
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
        public IActionResult MakeRental(int id, IFormCollection collection)
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

                // save changes in db
                _rentalsRepository.Save();
            }

            // redirect to user's dashboard
            return RedirectToAction("UserDashboard", "UserLogin", new { id = clientId });

        }
    }
}