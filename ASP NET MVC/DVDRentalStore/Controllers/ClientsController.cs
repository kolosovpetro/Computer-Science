using System;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientsController : Controller
    {
        private readonly rentalContext _rentalContext = new rentalContext();

        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _rentalContext.Clients
                .Select(x => x)
                .OrderBy(x => x.ClientId);
            return View(clients);
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            var client = _rentalContext
                             .Clients
                             .FirstOrDefault(x => x.ClientId == id)
                         ?? throw new ArgumentNullException(nameof(id));

            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(int id, IFormCollection collection)
        {
            var client = _rentalContext.Clients.FirstOrDefault(x => x.ClientId == id);
            var newFirstName = collection["FirstName"].ToString();
            var newLastName = collection["LastName"].ToString();
            var newBirthDay = Convert.ToDateTime(collection["Birthday"]);

            if (client != null)
            {
                client.FirstName = newFirstName;
                client.LastName = newLastName;
                client.Birthday = newBirthDay;
                _rentalContext.Update(client);
                _rentalContext.SaveChanges();
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
            var newClientId = _rentalContext.Clients.Select(x => x.ClientId).Max() + 1;

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
            _rentalContext.Clients.Add(newClient);

            // save changes in database
            _rentalContext.SaveChanges();

            // redirect to index
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}