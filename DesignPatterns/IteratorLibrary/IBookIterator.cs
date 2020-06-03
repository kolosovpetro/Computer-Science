namespace IteratorLibrary
{
    public interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
}
