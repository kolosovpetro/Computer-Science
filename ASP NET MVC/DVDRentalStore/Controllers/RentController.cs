using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class RentController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;
        private readonly IRepository<MoviesModel> _moviesRepository;

        public RentController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
            _moviesRepository = new RepositoryBase<MoviesModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult Rent()
        {
            // ReSharper disable once PossibleInvalidOperationException
            var clientId = (int)HttpContext.Session.GetInt32("userId");

            var client = _clientsRepository.GetById(clientId);
            var movies = _moviesRepository.GetAll();
            ViewData["Client"] = client;

            HttpContext.Session.SetInt32("userId", clientId);

            return View(movies);
        }

    }
}