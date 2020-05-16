using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class UserSignInController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;

        public UserSignInController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string username = collection["FirstName"];
            string password = collection["LastName"];

            var user = _clientsRepository.GetAll()
                .FirstOrDefault(x => x.FirstName == username && x.LastName == password);

            if (user == null)
                return NotFound("No such user");

            return RedirectToAction("UserDashboard", "UserDashboard", new { id = user.ClientId });
        }
    }
}