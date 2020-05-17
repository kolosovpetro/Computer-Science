using System;
using System.Collections.Generic;

namespace DVDRentalStore.Models
{
    public partial class ActorsModel
    {
        public ActorsModel()
        {
            Starring = new HashSet<StarringModel>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<StarringModel> Starring { get; set; }
    }
}
