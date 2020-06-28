namespace CodeFirstCLI.Models
{
    public class UserSubscription
    {
        // navigational properties
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}