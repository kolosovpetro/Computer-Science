using BuilderLibrary.ConcreteVehicles;

namespace BuilderLibrary.ConcreteBuilders
{
    class YamahaBuilder : IBuilder
    {
        public ITransport transport { get; private set; }

        public ITransport Create()
        {
            SetParameters();
            return transport;
        }

        public void Reset()
        {
            transport = new Yamaha();
        }

        public void SetParameters()
        {
            Reset();
            transport.SetManufacturer("Yamaha");
            transport.SetModel("MT09");
            transport.SetEngine("Yamaha Engine");
            transport.SetEngineVolume(3.0);
            transport.SetCylinderNumber(4);
            transport.SetWheelsNumber(2);
            transport.SetTankCapacity(10);
            transport.SetMaxSpeed(200);
        }
    }
}
