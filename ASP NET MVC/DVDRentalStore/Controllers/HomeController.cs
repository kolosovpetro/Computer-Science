﻿using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}