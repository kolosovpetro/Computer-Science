using IdentityAndPostgres.Models;

namespace IdentityAndPostgres.ViewModels
{
    public class ClientHistoryViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int? AgeRestriction { get; set; }
        public int MovieId { get; set; }
        public float? Price { get; set; }
        public ClientsModel Client { get; set; }
    }
}
