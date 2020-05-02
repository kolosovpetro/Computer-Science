using System;
using System.Collections.Generic;

namespace PostgreDatabaseFirst
{
    public partial class Actors
    {
        public Actors()
        {
            Starring = new HashSet<Starring>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Starring> Starring { get; set; }
    }
}
