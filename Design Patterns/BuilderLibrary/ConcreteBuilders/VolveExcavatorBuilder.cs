using BuilderLibrary.ConcreteVehicles;

namespace BuilderLibrary.ConcreteBuilders
{
    class VolveExcavatorBuilder : IBuilder
    {
        public ITransport transport { get; private set; }

        public ITransport Create()
        {
            SetParameters();
            return transport;
        }

        public void Reset()
        {
            transport = new VolvoExcavator();
        }

        public void SetParameters()
        {
            Reset();
            transport.SetManufacturer("Volvo");
            transport.SetModel("EC950F");
            transport.SetEngine("Volvo Engine");
            transport.SetEngineVolume(20.0);
            transport.SetCylinderNumber(12);
            transport.SetWheelsNumber(0);
            transport.SetTankCapacity(200);
            transport.SetMaxSpeed(60);
        }
    }
}
