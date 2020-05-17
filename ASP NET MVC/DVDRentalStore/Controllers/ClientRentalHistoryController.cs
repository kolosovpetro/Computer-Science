﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Misc;
using DVDRentalStore.Models;
using DVDRentalStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientRentalHistoryController : Controller
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepository<CopiesModel> _copiesRepository;
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<RentalsModel> _rentalsRepository;
        private readonly IRepository<MoviesModel> _moviesRepository;

        public ClientRentalHistoryController()
        {
            _dbFactory = new DbFactory();
            _copiesRepository = new RepositoryBase<CopiesModel>(_dbFactory);
            _clientsRepository = new RepositoryBase<ClientsModel>(_dbFactory);
            _rentalsRepository = new RepositoryBase<RentalsModel>(_dbFactory);
            _moviesRepository = new RepositoryBase<MoviesModel>(_dbFactory);
        }

        private List<MoviesViewModel> GetHistory(int clientId)
        {
            // mapper config
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<ClientHistoryQueryObject, MoviesViewModel>());

            // mapper config
            var mapper = new Mapper(config);

            // return collection
            var query = (from r in _rentalsRepository.GetAll()
                         join c in _clientsRepository.GetAll()
                             on r.ClientId equals c.ClientId
                         join cop in _copiesRepository.GetAll()
                             on r.CopyId equals cop.CopyId
                         join mov in _moviesRepository.GetAll()
                             on cop.MovieId equals mov.MovieId
                         select new ClientHistoryQueryObject()
                         {
                             Title = mov.Title,
                             Year = mov.Year,
                             AgeRestriction = mov.AgeRestriction,
                             MovieId = mov.MovieId,
                             Price = mov.Price,
                             ClientId = c.ClientId
                         })
                .Where(x => x.ClientId == clientId)
                .OrderBy(x => x.MovieId)
                .Distinct()
                .ToList();

            var result = mapper.Map<List<MoviesViewModel>>(query);

            return result;
        }

        public IActionResult ClientRentalHistory()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            var client = _dbFactory.Init().Clients
                .FirstOrDefault(x => x.ClientId == clientId);   // we access this way since of 2-pkey

            ViewData["Client"] = client;

            return View(GetHistory(clientId));
        }
    }
}