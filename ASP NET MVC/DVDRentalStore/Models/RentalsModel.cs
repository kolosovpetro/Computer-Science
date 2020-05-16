using System;

namespace DVDRentalStore.Models
{
    public partial class RentalsModel
    {
        public int CopyId { get; set; }
        public int ClientId { get; set; }
        public DateTime? DateOfRental { get; set; }
        public DateTime? DateOfReturn { get; set; }

        public virtual ClientsModel Client { get; set; }
        public virtual CopiesModel Copy { get; set; }
    }
}
