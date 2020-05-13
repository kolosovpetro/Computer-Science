using System.Linq;
using DVDRentalStore.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class UserLoginController : Controller
    {
        // database context
        private readonly rentalContext _rentalDb = new rentalContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string currentLogin = collection["FirstName"];
            string currentPassword = collection["LastName"];

            var currentUser = _rentalDb.Clients
                .FirstOrDefault(x => x.FirstName == currentLogin && x.LastName == currentPassword);

            if (currentUser == null)
                return NotFound("No such user");

            return RedirectToAction("Dashboard", "UserLogin", new { id = currentUser.ClientId });
        }

        [HttpGet]
        public IActionResult Dashboard(int id)
        {
            var client = _rentalDb.Clients.FirstOrDefault(x => x.ClientId == id);

            if (client != null) 
                HttpContext.Session.SetInt32("userId", client.ClientId);

            return View(client);
        }

    }
}