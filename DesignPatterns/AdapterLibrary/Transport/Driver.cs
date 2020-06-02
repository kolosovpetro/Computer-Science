namespace AdapterLibrary.Transport
{
    internal class Driver
    {
        public string Travel(ITransport transport)
        {
            return transport.Drive();
        }
    }
}
