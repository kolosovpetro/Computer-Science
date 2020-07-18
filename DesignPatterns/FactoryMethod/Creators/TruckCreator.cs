using FactoryMethod.Transport;

namespace FactoryMethod.Creators
{
    internal class TruckCreator : ICreator
    {
        public ITransport Transport { get; private set; }

        public ITransport CreateTransport()
        {
            Transport = new Truck();
            return Transport;
        }
    }
}
