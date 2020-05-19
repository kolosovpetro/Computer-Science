using System.Globalization;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class EditMovieController : Controller
    {
        private readonly MoviesRepository _moviesRepository;

        public EditMovieController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new MoviesRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _moviesRepository.GetById(id);

            if (movie == null)
                return NotFound("No such movie in database");

            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, IFormCollection collection)
        {
            var movie = _moviesRepository.GetById(id);
            var title = collection["Title"].ToString();
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"].ToString(), CultureInfo.InvariantCulture);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            movie.Title = title;
            movie.Year = year;
            movie.Price = price;
            movie.AgeRestriction = ageRestriction;

            _moviesRepository.Update(movie);
            _moviesRepository.Save();

            return RedirectToAction("AdminDashboard", "AdminDashboard");
        }
    }
}