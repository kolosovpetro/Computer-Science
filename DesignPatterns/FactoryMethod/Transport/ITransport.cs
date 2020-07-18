namespace FactoryMethod.Transport
{
    /// <summary>
    /// Common interface for all transport instances.
    /// </summary>
    internal interface ITransport
    {
        /// <summary>
        /// Common functionality of all transport. To be implemented differently for each class.
        /// </summary>
        string Ride();

    }
}
