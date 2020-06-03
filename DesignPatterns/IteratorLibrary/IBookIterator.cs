namespace IteratorLibrary
{
    public interface IBookIterator
    {
        void Reset();
        bool HasNext();
        Book Next();
        Book NextEven();
    }
}
