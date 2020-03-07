namespace FactoryMethod
{
    class CarCreator : ICreator
    {
        public ITransport CreateTransport()
        {
            return new Car();
        }
    }
}
