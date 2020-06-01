using System;

namespace ObserverLibrary.Subscriber
{
    internal class SubscriberNotFoundException : Exception
    {
        public SubscriberNotFoundException(string message) : base(message)
        {

        }
    }
}
