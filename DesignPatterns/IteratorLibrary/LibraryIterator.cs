namespace IteratorLibrary
{
    public class LibraryIterator : IBookIterator
    {
        // collection we work on
        private readonly IBookNumerable _aggregate;

        // index of current element of collection
        private int _index;

        // aggregate collection in constructor
        public LibraryIterator(IBookNumerable a)
        {
            _aggregate = a;
        }

        // method to check if there is more items in collection
        public bool HasNext()
        {
            return _index < _aggregate.Count;
        }

        public bool HasNextEven()
        {
            return _index < _aggregate.Count;
        }

        // returns next item of collection
        public Book Next()
        {
            return _aggregate[_index++];
        }

        public Book NextEven()
        {
            var temp = _index;
            _index += 2;
            return _aggregate[temp];
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
