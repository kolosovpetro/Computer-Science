namespace FactoryMethod
{
    class Ship : ITransport
    {
        public string Ride()
        {
            return "I'm an instance of Ship. I'm sailing ...";
        }
    }
}
