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
        private readonly IRepository<ActorsModel> _actorsRepository;

        public MoviesController()
        {
            IDbFactory dbFactory = new DbFactory();
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
            _copiesRepository = new RepositoryBase<CopiesModel>(dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(dbFactory);
            _starringRepository = new RepositoryBase<StarringModel>(dbFactory);
            _actorsRepository = new RepositoryBase<ActorsModel>(dbFactory);
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
            var movieId = (int)HttpContext.Session.GetInt32("movieId");  // movie id

            // this is cannot be done since db-first migrations are not allowed

            // 1 - starring select obj where obj.movieId == id
            var starring = _starringRepository
                .GetMany(x => x.MovieId == movieId).ToArray();

            // 2 - array of actor id's in 1
            var starringIndexes = starring.Select(x => x.ActorId).ToArray();

            // 3 delete in actors obj such that obj.actor id IN 2
            _actorsRepository.Delete(x => starringIndexes.Contains(x.ActorId));

            // 4 delete in starring obj such that obj IN 1
            _starringRepository.Delete(starring);

            // 5 select from copies obj such that obj.movie id == movie id
            var copies = _copiesRepository.GetMany(x => x.MovieId == movieId);

            // 6 rentals remove obj such that obj.copyId IN 5
            _rentalsRepository.Delete(x => copies.Select(t => t.CopyId).Contains(x.CopyId));

            // 7 copies remove obj such that obj IN 5
            _copiesRepository.Delete(x => copies.Contains(x));

            // 8 remove movie by movie id
            _moviesRepository.Delete(x => x.MovieId == movieId);

            // 9 save changes to databases
            _moviesRepository.Save();
            _starringRepository.Save();
            _actorsRepository.Save();
            _copiesRepository.Save();
            _rentalsRepository.Save();


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