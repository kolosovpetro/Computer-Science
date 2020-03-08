using BuilderLibrary.ConcreteBuilders;
using NUnit.Framework;

namespace BuilderLibrary
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void BmwTest()
        {
            IBuilder b = new BmwBuilder();
            ITransport bmw = b.Create();
            Assert.That(bmw.Manufacturer, Is.EqualTo("BMW"));
            Assert.That(bmw.Model, Is.EqualTo("BMW M3 GTR"));
            Assert.That(bmw.Engine, Is.EqualTo("BMW M3-Series Engine"));
            Assert.That(bmw.EngineVolume, Is.EqualTo(5.0));
            Assert.That(bmw.CylindersNumber, Is.EqualTo(8));
            Assert.That(bmw.WheelsNumber, Is.EqualTo(4));
            Assert.That(bmw.FuelTankCapacity, Is.EqualTo(50));
            Assert.That(bmw.MaxSpeed, Is.EqualTo(200));
        }
        
        [Test]
        public void VolvoExcavatorTest()
        {
            IBuilder b = new VolveExcavatorBuilder();
            ITransport volvoExcavator = b.Create();
            Assert.That(volvoExcavator.Manufacturer, Is.EqualTo("Volvo"));
            Assert.That(volvoExcavator.Model, Is.EqualTo("EC950F"));
            Assert.That(volvoExcavator.Engine, Is.EqualTo("Volvo Engine"));
            Assert.That(volvoExcavator.EngineVolume, Is.EqualTo(20.0));
            Assert.That(volvoExcavator.CylindersNumber, Is.EqualTo(12));
            Assert.That(volvoExcavator.WheelsNumber, Is.EqualTo(0));
            Assert.That(volvoExcavator.FuelTankCapacity, Is.EqualTo(200));
            Assert.That(volvoExcavator.MaxSpeed, Is.EqualTo(60));
        }
        
        [Test]
        public void YamahaTest()
        {
            IBuilder b = new YamahaBuilder();
            ITransport yamaha = b.Create();
            Assert.That(yamaha.Manufacturer, Is.EqualTo("Yamaha"));
            Assert.That(yamaha.Model, Is.EqualTo("MT09"));
            Assert.That(yamaha.Engine, Is.EqualTo("Yamaha Engine"));
            Assert.That(yamaha.EngineVolume, Is.EqualTo(3.0));
            Assert.That(yamaha.CylindersNumber, Is.EqualTo(4));
            Assert.That(yamaha.WheelsNumber, Is.EqualTo(2));
            Assert.That(yamaha.FuelTankCapacity, Is.EqualTo(10));
            Assert.That(yamaha.MaxSpeed, Is.EqualTo(200));
        }

        [Test]
        public void MercedesTruckTest()
        {
            IBuilder b = new MercedesBenzTruckBuilder();
            ITransport mercedesTruck = b.Create();
            Assert.That(mercedesTruck.Manufacturer, Is.EqualTo("Mercedes-Benz"));
            Assert.That(mercedesTruck.Model, Is.EqualTo("Actors SLT"));
            Assert.That(mercedesTruck.Engine, Is.EqualTo("Mercedes-benz Engine"));
            Assert.That(mercedesTruck.EngineVolume, Is.EqualTo(100.0));
            Assert.That(mercedesTruck.CylindersNumber, Is.EqualTo(14));
            Assert.That(mercedesTruck.WheelsNumber, Is.EqualTo(12));
            Assert.That(mercedesTruck.FuelTankCapacity, Is.EqualTo(200));
            Assert.That(mercedesTruck.MaxSpeed, Is.EqualTo(120));
        }
    }
}
