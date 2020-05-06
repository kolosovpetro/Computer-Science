using System.Collections.Generic;

namespace DVDRentalStore.Models
{
    public partial class MoviesModel
    {
        public MoviesModel()
        {
            Copies = new HashSet<CopiesModel>();
            Starring = new HashSet<StarringModel>();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int? AgeRestriction { get; set; }
        public int MovieId { get; set; }
        public float? Price { get; set; }

        public virtual ICollection<CopiesModel> Copies { get; set; }
        public virtual ICollection<StarringModel> Starring { get; set; }

    }
}
