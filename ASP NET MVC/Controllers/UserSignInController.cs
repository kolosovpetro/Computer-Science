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
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();

            var user = _clientsRepository.GetAll()
                .FirstOrDefault(x => x.FirstName == username && x.LastName == password);

            if (user == null)
                return NotFound("Wrong username or password");

            return RedirectToAction("UserDashboard", "UserDashboard", new { id = user.ClientId });
        }
    }
}