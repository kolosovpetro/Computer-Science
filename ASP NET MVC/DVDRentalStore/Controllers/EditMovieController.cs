using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class EditMovieController : Controller
    {
        private readonly IRepository<MoviesModel> _moviesRepository;

        public EditMovieController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _moviesRepository.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, IFormCollection collection)
        {
            var movie = _moviesRepository.GetById(id);
            var movieId = int.Parse(collection["MovieId"]);
            var title = collection["Title"].ToString();
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"]);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            if (movie != null)
            {
                movie.MovieId = movieId;
                movie.Title = title;
                movie.Year = year;
                movie.Price = price;
                movie.AgeRestriction = ageRestriction;
                _moviesRepository.Update(movie);
                _moviesRepository.Save();
            }

            return RedirectToAction("AdminSignIn", "AdminSignIn");
        }
    }
}