using AdapterLibrary.Animal;
using AdapterLibrary.Transport;
using NUnit.Framework;

namespace AdapterLibrary
{
    [TestFixture]
    internal class UnitTests
    {
        private readonly ITransport _transport = new Auto();
        private readonly Driver _driver = new Driver();
        private readonly IAnimal _camel = new Camel();

        [Test]
        public void DriverTransportTest()
        {
            var rideMessage = _driver.Travel(_transport);
            Assert.That(rideMessage, Is.EqualTo("Auto is moving by the road"));
        }

        [Test]
        public void DriverCamelTest()
        {
            ITransport camelAdapter = new TransportToAnimalAdapter(_camel);
            var rideMessage = _driver.Travel(camelAdapter);
            Assert.That(rideMessage, Is.EqualTo("Camel is moving through the sands"));
        }
    }
}
