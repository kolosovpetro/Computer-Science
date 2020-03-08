namespace BuilderLibrary.ConcreteBuilders
{
    class BmwBuilder : IBuilder
    {
        public ITransport transport { get; private set; }

        public ITransport Create()
        {
            SetParameters();
            return transport;
        }

        public void Reset()
        {
            transport = new BMW();
        }

        public void SetParameters()
        {
            Reset();
            transport.SetManufacturer("BMW");
            transport.SetModel("BMW M3 GTR");
            transport.SetEngine("BMW M3-Series Engine");
            transport.SetEngineVolume(5.0);
            transport.SetCylinderNumber(8);
            transport.SetWheelsNumber(4);
            transport.SetTankCapacity(50);
            transport.SetMaxSpeed(200);
        }
    }
}
