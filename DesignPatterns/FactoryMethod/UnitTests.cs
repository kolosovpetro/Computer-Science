using FactoryMethod.Creators;
using FactoryMethod.Transport;
using NUnit.Framework;

namespace FactoryMethod
{
    [TestFixture]
    internal class UnitTests
    {
        private ITransport _transport;
        private ICreator _creator;

        [Test]
        public void CarTest()
        {
            _creator = new CarCreator();
            _transport = _creator.CreateTransport();
            Assert.That(_transport.Ride(), Is.EqualTo("I'm instance of type Car. I riding ..."));
            Assert.That(_transport.GetType().Name, Is.EqualTo("Car"));
        }

        [Test]
        public void TruckTest()
        {
            _creator = new TruckCreator();
            _transport = _creator.CreateTransport();
            Assert.That(_transport.Ride(), Is.EqualTo("I'm an instance of Truck. I'm riding ... "));
            Assert.That(_transport.GetType().Name, Is.EqualTo("Truck"));
        }

        [Test]
        public void ShipTest()
        {
            _creator = new ShipCreator();
            _transport = _creator.CreateTransport();
            Assert.That(_transport.Ride(), Is.EqualTo("I'm an instance of Ship. I'm sailing ..."));
            Assert.That(_transport.GetType().Name, Is.EqualTo("Ship"));
        }
    }
}