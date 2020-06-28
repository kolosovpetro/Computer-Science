using System.Collections;
using System.Collections.Generic;

namespace CodeFirstCLI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        
        // navigational property
        public virtual ICollection<User> TeamMembers { get; set; }
    }
}