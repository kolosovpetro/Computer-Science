using BuilderLibrary.ConcreteVehicles;

namespace BuilderLibrary.ConcreteBuilders
{
    class MercedesBenzTruckBuilder : IBuilder
    {
        public ITransport transport { get; private set; }

        public ITransport Create()
        {
            SetParameters();
            return transport;
        }

        public void Reset()
        {
            transport = new MercedesBenzTruck();
        }

        public void SetParameters()
        {
            Reset();
            transport.SetManufacturer("Mercedes-Benz");
            transport.SetModel("Actors SLT");
            transport.SetEngine("Mercedes-benz Engine");
            transport.SetEngineVolume(100.0);
            transport.SetCylinderNumber(14);
            transport.SetWheelsNumber(12);
            transport.SetTankCapacity(200);
            transport.SetMaxSpeed(120);
        }
    }
}
