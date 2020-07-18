using FactoryMethod.Transport;

namespace FactoryMethod.Creators
{
    internal class CarCreator : ICreator
    {
        public ITransport Transport { get; private set; }

        public ITransport CreateTransport()
        {
            Transport = new Car();
            return Transport;
        }
    }
}
