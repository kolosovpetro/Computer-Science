namespace ObserverLibrary
{
    interface ISubscriber
    {
        bool IsSubscribed { get; }
        string SubscriberOf { get; }
        string NewNotification { get; }

        void Subscribe(string magazine);
        void Unsubscribe();
        void Notify(string newNotification);
    }
}
