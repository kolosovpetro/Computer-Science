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
            var movie = _moviesRepository.GetById(id);  // get movie by id

            var availableCopy = _copiesRepository
                .Get(x => (bool)x.Available && x.MovieId == id);    // check available copy

            if (availableCopy == null)
                return NotFound($"There is no available copies of {movie?.Title}");

            ViewData["Movie"] = movie;  // bring movie instance to view data

            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");     // get users id from session

            var client = _clientsRepository.GetById(clientId);      // get instance of client

            ViewData["Client"] = client;    // set instance to view

            HttpContext.Session.SetInt32("clientId", clientId);     // set client id for post

            return View();
        }

        [HttpPost]
        public IActionResult MakeRental(int id, IFormCollection collection)
        {
            var availableCopy = _copiesRepository
                .Get(x => (bool)x.Available && x.MovieId == id);    // check available copy

            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("clientId");   // get client id from session

            var dateOfRental = Convert.ToDateTime(collection["DateOfRental"]);  // get date of rental of form

            var dateOfReturn = Convert.ToDateTime(collection["DateOfReturn"]);  // get date of return of form

            var rental = new RentalsModel
            {
                ClientId = clientId,
                CopyId = availableCopy.CopyId,
                DateOfRental = dateOfRental,
                DateOfReturn = dateOfReturn
            };

            _rentalsRepository.Add(rental);
            _rentalsRepository.Save();


            return RedirectToAction("UserDashboard", "UserDashboard", new { id = clientId });
        }
    }
}