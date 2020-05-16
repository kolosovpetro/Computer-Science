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
            var clientId = _clientsRepository.GetAll()
                .Max(x => x.ClientId) + 1;  // calculate new client id

            var firstname = collection["FirstName"];
            var lastname = collection["LastName"];
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            _clientsRepository.Add(new ClientsModel
            {
                ClientId = clientId,
                FirstName = firstname,
                LastName = lastname,
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