using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class DeleteMovieController : Controller
    {
        private readonly IRepository<MoviesModel> _moviesRepository;
        private readonly IRepository<CopiesModel> _copiesRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;

        public DeleteMovieController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
            _copiesRepository = new RepositoryBase<CopiesModel>(dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _moviesRepository.GetById(id);
            HttpContext.Session.SetInt32("movieId", id);        // set movie id in session
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie()
        {
            var movieId = HttpContext.Session.GetInt32("movieId");  // movie id

            var copies = _copiesRepository
                .GetMany(x => x.MovieId == movieId);    // all copies by movie id

            var rentals = _rentalsRepository
                .GetMany(x => copies
                    .Select(t => t.CopyId).Contains(x.CopyId));     // rentals by all copies

            _rentalsRepository.Delete(rentals);     // delete from rentals
            _rentalsRepository.Save();

            _copiesRepository.Delete(copies);       // delete all copies
            _copiesRepository.Save();

            _moviesRepository.Delete(x => x.MovieId == movieId);    // delete movie by movie id
            _moviesRepository.Save();

            return RedirectToAction("AdminSignIn", "AdminSignIn");     // redirect to index
        }
    }
}