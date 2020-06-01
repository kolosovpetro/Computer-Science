using System.Collections.Generic;
using ObserverLibrary.Subscriber;

namespace ObserverLibrary.Publisher
{
    internal interface IPublisher
    {
        List<ISubscriber> Subscribers { get; }
        int SubscribersCount { get; }
        string Name { get; }
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void NotifySubscribers(string notification);

    }
}
