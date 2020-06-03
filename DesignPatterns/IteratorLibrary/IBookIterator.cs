namespace IteratorLibrary
{
    public interface IBookIterator
    {
        void Reset();
        bool HasNext();
        Book Next();
        bool HasNextEven();
        Book NextEven();
    }
}
