using System.Collections;
using System.Collections.Generic;

namespace CodeFirstCLI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // navigational property for team
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        // navigational property for address
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        // navigational property for Subscriptions
        public virtual ICollection<UserSubscription> Subscriptions { get; set; }

        public override string ToString()
        {
            return $"Id: {UserId}, Firstname: {FirstName}, Lastname: {LastName} Address: {Address}";
        }
    }
}