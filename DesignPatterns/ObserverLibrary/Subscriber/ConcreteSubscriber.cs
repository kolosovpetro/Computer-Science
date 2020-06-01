namespace ObserverLibrary.Subscriber
{
    internal class ConcreteSubscriber : ISubscriber
    {
        public bool IsSubscribed { get; private set; }

        public string SubscribedTo { get; private set; }

        public string Notification { get; private set; }

        public void Notify(string notification)
        {
            Notification = notification;
        }

        public void Subscribe(string magazine)
        {
            SubscribedTo = magazine;
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            SubscribedTo = null;
            IsSubscribed = false;
        }
    }
}
