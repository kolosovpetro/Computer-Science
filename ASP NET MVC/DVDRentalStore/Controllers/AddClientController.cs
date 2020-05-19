using System;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AddClientController : Controller
    {
        private readonly ClientsRepository _clientsRepository;

        public AddClientController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(IFormCollection collection)
        {
            var id = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;
            var firstname = collection["FirstName"].ToString();
            var lastname = collection["LastName"].ToString();
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            var client = new ClientsModel
            {
                ClientId = id,
                FirstName = firstname,
                LastName = lastname,
                Birthday = birthday
            };

            _clientsRepository.Add(client);     // add new client to database
            _clientsRepository.Save();

            return RedirectToAction("AdminDashboard", "AdminDashboard");  // redirect to dashboard
        }
    }
}