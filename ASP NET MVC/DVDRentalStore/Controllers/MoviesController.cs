using System;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly rentalContext _rentalContext = new rentalContext();

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

            return RedirectToAction("Index", "AdminLogin");
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

            // redirect to admin login from
            return RedirectToAction("Index", "AdminLogin");
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
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}