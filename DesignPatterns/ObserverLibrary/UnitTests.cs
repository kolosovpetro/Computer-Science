using NUnit.Framework;
using ObserverLibrary.Publisher;
using ObserverLibrary.Subscriber;

namespace ObserverLibrary
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void SubscribeTest()
        {
            IPublisher p = new ConcretePublisher("New York Times");
            ISubscriber s = new ConcreteSubscriber();
            p.Subscribe(s);
            Assert.That(p.SubscribersCount, Is.EqualTo(1));
            Assert.That(s.IsSubscribed, Is.EqualTo(true));
            Assert.That(s.SubscribedTo, Is.EqualTo(p.Name));
        }

        [Test]
        public void NotifyTest()
        {
            IPublisher p = new ConcretePublisher("New York Times");
            ISubscriber s = new ConcreteSubscriber();
            p.Subscribe(s);
            p.NotifySubscribers("Economy grow is going on!!:)");
            Assert.That(s.Notification, Is.EqualTo("Economy grow is going on!!:)"));
        }
    }
}
