namespace FactoryMethod.Transport
{
    internal class Car : ITransport
    {
        public string Ride()
        {
            return "I'm instance of type Car. I riding ...";
        }
    }
}
