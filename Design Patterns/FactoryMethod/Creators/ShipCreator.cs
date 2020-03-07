using System;

namespace FactoryMethod
{
    class ShipCreator : ICreator
    {
        public ITransport CreateTransport()
        {
            return new Ship();
        }
    }
}
