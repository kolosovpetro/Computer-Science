using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository<MoviesModel> _moviesRepository;
        private readonly IRepository<CopiesModel> _copiesRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;
        private readonly IRepository<StarringModel> _starringRepository;

        public MoviesController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
            _copiesRepository = new RepositoryBase<CopiesModel>(dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(dbFactory);
            _starringRepository = new RepositoryBase<StarringModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult ListOfMovies()
        {
            var movies = _moviesRepository.GetAll();
            return View(movies);
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

            return RedirectToAction("Index", "AdminLogin");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _moviesRepository.GetById(id);
            HttpContext.Session.SetInt32("movieId", id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie()
        {
            var id = (int)HttpContext.Session.GetInt32("movieId");  // movie id

            // get all copies id's by movie id
            var copiesById = _copiesRepository
                .GetMany(x => x.MovieId == id)
                .Select(x => x.CopyId)
                .ToArray();

            // delete of all rentals with copies by movie id
            _rentalsRepository.Delete(x => copiesById.Contains(x.CopyId));

            // delete all copies with: movie id == id
            _copiesRepository.Delete(x => x.MovieId == id);

            // delete all starring by movie id
            _starringRepository.Delete(x => x.MovieId == id);

            // get all movies with id: x => x.MovieId == movieId
            var movieById = _moviesRepository.GetById(id);

            // delete all movies by id
            _moviesRepository.Delete(movieById);

            // save changes
            _moviesRepository.Save();

            // redirect to admin login from
            return RedirectToAction("Index", "AdminLogin");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(IFormCollection collection)
        {
            // movie id is calculated from database
            var id = _moviesRepository.GetAll().Max(x => x.MovieId) + 1;

            // get movie data from form collection
            var title = collection["Title"].ToString();
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"]);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            // create new movie instance
            var movie = new MoviesModel
            {
                Title = title,
                MovieId = id,
                Year = year,
                AgeRestriction = ageRestriction,
                Price = price
            };

            // add an instance of new movie to database
            _moviesRepository.Add(movie);

            // save changes in database
            _moviesRepository.Save();

            // redirect to index
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}