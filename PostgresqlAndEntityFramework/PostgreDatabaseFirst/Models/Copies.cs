using System.Collections.Generic;

namespace PostgreDatabaseFirst.Models
{
    public partial class Copies
    {
        public Copies()
        {
            Rentals = new HashSet<Rentals>();
        }

        public int CopyId { get; set; }
        public bool? Available { get; set; }
        public int? MovieId { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual ICollection<Rentals> Rentals { get; set; }

        public override string ToString()
        {
            return $"Movie Id: {MovieId}, " +
                $"Copy Id: {CopyId}, " +
                $"Available: {(bool)Available}, " +
                $"Title: {Movie.Title}";
        }
    }
}
