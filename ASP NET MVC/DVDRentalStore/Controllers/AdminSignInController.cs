using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AdminSignInController : Controller
    {
        private readonly IRepository<EmployeesModel> _employeesRepository;

        public AdminSignInController()
        {
            IDbFactory dbFactory = new DbFactory();
            _employeesRepository = new RepositoryBase<EmployeesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult AdminSignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSignIn(IFormCollection collection)
        {
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();
            var employee = _employeesRepository
                .Get(x => x.FirstName == username && x.LastName == password);

            if (employee == null) return NotFound("There is no such employee");
            var employeeId = employee.EmployeeId;
            return RedirectToAction("AdminDashboard", "AdminDashboard", new { id = employeeId });
        }
    }
}