using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Publisher
    {
        List<ISubscriber> Subscribers = new List<ISubscriber>();
        string MainState;
        public void Subscribe(ISubscriber subscriber)
        {
            Subscribers.Add(subscriber);
            subscriber.Update($"I currently subscribed to {this.GetType()}.");
        }
        public void Unsubscribe(ISubscriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }
        public void NotifySubscribers()
        {
            foreach (ISubscriber subscriber in Subscribers)
            {
                subscriber.Update(MainState);
            }
        }
        public void BusinessLogics(string newMainState)
        {
            this.MainState = newMainState;
            NotifySubscribers();
        }
    }
}
