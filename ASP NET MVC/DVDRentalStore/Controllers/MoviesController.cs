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

        public IActionResult Index()
        {
            var movs = _rentalDb.Movies.Select(x => x);
            return View(movs);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _rentalDb.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var movie = _rentalDb.Movies.Where(x => x.MovieId == id).FirstOrDefault();
                movie.MovieId = int.Parse(collection["MovieId"]);
                movie.Title = collection["Title"];
                movie.Year = int.Parse(collection["Year"]);
                movie.AgeRestriction = int.Parse(collection["AgeRestriction"]);
                movie.Price = float.Parse(collection["Price"]);
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

    }
}
