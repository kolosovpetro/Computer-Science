using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IRepository<EmployeesModel> _employeesRepository;

        public AdminDashboardController()
        {
            IDbFactory dbFactory = new DbFactory();
            _employeesRepository = new RepositoryBase<EmployeesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult AdminDashboard(int id)
        {
            var employee = _employeesRepository.Get(x => x.EmployeeId == id);
            return View(employee);
        }
    }
}