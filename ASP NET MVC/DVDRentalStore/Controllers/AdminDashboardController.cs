﻿using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AdminDashboard()
        {
            var adminId = HttpContext.Session.GetInt32("adminId");
            var admin = _employeesRepository.Get(x => x.EmployeeId == adminId);

            if (admin == null)
                return NotFound("No such admin user or wrong attempt to connect");

            ViewData["Admin"] = admin;
            return View();

        }
    }
}