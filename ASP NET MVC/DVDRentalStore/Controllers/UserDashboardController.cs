using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class UserDashboardController : Controller
    {
        private readonly ClientsRepository _clientsRepository;

        public UserDashboardController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult UserDashboard(int id)
        {
            var client = _clientsRepository.GetAll()
                .FirstOrDefault(x => x.ClientId == id);

            if (client != null)
                HttpContext.Session.SetInt32("userId", client.ClientId);

            return View(client);
        }
    }
}