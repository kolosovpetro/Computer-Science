using FactoryMethod.Transport;

namespace FactoryMethod.Creators
{
    internal class ShipCreator : ICreator
    {
        public ITransport Transport { get; private set; }

        public ITransport CreateTransport()
        {
            Transport = new Ship();
            return Transport;
        }
    }
}
