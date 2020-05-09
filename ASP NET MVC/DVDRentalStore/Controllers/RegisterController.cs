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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string firstName = collection["FirstName"];
            string lastName = collection["LastName"];
            DateTime? birthday = Convert.ToDateTime(collection["Birthday"]);

            using (rentalContext rentalDb = new rentalContext())
            {
                // this is stupid approach, however auto increment doesn't work

                int clientId = rentalDb.Clients.Select(x => x.ClientId).Max() + 1;

                rentalDb.Clients
                    .Add(new ClientsModel
                    {
                        ClientId = clientId,
                        FirstName = firstName,
                        LastName = lastName,
                        Birthday = birthday
                    });

                rentalDb.SaveChanges();
            }

            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}