using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class LoginController : Controller
    {
        // database context
        private readonly rentalContext _rentalDb = new rentalContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string currentLogin = collection["userLogin"];
            string currentPassword = collection["userPassword"];

            var currentUser = _rentalDb.Clients
                .Where(x => x.FirstName == currentLogin && x.LastName == currentPassword)
                .FirstOrDefault();

            if (currentUser == null)
                return NotFound("No such user");

            return RedirectToAction("Dashboard", "Login", new { id = currentUser.ClientId });
        }

        [HttpGet]
        public IActionResult Dashboard(int id)
        {
            var client = _rentalDb.Clients.Where(x => x.ClientId == id).FirstOrDefault();
            ViewData["Client"] = client;
            HttpContext.Session.SetInt32("userId", client.ClientId);
            return View();
        }

        [HttpGet]
        public IActionResult Rent()
        {
            var userId = (int)HttpContext.Session.GetInt32("userId");
            var client = _rentalDb.Clients.Where(x => x.ClientId == userId).FirstOrDefault();
            var movies = _rentalDb.Movies.Select(x => x);
            ViewData["Client"] = client;
            HttpContext.Session.SetInt32("userId", userId);
            return View(movies);
        }

        [HttpGet]
        public IActionResult OrderId(int id)
        {
            // movie client want to order by movie id
            var movie = _rentalDb.Movies.Where(x => x.MovieId == id).FirstOrDefault();

            // check if there available copies of movie by movie id
            var availableCopy = _rentalDb.Copies.Where(x => (bool)x.Available && x.MovieId == id)
                .FirstOrDefault();

            if (availableCopy == null)
                return NotFound($"There is no available copies of {movie.Title}");

            // pass movie instance to view
            ViewData["Movie"] = movie;

            // get client id from session 
            var userId = (int)HttpContext.Session.GetInt32("userId");

            // get instance of client by id
            var client = _rentalDb.Clients.Where(x => x.ClientId == userId).FirstOrDefault();

            // set instance of client to view data of view
            ViewData["Client"] = client;

            // set client id for next session
            HttpContext.Session.SetInt32("userId", userId);

            return View();
        }

        [HttpPost]
        public IActionResult OrderId(int id, IFormCollection collection)
        {
            // get available copy of movie by movie id
            var availableCopy = _rentalDb.Copies.Where(x => (bool)x.Available && x.MovieId == id)
                .FirstOrDefault();

            // get client id from session
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            // get date of rental
            var dateOfRental = Convert.ToDateTime(collection["DateOfRental"]);

            // get date of return
            var dateOfReturn = Convert.ToDateTime(collection["DateOfReturn"]);

            // instance of new rental
            var newRental = new RentalsModel
            {
                ClientId = clientId,
                CopyId = availableCopy.CopyId,
                DateOfRental = dateOfRental,
                DateOfReturn = dateOfReturn
            };

            // add new rental to database
            _rentalDb.Rentals.Add(newRental);

            // save changes in db
            _rentalDb.SaveChanges();

            // redirect to user's dashboard
            return RedirectToAction("Dashboard", "Login", new { id = clientId });

        }

        [HttpGet]
        public IActionResult RentHistory()
        {
            var userId = (int)HttpContext.Session.GetInt32("userId");
            var client = _rentalDb.Clients.Where(x => x.ClientId == userId).FirstOrDefault();
            var clientHistory = (from r in _rentalDb.Rentals
                                 join c in _rentalDb.Clients
                                 on r.ClientId equals c.ClientId
                                 join cop in _rentalDb.Copies
                                 on r.CopyId equals cop.CopyId
                                 join mov in _rentalDb.Movies
                                 on cop.MovieId equals mov.MovieId
                                 select new
                                 {
                                     mov.Title,
                                     mov.Year,
                                     mov.AgeRestriction,
                                     mov.MovieId,
                                     mov.Price,
                                     c.ClientId
                                 }).Where(x => x.ClientId == userId).Distinct();

            List<MoviesModel> clientMovies = new List<MoviesModel>();

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