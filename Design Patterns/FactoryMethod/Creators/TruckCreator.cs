namespace FactoryMethod
{
    class TruckCreator : ICreator
    {
        public ITransport transport { get; private set; }

        public ITransport CreateTransport()
        {
            transport = new Truck();
            return transport;
        }
    }
}
