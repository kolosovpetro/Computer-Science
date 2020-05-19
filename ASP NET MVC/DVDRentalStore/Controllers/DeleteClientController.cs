﻿using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class DeleteClientController : Controller
    {
        private readonly ClientsRepository _clientsRepository;
        private readonly RentalsRepository _rentalsRepository;

        public DeleteClientController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
            _rentalsRepository = new RentalsRepository(dbFactory);
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

            _rentalsRepository.Delete(x => x.ClientId == clientId); // delete client's rentals
            _rentalsRepository.Save();

            _clientsRepository.Delete(x => x.ClientId == clientId); // delete from clients set
            _clientsRepository.Save();

            return RedirectToAction("AdminDashboard", "AdminDashboard");
        }
    }
}