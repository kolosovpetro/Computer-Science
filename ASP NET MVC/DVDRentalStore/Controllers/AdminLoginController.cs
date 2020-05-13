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
            var adminLogin = collection["FirstName"].ToString();
            var adminPassword = collection["LastName"].ToString();
            var employee = _rentalContext.Employees
                .FirstOrDefault(x => x.FirstName == adminLogin && x.LastName == adminPassword);

            if (employee == null) return NotFound("There is no such employee");
            var employeeId = employee.EmployeeId;
            return RedirectToAction("AdminDashboard", "AdminLogin", new { id = employeeId });
        }

        [HttpGet]
        public IActionResult AdminDashboard(int id)
        {
            var employee = _rentalContext.Employees
                .FirstOrDefault(x => x.EmployeeId == id);
            return View(employee);
        }

    }
}