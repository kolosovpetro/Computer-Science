using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DVDRentalStore.DAL;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string userLogin = collection["userLogin"];
            string userPassword = collection["userPassword"];
            EmployeesModel user;

            using (rentalContext rentContext = new rentalContext())
            {
                user = rentContext.Employees
                    .Where(x => x.FirstName == userLogin && x.LastName == userPassword).FirstOrDefault();
            }

            if (user == null)
                throw new Exception("No such user");

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}