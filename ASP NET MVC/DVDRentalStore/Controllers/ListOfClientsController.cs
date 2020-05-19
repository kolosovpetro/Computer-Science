using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ListOfClientsController : Controller
    {
        private readonly ClientsRepository _clientsRepository;

        public ListOfClientsController()
        {
            IDbFactory dbFactory = new DbFactory();
            _clientsRepository = new ClientsRepository(dbFactory);
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