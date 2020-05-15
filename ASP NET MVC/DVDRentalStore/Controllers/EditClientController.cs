using System;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class EditClientController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;

        public EditClientController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
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

            return RedirectToAction("AdminSignIn", "AdminSignIn");
        }
    }
}