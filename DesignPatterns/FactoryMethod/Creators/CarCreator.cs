namespace FactoryMethod
{
    class CarCreator : ICreator
    {
        public ITransport transport { get; private set; }

        public ITransport CreateTransport()
        {
            transport = new Car();
            return transport;
        }
    }
}
