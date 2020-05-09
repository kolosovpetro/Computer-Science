using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class LoginController : Controller
    {
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
            ClientsModel client;


            client = _rentalDb.Clients
                .Where(x => x.FirstName == currentLogin && x.LastName == currentPassword)
                .FirstOrDefault();

            if (client == null)
                throw new Exception("No such user");

            HttpContext.Session.SetString("username", client.FirstName);

            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            string text = HttpContext.Session.GetString("username");
            HttpContext.Session.SetString("username2", text);
            return View();
        }

        [HttpGet]
        public IActionResult Rent()
        {
            ViewBag.username2 = HttpContext.Session.GetString("username2");
            string text = HttpContext.Session.GetString("username2");
            HttpContext.Session.SetString("username2", text);
            var movs = _rentalDb.Movies.Select(x => x);
            return View(movs);
        }

        [HttpGet]
        public IActionResult OrderId(int id)
        {
            ViewBag.username2 = HttpContext.Session.GetString("username2");
            ViewBag.movieTitle = _rentalDb.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault().Title;

            return View();
        }

        [HttpPost]
        public IActionResult OrderId(int id, IFormCollection collection)
        {
            // get all available copy of movie dy id
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
                throw new Exception("There is no available copies");

            return View();
        }
    }
}