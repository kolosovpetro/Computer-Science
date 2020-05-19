using System;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class EditClientController : Controller
    {
        private readonly ClientsRepository _clientsRepository;

        public EditClientController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            var client = _clientsRepository.GetById(id);

            if (client == null)
                return NotFound("No such client in database");

            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(int id, IFormCollection collection)
        {
            var client = _clientsRepository.GetById(id);
            var firstname = collection["FirstName"].ToString();
            var lastname = collection["LastName"].ToString();
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            client.FirstName = firstname;
            client.LastName = lastname;
            client.Birthday = birthday;
            _clientsRepository.Update(client);
            _clientsRepository.Save();

            return RedirectToAction("AdminDashboard", "AdminDashboard");
        }
    }
}