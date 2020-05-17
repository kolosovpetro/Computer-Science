using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ListOfMoviesController : Controller
    {
        private readonly IRepository<MoviesModel> _moviesRepository;

        public ListOfMoviesController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
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