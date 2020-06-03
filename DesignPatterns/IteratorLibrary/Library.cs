namespace IteratorLibrary
{
    public class Library : IBookNumerable
    {
        // collection of books in library
        private readonly Book[] _books;

        // composition in constructor
        public Library()
        {
            _books = new[]
            {
                new Book{Name="Война и мир"},
                new Book {Name="Отцы и дети"},
                new Book {Name="Вишневый сад"}
            };
        }

        // property gives the total count of books in library
        public int Count => _books.Length;

        // implementation of indexer
        public Book this[int index] => _books[index];

        // numerator (or iterator) factory
        public IBookIterator CreateIterator()
        {
            return new LibraryIterator(this);
        }
    }
}
