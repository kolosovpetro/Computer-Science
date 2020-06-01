using System;

namespace FactoryMethod
{
    class ShipCreator : ICreator
    {
        public ITransport transport { get; private set; }

        public ITransport CreateTransport()
        {
            transport = new Ship();
            return transport;
        }
    }
}
