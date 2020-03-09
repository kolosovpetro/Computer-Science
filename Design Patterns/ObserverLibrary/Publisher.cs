using System.Collections.Generic;

namespace ObserverLibrary
{
    class Publisher : IPublisher
    {
        public List<ISubscriber> subs { get; private set; }

        public int SubsCount
        {
            get
            {
                return subs.Count;
            }
        }

        public string Name { get; private set; }

        public Publisher(string name)
        {
            Name = name;
            subs = new List<ISubscriber>();
        }

        public void NotifySubscribers(string notification)
        {
            foreach (ISubscriber sub in subs)
            {
                sub.Notify(notification);
            }
        }

        public void Subscribe(ISubscriber sub)
        {
            subs.Add(sub);
            sub.Subscribe(Name);
        }

        public void Unsubscribe(ISubscriber sub)
        {
            if (subs.Contains(sub))
            {
                int index = subs.IndexOf(sub);
                sub.Unsubscribe();
                subs.RemoveAt(index);
            }

            throw new SubscriberNotFoundException("There is no suc subscriber in the list");
        }
    }
}
