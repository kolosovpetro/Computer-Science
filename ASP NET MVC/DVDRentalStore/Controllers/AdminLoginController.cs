using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly IRepository<EmployeesModel> _employeesRepository;

        public AdminLoginController()
        {
            IDbFactory dbFactory = new DbFactory();
            _employeesRepository = new RepositoryBase<EmployeesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();
            var employee = _employeesRepository
                .Get(x => x.FirstName == username && x.LastName == password);

            if (employee == null) return NotFound("There is no such employee");
            var employeeId = employee.EmployeeId;
            return RedirectToAction("AdminDashboard", "AdminLogin", new { id = employeeId });
        }

        [HttpGet]
        public IActionResult AdminDashboard(int id)
        {
            var employee = _employeesRepository.Get(x => x.EmployeeId == id);
            return View(employee);
        }

    }
}