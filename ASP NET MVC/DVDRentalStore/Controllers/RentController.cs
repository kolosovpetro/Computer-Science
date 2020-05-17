using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Misc;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RentController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<MoviesModel> _moviesRepository;
        private readonly IRepository<CopiesModel> _copiesRepository;

        public RentController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
            _copiesRepository = new RepositoryBase<CopiesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult Rent()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            // select movies where are available copy
            var joinModels =
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

            // get set of available copies by movie id
            var availableMovies = joinModels
                .Where(x => x.Available != null && (bool)x.Available)
                .OrderBy(g => g.MovieId);

            // config auto-mapper
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<AvailableMovieQueryObject, MoviesModel>());

            // create auto-mapper instance
            var mapper = new Mapper(config);

            // map collection we got previously
            var viewModel = mapper.Map<IEnumerable<MoviesModel>>(availableMovies);

            var client = _clientsRepository.GetById(clientId);

            ViewData["Client"] = client;

            HttpContext.Session.SetInt32("userId", clientId);

            return View(viewModel);
        }

    }
}