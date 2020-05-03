using System;
using System.Collections.Generic;

namespace DVDRentalStore.ReverseEngineering
{
    public partial class Clients
    {
        public Clients()
        {
            Rentals = new HashSet<Rentals>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
