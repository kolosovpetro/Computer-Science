﻿using System;
using System.Linq;
using DVDRentalStore.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly rentalContext _rentalContext = new rentalContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            var adminLogin = collection["adminLogin"].ToString();
            var adminPassword = collection["adminPassword"].ToString();
            var employee = _rentalContext.Employees
                .FirstOrDefault(x => x.FirstName == adminLogin && x.LastName == adminPassword);

            if (employee == null) return NotFound("There is no such employee");
            var employeeId = employee.EmployeeId;
            return RedirectToAction("AdminDashboard", "AdminLogin", new {id = employeeId});
        }

        [HttpGet]
        public IActionResult AdminDashboard(int id)
        {
            var employee = _rentalContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            ViewData["Employee"] = employee;
            return View();
        }

        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _rentalContext.Clients.Select(x => x);
            return View(clients);
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            var client = _rentalContext
                             .Clients
                             .FirstOrDefault(x => x.ClientId == id)
                         ?? throw new ArgumentNullException(nameof(id));

            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(int id, IFormCollection collection)
        {
            var client = _rentalContext.Clients.FirstOrDefault(x => x.ClientId == id);
            var newFirstName = collection["FirstName"].ToString();
            var newLastName = collection["LastName"].ToString();
            var newClientId = int.Parse(collection["ClientId"]);
            var newBirthDay = Convert.ToDateTime(collection["Birthday"]);

            if (client != null)
            {
                client.FirstName = newFirstName;
                client.LastName = newLastName;
                client.ClientId = newClientId;
                client.Birthday = newBirthDay;
                _rentalContext.Update(client);
                _rentalContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ListOfMovies()
        {
            var movies = _rentalContext.Movies.Select(x => x);
            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _rentalContext.Movies.FirstOrDefault(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, IFormCollection collection)
        {
            var movie = _rentalContext.Movies.FirstOrDefault(x => x.MovieId == id);
            var newMovieId = int.Parse(collection["MovieId"]);
            var newTitle = collection["Title"].ToString();
            var newYear = int.Parse(collection["Year"]);
            var newPrice = float.Parse(collection["Price"]);
            var newAgeRestriction = int.Parse(collection["AgeRestriction"]);

            if (movie != null)
            {
                movie.MovieId = newMovieId;
                movie.Title = newTitle;
                movie.Year = newYear;
                movie.Price = newPrice;
                movie.AgeRestriction = newAgeRestriction;
                _rentalContext.Update(movie);
                _rentalContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}