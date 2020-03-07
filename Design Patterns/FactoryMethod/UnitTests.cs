using NUnit.Framework;

namespace FactoryMethod
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void CarTest()
        {
            ICreator c = new CarCreator();
            ITransport t = c.CreateTransport();
            Assert.That(t.Ride(), Is.EqualTo("I'm instance of type Car. I riding ..."));
            Assert.That(t.GetType().Name, Is.EqualTo("Car"));
        }

        [Test]
        public void TruckTest()
        {
            ICreator c = new TruckCreator();
            ITransport t = c.CreateTransport();
            Assert.That(t.Ride(), Is.EqualTo("I'm an instance of Truck. I'm riding ... "));
            Assert.That(t.GetType().Name, Is.EqualTo("Truck"));
        }
        
        [Test]
        public void ShipTest()
        {
            ICreator c = new ShipCreator();
            ITransport t = c.CreateTransport();
            Assert.That(t.Ride(), Is.EqualTo("I'm an instance of Ship. I'm sailing ..."));
            Assert.That(t.GetType().Name, Is.EqualTo("Ship"));
        }
    }
}
