using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AddMovieController : Controller
    {
        private readonly IRepository<MoviesModel> _moviesRepository;

        public AddMovieController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
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

            var title = collection["Title"];    
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"]);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            var movie = new MoviesModel
            {
                Title = title,
                MovieId = id,
                Year = year,
                AgeRestriction = ageRestriction,
                Price = price
            };      // instance of new movie to be added

            _moviesRepository.Add(movie);
            _moviesRepository.Save();

            return RedirectToAction("AdminSignIn", "AdminSignIn");
        }
    }
}