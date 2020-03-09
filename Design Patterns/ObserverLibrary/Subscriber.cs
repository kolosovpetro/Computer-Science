namespace ObserverLibrary
{
    class Subscriber : ISubscriber
    {
        public bool IsSubscribed { get; private set; }

        public string SubscriberOf { get; private set; }

        public string NewNotification { get; private set; }

        public void Notify(string newNotification)
        {
            NewNotification = newNotification;
        }

        public void Subscribe(string magazine)
        {
            SubscriberOf = magazine;
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            SubscriberOf = null;
            IsSubscribed = false;
        }
    }
}
