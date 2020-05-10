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
            // movie client want to order
            ViewData["Movie"] = _rentalDb.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();

            // instance of client
            var userId = (int)HttpContext.Session.GetInt32("userId");

            // set instance of client to view data of view
            ViewData["Client"] = _rentalDb.Clients
                .Where(x => x.ClientId == userId)
                .FirstOrDefault();

            // set session for client id
            HttpContext.Session.SetInt32("userId", userId);

            return View();
        }

        [HttpPost]
        public IActionResult OrderId(int id, IFormCollection collection)
        {
            // get all available copy of movie by id
            var availableCopy = _rentalDb.Copies
                .Where(x => (bool)x.Available && x.MovieId == id)
                .FirstOrDefault();

            // get client id from previous form
            var userId = HttpContext.Session.GetInt32("userId");

            // get client instance by 
            var clientId = _rentalDb.Clients
                .Where(x => x.ClientId == userId)
                .Select(t => t.ClientId)
                .FirstOrDefault();

            // this check has to be moved in previous controller method
            if (availableCopy == null)
                return NotFound("No available copies of movie");

            // get date of rental
            var dateOfRental = Convert.ToDateTime(collection["DateOfRental"]);

            // get date of return
            var dateOfReturn = Convert.ToDateTime(collection["DateOfReturn"]);

            // add rental to database
            _rentalDb.Rentals.Add(new RentalsModel
            {
                ClientId = clientId,
                CopyId = availableCopy.CopyId,
                DateOfRental = dateOfRental,
                DateOfReturn = dateOfReturn
            });

            _rentalDb.SaveChanges();

            // set copy to be unavailable
            availableCopy.Available = false;
            _rentalDb.Copies.Update(availableCopy);
            _rentalDb.SaveChanges();

            return RedirectToAction("Index");
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