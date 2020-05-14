using System;
using System.Linq;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RentalContext _rentalContext = new RentalContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            // this is stupid approach to get id, however auto increment doesn't work

            var clientId = _rentalContext.Clients.Select(x => x.ClientId).Max() + 1;

            string firstName = collection["FirstName"];
            string lastName = collection["LastName"];
            DateTime? birthday = Convert.ToDateTime(collection["Birthday"]);



            _rentalContext.Clients.Add(new ClientsModel
            {
                ClientId = clientId,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday
            });

            _rentalContext.SaveChanges();


            return RedirectToAction("Success", "Register", new { id = clientId });
        }

        [HttpGet]
        public IActionResult Success(int id)
        {
            var client = _rentalContext.Clients.FirstOrDefault(x => x.ClientId == id)
                         ?? throw new ArgumentNullException(nameof(id));

            return View(client);
        }
    }
}