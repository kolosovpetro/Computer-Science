using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using DVDRentalStore.Repositories;
using DVDRentalStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RentController : Controller
    {
        private readonly ClientsRepository _clientsRepository;
        private readonly MoviesRepository _moviesRepository;
        private readonly CopiesRepository _copiesRepository;

        public RentController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
            _moviesRepository = new MoviesRepository(dbFactory);
            _copiesRepository = new CopiesRepository(dbFactory);
        }

        [HttpGet]
        public IActionResult Rent()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            var viewModel =
                (from mov in _moviesRepository.GetAll()
                join cop in _copiesRepository.GetAll()
                    on mov.MovieId equals cop.MovieId
                select new MoviesViewModel()
                {
                    Title = mov.Title,
                    MovieId = mov.MovieId,
                    Year = mov.Year,
                    AgeRestriction = mov.AgeRestriction,
                    Price = mov.Price,
                    Available = cop.Available,
                    Client = _clientsRepository.GetById(clientId)
                }).Where(x => x.Available != null && (bool)x.Available)
                    .OrderBy(g => g.MovieId);   // available copies

            HttpContext.Session.SetInt32("userId", clientId);   // set session integer of clientId

            return View(viewModel);
        }

    }
}