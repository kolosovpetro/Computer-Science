using System.Collections.Generic;

namespace ObserverLibrary
{
    interface IPublisher
    {
        List<ISubscriber> subs { get; }
        int SubsCount { get; }
        string Name { get; }
        void Subscribe(ISubscriber sub);
        void Unsubscribe(ISubscriber sub);
        void NotifySubscribers(string text);

    }
}
