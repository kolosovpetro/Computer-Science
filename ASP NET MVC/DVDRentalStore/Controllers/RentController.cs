using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVDRentalStore.DAL;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Misc;
using DVDRentalStore.Models;
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

            // join movies and copies to get available property
            var moviesJoinCopies =
                from mov in _moviesRepository.GetAll()
                join cop in _copiesRepository.GetAll()
                    on mov.MovieId equals cop.MovieId
                select new AvailableMovieQueryObject()
                {
                    Title = mov.Title,
                    MovieId = mov.MovieId,
                    Year = mov.Year,
                    AgeRestriction = mov.AgeRestriction,
                    Price = mov.Price,
                    Available = cop.Available
                };

            var availableCopies = moviesJoinCopies
                .Where(x => x.Available != null && (bool)x.Available)
                .OrderBy(g => g.MovieId);   // available copies

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<AvailableMovieQueryObject, MoviesModel>());   // configure auto-mapper

            var mapper = new Mapper(config);    // create auto-mapper instance

            var viewModel = mapper.Map<IEnumerable<MoviesModel>>(availableCopies);  // map available copies

            var client = _clientsRepository.GetById(clientId);      // get client by id

            ViewData["Client"] = client;    // set client instance to view data

            HttpContext.Session.SetInt32("userId", clientId);   // set session integer of clientId

            return View(viewModel);
        }

    }
}