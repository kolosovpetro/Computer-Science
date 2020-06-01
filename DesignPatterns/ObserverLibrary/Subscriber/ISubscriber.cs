namespace ObserverLibrary.Subscriber
{
    internal interface ISubscriber
    {
        bool IsSubscribed { get; }
        string SubscribedTo { get; }
        string Notification { get; }

        void Subscribe(string magazine);
        void Unsubscribe();
        void Notify(string notification);
    }
}
