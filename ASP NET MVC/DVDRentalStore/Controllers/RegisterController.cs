using System;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;

        public RegisterController()
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
            // this is stupid approach to get id, however auto increment doesn't work

            var clientId = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;

            string firstName = collection["FirstName"];
            string lastName = collection["LastName"];
            DateTime? birthday = Convert.ToDateTime(collection["Birthday"]);

            _clientsRepository.Add(new ClientsModel
            {
                ClientId = clientId,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday
            });

            _clientsRepository.Save();

            return RedirectToAction("Success", "Register", new { id = clientId });
        }

        [HttpGet]
        public IActionResult Success(int id)
        {
            var client = _clientsRepository.GetById(id);
            return View(client);
        }
    }
}