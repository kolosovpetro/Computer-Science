using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class UserSignInController : Controller
    {
        private readonly ClientsRepository _clientsRepository;

        public UserSignInController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();

            var client = _clientsRepository.GetAll()
                .FirstOrDefault(x => x.FirstName == username && x.LastName == password);

            if (client == null)
                return NotFound("Wrong username or password");

            return RedirectToAction("UserDashboard", "UserDashboard", new { id = client.ClientId });
        }
    }
}