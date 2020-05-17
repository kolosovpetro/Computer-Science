using System.Globalization;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AddMovieController : Controller
    {
        private readonly MoviesRepository _moviesRepository;

        public AddMovieController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new MoviesRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(IFormCollection collection)
        {
            var id = _moviesRepository.GetAll()
                .Max(x => x.MovieId) + 1;   // calculate new movie id

            var title = collection["Title"].ToString();
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"].ToString(), CultureInfo.InvariantCulture);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            var movie = new MoviesModel
            {
                Title = title,
                MovieId = id,
                Year = year,
                AgeRestriction = ageRestriction,
                Price = price
            };

            _moviesRepository.Add(movie);
            _moviesRepository.Save();

            return RedirectToAction("AdminDashboard", "AdminDashboard");
        }
    }
}