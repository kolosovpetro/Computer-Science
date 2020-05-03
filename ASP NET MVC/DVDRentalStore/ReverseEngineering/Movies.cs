using System;
using System.Collections.Generic;

namespace DVDRentalStore.ReverseEngineering
{
    public partial class Movies
    {
        public Movies()
        {
            Copies = new HashSet<Copies>();
            Starring = new HashSet<Starring>();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int? AgeRestriction { get; set; }
        public int MovieId { get; set; }
        public float? Price { get; set; }

        public virtual ICollection<Copies> Copies { get; set; }
        public virtual ICollection<Starring> Starring { get; set; }

        public override string ToString()
        {
            return $"{MovieId} - {Title} - {Year} - {Price}";
        }
    }
}
