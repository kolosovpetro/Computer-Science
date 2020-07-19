using System;
using System.Collections.Generic;

namespace DVDRentalStore.Models
{
    public partial class ClientsModel
    {
        public ClientsModel()
        {
            Rentals = new HashSet<RentalsModel>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<RentalsModel> Rentals { get; set; }
    }
}
