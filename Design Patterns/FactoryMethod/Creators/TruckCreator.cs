namespace FactoryMethod
{
    class TruckCreator : ICreator
    {
        public ITransport CreateTransport()
        {
            return new Truck();
        }
    }
}
