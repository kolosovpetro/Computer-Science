using System.Collections.Generic;

namespace DVDRentalStore.Models
{
    public partial class CopiesModel
    {
        public CopiesModel()
        {
            Rentals = new HashSet<RentalsModel>();
        }

        public int CopyId { get; set; }
        public bool? Available { get; set; }
        public int? MovieId { get; set; }

        public virtual MoviesModel Movie { get; set; }
        public virtual ICollection<RentalsModel> Rentals { get; set; }
    }
}
