using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ListOfClientsController : Controller
    {
        private readonly IRepository<ClientsModel> _clientsRepository;

        public ListOfClientsController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new RepositoryBase<ClientsModel>(dbFactory);
        }

        [HttpGet]
        public IActionResult ListOfClients()
        {
            var clients = _clientsRepository.GetAll()
                .OrderBy(x => x.ClientId);
            return View(clients);
        }
    }
}