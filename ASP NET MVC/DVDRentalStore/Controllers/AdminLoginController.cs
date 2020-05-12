using System;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
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
            var adminLogin = collection["FirstName"].ToString();
            var adminPassword = collection["LastName"].ToString();
            var employee = _rentalContext.Employees
                .FirstOrDefault(x => x.FirstName == adminLogin && x.LastName == adminPassword);

            if (employee == null) return NotFound("There is no such employee");
            var employeeId = employee.EmployeeId;
            return RedirectToAction("AdminDashboard", "AdminLogin", new { id = employeeId });
        }

        [HttpGet]
        public IActionResult AdminDashboard(int id)
        {
            var employee = _rentalContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return View(employee);
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

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _rentalContext.Movies.FirstOrDefault(x => x.MovieId == id)
                        ?? throw new ArgumentNullException(nameof(id));
            HttpContext.Session.SetInt32("movieId", id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie()
        {
            var movieId = HttpContext.Session.GetInt32("movieId");

            // get all copies by movie id
            var copiesByMovieId = _rentalContext.Copies
                .Where(x => x.MovieId == movieId)
                .ToArray();

            var copiesIndexes = copiesByMovieId.Select(x => x.CopyId);

            // get rentals by copy id
            var rentalsByCopyId = _rentalContext.Rentals
                .Where(x => copiesIndexes.Contains(x.CopyId))
                .ToArray();

            // delete of all rentals with copies by movie id
            _rentalContext.Rentals.RemoveRange(rentalsByCopyId);

            // delete all copies with movie id == id
            _rentalContext.Copies.RemoveRange(copiesByMovieId);

            // get all starring by movie id
            var starringByMovieId = _rentalContext.Starring
                .Where(x => x.MovieId == movieId)
                .ToArray();

            // delete all starring by movie id
            _rentalContext.Starring.RemoveRange(starringByMovieId);

            // get all movies with id
            var movieById = _rentalContext.Movies.FirstOrDefault(x => x.MovieId == movieId);

            // delete all movies by id
            _rentalContext.Movies.Remove(movieById ?? throw new NullReferenceException());

            // save changes
            _rentalContext.SaveChanges();

            // load main page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(IFormCollection collection)
        {
            // movie id is calculated from database
            var movieId = _rentalContext.Movies.Select(x => x.MovieId).Max() + 1;

            // get movie data from form collection
            var movieTitle = collection["Title"].ToString();
            var movieYear = int.Parse(collection["Year"]);
            var moviePrice = float.Parse(collection["Price"]);
            var movieAgeRestriction = int.Parse(collection["AgeRestriction"]);

            // create new movie instance
            var newMovie = new MoviesModel
            {
                Title = movieTitle,
                MovieId = movieId,
                Year = movieYear,
                AgeRestriction = movieAgeRestriction,
                Price = moviePrice
            };

            // add an instance of new movie to database
            _rentalContext.Movies.Add(newMovie);

            // save changes in database
            _rentalContext.SaveChanges();

            // redirect to index
            return RedirectToAction("Index");
        }
    }
}