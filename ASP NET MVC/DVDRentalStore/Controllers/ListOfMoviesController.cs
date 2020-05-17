using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ListOfMoviesController : Controller
    {
        private readonly MoviesRepository _moviesRepository;

        public ListOfMoviesController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new MoviesRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult ListOfMovies()
        {
            var movies = _moviesRepository.GetAll()
                .OrderBy(x => x.MovieId);

            return View(movies);
        }
    }
}