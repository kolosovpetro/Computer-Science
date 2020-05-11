using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DVDRentalStore.DAL;
using Microsoft.AspNetCore.Http;
using System;
using DVDRentalStore.Models;

namespace DVDRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly rentalContext _rentalDb = new rentalContext();

        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            var movies = _rentalDb.Movies.Select(x => x);

            switch (sortOrder)
            {
                case "titleAscending":
                    movies = movies.OrderBy(x => x.Title);
                    break;
                case "yearAscending":
                    movies = movies.OrderBy(x => x.Year);
                    break;
                case "idAscending":
                    movies = movies.OrderBy(x => x.MovieId);
                    break;
                case "ageRestrictionAscending":
                    movies = movies.OrderBy(x => x.AgeRestriction);
                    break;
                case "priceAscending":
                    movies = movies.OrderBy(x => x.AgeRestriction);
                    break;
            }

            return View(movies);
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string searchItem = collection["searchString"];
            ViewBag.currentSearchItem = searchItem;
            var searchResult = _rentalDb.Movies
                .Where(x => x.Title.ToLower().Contains(searchItem.ToLower()));
            return View(searchResult);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _rentalDb.Movies.FirstOrDefault(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var movie = _rentalDb.Movies.FirstOrDefault(x => x.MovieId == id);
                if (movie != null)
                {
                    movie.MovieId = int.Parse(collection["MovieId"]);
                    movie.Title = collection["Title"];
                    movie.Year = int.Parse(collection["Year"]);
                    movie.AgeRestriction = int.Parse(collection["AgeRestriction"]);
                    movie.Price = float.Parse(collection["Price"]);
                }

                _rentalDb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                var newMovie = new MoviesModel
                {
                    MovieId = int.Parse(collection["MovieId"]),
                    Title = collection["Title"],
                    Year = int.Parse(collection["Year"]),
                    AgeRestriction = int.Parse(collection["AgeRestriction"]),
                    Price = float.Parse(collection["Price"])
                };
                _rentalDb.Add(newMovie);
                _rentalDb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mov = _rentalDb.Movies.FirstOrDefault(x => x.MovieId == id);
            return View(mov);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            // get all copies by movie id
            var copiesByMovieId = _rentalDb.Copies
                .Where(x => x.MovieId == id)
                .ToArray();

            var copiesIndexes = copiesByMovieId.Select(x => x.CopyId);

            // get rentals by copy id
            var rentalsByCopyId = _rentalDb.Rentals
                .Where(x => copiesIndexes.Contains(x.CopyId))
                .ToArray();

            // delete of all rentals with copies by movie id
            _rentalDb.Rentals.RemoveRange(rentalsByCopyId);

            // delete all copies with movie id == id
            _rentalDb.Copies.RemoveRange(copiesByMovieId);

            // get all starring by movie id
            var starringByMovieId = _rentalDb.Starring
                .Where(x => x.MovieId == id)
                .ToArray();

            // delete all starring by movie id
            _rentalDb.Starring.RemoveRange(starringByMovieId);

            // get all movies with id
            var movieById = _rentalDb.Movies.FirstOrDefault(x => x.MovieId == id);

            // delete all movies by id
            _rentalDb.Movies.Remove(movieById ?? throw new NullReferenceException());

            // save changes
            _rentalDb.SaveChanges();

            // load main page
            return RedirectToAction("Index");
        }
    }
}