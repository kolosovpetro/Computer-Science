using System.Collections.Generic;
using AutoMapper;
using IdentityAndPostgres.Models;
using IdentityAndPostgres.Services;
using IdentityAndPostgres.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndPostgres.Controllers
{
    public class MainController : Controller
    {
        private readonly MainServices _mainServices = new MainServices();

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(IFormCollection collection)
        {
            var client = _mainServices.AddClientModel(collection);
            _mainServices.AddAndSaveClientInDatabase(client);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            var client = _mainServices.GetClientModelById(id);
            if (client == null)
                return NotFound("No such client in database");
            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(int id, IFormCollection collection)
        {
            _mainServices.EditAndSaveClient(id, collection);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ListOfMovies()
        {
            var movies = _mainServices.ListOfMoviesModel();
            // configure automapper
            var config = new MapperConfiguration(cfg => cfg
                .CreateMap<MoviesModel, MoviesViewModel>());
            // create automapper instance
            var mapper = new Mapper(config);
            // mapping
            var viewModel = mapper.Map<IEnumerable<MoviesViewModel>>(movies);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _mainServices.ListOfClientModel();
            return View(clients);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _mainServices.GetMovieById(id);
            if (movie == null) return NotFound("No such movie in database");
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, IFormCollection collection)
        {
            _mainServices.EditAndSaveMovie(id, collection);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            var movie = _mainServices.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            _mainServices.DeleteAndSaveMovie(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(IFormCollection collection)
        {
            var movie = _mainServices.AddMovieModel(collection);
            _mainServices.AddAndSaveMovie(movie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DeleteClient(int clientId)
        {
            var client = _mainServices.GetClientModelById(clientId);
            HttpContext.Session.SetInt32("clientId", clientId);
            return View(client);
        }

        [HttpPost]
        public IActionResult DeleteClient()
        {
            var clientId = HttpContext.Session.GetInt32("clientId");
            _mainServices.DeleteAndSaveClient(clientId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MovieDetails(int id)
        {
            var model = _mainServices.GetMovieById(id);
            // configure automapper
            var config = new MapperConfiguration(cfg => cfg
                .CreateMap<MoviesModel, MoviesViewModel>());
            // create automapper instance
            var mapper = new Mapper(config);
            // mapping
            var viewModel = mapper.Map<MoviesViewModel>(model);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ClientRentalHistory(int id)
        {
            return View(_mainServices.GetHistory(id));
        }
    }
}