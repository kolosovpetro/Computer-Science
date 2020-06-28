using System.Collections.Generic;

namespace CodeFirstCLI.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public int Yaer { get; set; }

        // navigational property
        public ICollection<UserSubscription> Subscriptions { get; set; }
    }
}