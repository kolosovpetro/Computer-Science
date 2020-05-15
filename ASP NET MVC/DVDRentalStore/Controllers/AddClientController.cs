using System;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AddClientController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;

        public AddClientController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(IFormCollection collection)
        {
            // client id of new client to be calculated
            var clientId = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;

            // firstname of new client
            var firstName = collection["FirstName"];

            // lastname of new client
            var lastName = collection["LastName"];

            // birthday of new client
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            // instance of new client
            var client = new ClientsModel
            {
                ClientId = clientId,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday
            };

            // append new client to database
            _clientsRepository.Add(client);

            // save changes in database
            _clientsRepository.Save();

            // redirect to index
            return RedirectToAction("AdminSignIn", "AdminSignIn");
        }
    }
}