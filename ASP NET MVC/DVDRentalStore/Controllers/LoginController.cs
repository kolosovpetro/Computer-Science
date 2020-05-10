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
            ViewData["Movie"] = _rentalDb.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();

            var userId = (int)HttpContext.Session.GetInt32("userId");
            ViewData["Client"] = _rentalDb.Clients
                .Where(x => x.ClientId == userId)
                .FirstOrDefault();

            return View();
        }

        [HttpPost]
        public IActionResult OrderId(int id, IFormCollection collection)
        {
            // get all available copy of movie by id
            var availableCopy = _rentalDb.Copies
                .Where(x => (bool)x.Available && x.MovieId == id)
                .FirstOrDefault();

            // get client id by username
            string userName = HttpContext.Session.GetString("username2");
            var clientId = _rentalDb.Clients
                .Where(x => x.FirstName == userName)
                .Select(t => t.ClientId)
                .FirstOrDefault();

            if (availableCopy == null)
                return NotFound("No available copies of movie");

            return View();
        }

        [HttpGet]
        public IActionResult RentHistory()
        {
            var userId = (int)HttpContext.Session.GetInt32("userId");
            var client = _rentalDb.Clients.Where(x => x.ClientId == userId).FirstOrDefault();
            var clientHistory = (from r in _rentalDb.Rentals
                                 from c in _rentalDb.Copies
                                 from m in _rentalDb.Movies
                                 select new
                                 {
                                     r.ClientId,
                                     m.Title,
                                     m.Year,
                                     m.MovieId,
                                     m.Price,
                                     m.AgeRestriction
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