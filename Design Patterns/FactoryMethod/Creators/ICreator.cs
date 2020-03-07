namespace FactoryMethod
{
    /// <summary>
    /// Common interface for Transpor creator classes.
    /// </summary>
    interface ICreator
    {
        /// <summary>
        /// Returns instance implementing interface ITransport
        /// </summary>
        /// <returns></returns>
        ITransport CreateTransport();
    }
}
