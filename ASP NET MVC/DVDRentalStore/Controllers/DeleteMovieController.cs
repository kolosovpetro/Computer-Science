using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class DeleteMovieController : Controller
    {
        private readonly MoviesRepository _moviesRepository;
        private readonly CopiesRepository _copiesRepository;
        private readonly RentalsRepository _rentalsRepository;

        public DeleteMovieController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new MoviesRepository(dbFactory);
            _copiesRepository = new CopiesRepository(dbFactory);
            _rentalsRepository = new RentalsRepository(dbFactory);
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

            return RedirectToAction("AdminDashboard", "AdminDashboard");     // redirect to dashboard
        }
    }
}