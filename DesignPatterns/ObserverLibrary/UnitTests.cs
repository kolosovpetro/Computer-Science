using NUnit.Framework;

namespace ObserverLibrary
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void SubscribeTest()
        {
            IPublisher p = new Publisher("Kurier Nedeli");
            ISubscriber s = new Subscriber();
            p.Subscribe(s);
            Assert.That(p.SubsCount, Is.EqualTo(1));
            Assert.That(s.IsSubscribed, Is.EqualTo(true));
            Assert.That(s.SubscriberOf, Is.EqualTo(p.Name));
        }
        
        [Test]
        public void NotifyTest()
        {
            IPublisher p = new Publisher("Kurier Nedeli");
            ISubscriber s = new Subscriber();
            p.Subscribe(s);
            p.NotifySubscribers("New arrivals! Hurry to buy!");
            Assert.That(s.NewNotification, Is.EqualTo("New arrivals! Hurry to buy!"));
        }
    }
}
