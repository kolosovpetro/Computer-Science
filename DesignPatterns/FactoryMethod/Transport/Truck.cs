namespace FactoryMethod.Transport
{
    internal class Truck : ITransport
    {
        public string Ride()
        {
            return "I'm an instance of Truck. I'm riding ... ";
        }
    }
}