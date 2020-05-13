using System;
using System.Collections.Generic;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RentalsController : Controller
    {
        private readonly rentalContext _rentalContext = new rentalContext();

        [HttpGet]
        public IActionResult Rent()
        {
            var userId = (int)HttpContext.Session.GetInt32("userId");
            var client = _rentalContext.Clients.FirstOrDefault(x => x.ClientId == userId);
            var movies = _rentalContext.Movies.Select(x => x);
            ViewData["Client"] = client;
            HttpContext.Session.SetInt32("userId", userId);
            return View(movies);
        }

        [HttpGet]
        public IActionResult OrderId(int id)
        {
            // movie client want to order by movie id
            var movie = _rentalContext.Movies.FirstOrDefault(x => x.MovieId == id);

            // check if there available copies of movie by movie id
            var availableCopy = _rentalContext.Copies
                .FirstOrDefault(x => (bool)x.Available && x.MovieId == id);

            if (availableCopy == null)
                return NotFound($"There is no available copies of {movie?.Title}");

            // pass movie instance to view
            ViewData["Movie"] = movie;

            // get client id from session 
            var userId = (int)HttpContext.Session.GetInt32("userId");

            // get instance of client by id
            var client = _rentalContext.Clients.FirstOrDefault(x => x.ClientId == userId);

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
            var availableCopy = _rentalContext.Copies
                .FirstOrDefault(x => (bool)x.Available && x.MovieId == id);

            // get client id from session
            var clientId = (int)HttpContext.Session.GetInt32("userId");

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
                _rentalContext.Rentals.Add(newRental);
            }

            // save changes in db
            _rentalContext.SaveChanges();

            // redirect to user's dashboard
            return RedirectToAction("Dashboard", "UserLogin", new { id = clientId });

        }

        [HttpGet]
        public IActionResult RentHistory()
        {
            var userId = (int)HttpContext.Session.GetInt32("userId");

            var client = _rentalContext.Clients.FirstOrDefault(x => x.ClientId == userId);
            var clientHistory = (from r in _rentalContext.Rentals
                                 join c in _rentalContext.Clients
                                 on r.ClientId equals c.ClientId
                                 join cop in _rentalContext.Copies
                                 on r.CopyId equals cop.CopyId
                                 join mov in _rentalContext.Movies
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