using System;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;

        public ClientsController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _clientsRepository.GetAll()
                .OrderBy(x => x.ClientId);
            return View(clients);
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            var client = _clientsRepository.GetById(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(int id, IFormCollection collection)
        {
            var client = _clientsRepository.GetById(id);
            var newFirstName = collection["FirstName"].ToString();
            var newLastName = collection["LastName"].ToString();
            var newBirthDay = Convert.ToDateTime(collection["Birthday"]);

            if (client != null)
            {
                client.FirstName = newFirstName;
                client.LastName = newLastName;
                client.Birthday = newBirthDay;
                _clientsRepository.Update(client);
                _clientsRepository.Save();
            }

            return RedirectToAction("Index", "AdminLogin");
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
            var newClientId = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;

            // firstname of new client
            var newFirstName = collection["FirstName"].ToString();

            // lastname of new client
            var newLastName = collection["LastName"].ToString();

            // birthday of new client
            var newBirthday = Convert.ToDateTime(collection["Birthday"]);

            // instance of new client
            var newClient = new ClientsModel
            {
                ClientId = newClientId,
                FirstName = newFirstName,
                LastName = newLastName,
                Birthday = newBirthday
            };

            // append new client to database
            _clientsRepository.Add(newClient);

            // save changes in database
            _clientsRepository.Save();

            // redirect to index
            return RedirectToAction("Index", "AdminLogin");
        }

        [HttpGet]
        public IActionResult DeleteClient(int id)
        {
            var client = _clientsRepository.GetById(id);
            HttpContext.Session.SetInt32("clientId", id);
            return View(client);
        }

        [HttpPost]
        public IActionResult DeleteClient()
        {
            var clientId = HttpContext.Session.GetInt32("clientId");

            // delete from rentals history
            _rentalsRepository.Delete(x => x.ClientId == clientId);

            // delete from clients
            _clientsRepository.Delete(x => x.ClientId == clientId);

            // save changes to databases
            _rentalsRepository.Save();
            _clientsRepository.Save();

            // redirect to index
            return RedirectToAction("Index", "AdminLogin");
        }


    }
}