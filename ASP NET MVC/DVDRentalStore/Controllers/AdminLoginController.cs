using System;
using System.Linq;
using DVDRentalStore.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly rentalContext _rentalContext = new rentalContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            var adminLogin = collection["adminLogin"].ToString();
            var adminPassword = collection["adminPassword"].ToString();
            var employee = _rentalContext.Employees
                .FirstOrDefault(x => x.FirstName == adminLogin && x.LastName == adminPassword);

            if (employee == null) return NotFound("There is no such employee");
            var employeeId = employee.EmployeeId;
            return RedirectToAction("AdminDashboard", "AdminLogin", new {id = employeeId});
        }

        [HttpGet]
        public IActionResult AdminDashboard(int id)
        {
            var employee = _rentalContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            ViewData["Employee"] = employee;
            return View();
        }
        
        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _rentalContext.Clients.Select(x => x);
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
    }
}