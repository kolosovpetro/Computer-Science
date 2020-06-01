using System.Collections.Generic;
using ObserverLibrary.Subscriber;

namespace ObserverLibrary.Publisher
{
    internal class ConcretePublisher : IPublisher
    {
        public List<ISubscriber> Subscribers { get; }

        public int SubscribersCount => Subscribers.Count;

        public string Name { get; }

        public ConcretePublisher(string name)
        {
            Name = name;
            Subscribers = new List<ISubscriber>();
        }

        public void NotifySubscribers(string notification)
        {
            foreach (var sub in Subscribers)
            {
                sub.Notify(notification);
            }
        }

        public void Subscribe(ISubscriber subscriber)
        {
            Subscribers.Add(subscriber);
            subscriber.Subscribe(Name);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            if (Subscribers.Contains(subscriber))
            {
                int index = Subscribers.IndexOf(subscriber);
                subscriber.Unsubscribe();
                Subscribers.RemoveAt(index);
            }

            throw new SubscriberNotFoundException("There is no suc subscriber in the list");
        }
    }
}
