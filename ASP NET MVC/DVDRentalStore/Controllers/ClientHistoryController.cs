using DVDRentalStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalStore.Controllers
{
    public class ClientHistoryController : Controller
    {
        private readonly ClientHistoryService _service;

        public ClientHistoryController()
        {
            _service = new ClientHistoryService();
        }

        public IActionResult ClientRentalHistory(int id)
        {
            return View(_service.GetHistory(id));
        }
    }
}