using System;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
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
            var clientId = _clientsRepository.GetAll()
                               .Max(x => x.ClientId) + 1;   // calculate new client id

            var firstName = collection["FirstName"].ToString();    // get client firstname

            var lastName = collection["LastName"].ToString();  // get client lastname

            var birthday = Convert.ToDateTime(collection["Birthday"]);  // get client birthday

            var client = new ClientsModel
            {
                ClientId = clientId,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday
            };

            _clientsRepository.Add(client);     // add new client to database
            _clientsRepository.Save();

            return RedirectToAction("AdminDashboard", "AdminDashboard");  // redirect to dashboard
        }
    }
}