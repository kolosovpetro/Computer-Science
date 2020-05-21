using DVDRentalStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientServices _services = new ClientServices();

        [HttpGet]
        public IActionResult ClientRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClientRegister(IFormCollection collection)
        {
            var client = _services.ClientRegisterPost(collection);
            _services.AddToDatabase(client);
            return RedirectToAction("Success", "Client", new { id = client });
        }

        [HttpGet]
        public IActionResult Success(int id)
        {
            var client = _services.GetSuccessModel(id);
            return View(client);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            var client = _services.ClientSignInModel(collection);
            if (client == null) return NotFound("Wrong username or password");
            return RedirectToAction("ClientDashboard", "Client", new { id = client.ClientId });
        }

        [HttpGet]
        public IActionResult ClientDashboard(int id)
        {
            var client = _services.UserDashboardModel(id);
            return View(client);
        }

        [HttpGet]
        public IActionResult Rent()
        {
            var viewModel = _services.RentMovieViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ClientRentalHistory(int clientId)
        {
            return View(_services.GetHistory(clientId));
        }
    }
}