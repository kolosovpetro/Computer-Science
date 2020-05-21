using DVDRentalStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminServices _adminServices = new AdminServices();

        [HttpGet]
        public IActionResult AdminSignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSignIn(IFormCollection collection)
        {
            var admin = _adminServices.AdminSignInModel(collection);
            if (admin == null)
                return NotFound("Wrong login or password");
            HttpContext.Session.SetInt32("AdminId", admin.EmployeeId);      // set admin id in session
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null)
                return NotFound("Wrong login or password");
            var admin = _adminServices.GetEmployeeModelById((int)adminId);
            return View(admin);

        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(IFormCollection collection)
        {
            var client = _adminServices.AddClientModel(collection);
            _adminServices.AddAndSaveClientInDatabase(client);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            var client = _adminServices.GetClientModelById(id);
            if (client == null)
                return NotFound("No such client in database");
            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(int id, IFormCollection collection)
        {
            _adminServices.EditAndSaveClient(id, collection);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpGet]
        public IActionResult ListOfMovies()
        {
            var movies = _adminServices.ListOfMoviesModel();
            return View(movies);
        }

        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _adminServices.ListOfClientModel();
            return View(clients);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _adminServices.GetMovieById(id);
            if (movie == null) return NotFound("No such movie in database");
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, IFormCollection collection)
        {
            _adminServices.EditAndSaveMovie(id, collection);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _adminServices.GetMovieById(id);
            HttpContext.Session.SetInt32("movieId", id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie()
        {
            var movieId = HttpContext.Session.GetInt32("movieId");
            _adminServices.DeleteAndSaveMovie(movieId);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(IFormCollection collection)
        {
            var movie = _adminServices.AddMovieModel(collection);
            _adminServices.AddAndSaveMovie(movie);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteClient(int clientId)
        {
            var client = _adminServices.GetClientModelById(clientId);
            HttpContext.Session.SetInt32("clientId", clientId);
            return View(client);
        }

        [HttpPost]
        public IActionResult DeleteClient()
        {
            var clientId = HttpContext.Session.GetInt32("clientId");
            _adminServices.DeleteAndSaveClient(clientId);
            return RedirectToAction("AdminDashboard", "Admin");
        }
    }
}