using FactoryMethod.Transport;

namespace FactoryMethod.Creators
{
    /// <summary>
    /// Common interface for Transport creator classes.
    /// </summary>
    internal interface ICreator
    {
        ITransport Transport { get; }
        /// <summary>
        /// Returns instance implementing interface ITransport
        /// </summary>
        /// <returns></returns>
        ITransport CreateTransport();
    }
}
