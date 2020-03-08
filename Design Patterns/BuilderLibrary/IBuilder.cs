namespace BuilderLibrary
{
    interface IBuilder
    {
        ITransport transport { get; }
        void Reset();
        void SetParameters();
        ITransport Create();
    }
}
