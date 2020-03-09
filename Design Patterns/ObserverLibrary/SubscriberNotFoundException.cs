using System;

namespace ObserverLibrary
{
    class SubscriberNotFoundException : Exception
    {
        public SubscriberNotFoundException()
        {

        }

        public SubscriberNotFoundException(string message) : base(message)
        {

        }
    }
}
