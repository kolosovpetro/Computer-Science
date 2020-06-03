using System;
using IteratorLibrary;

namespace IteratorConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);

            // otherwise

            Book[] books = {
                new Book{Name="Война и мир"},
                new Book {Name="Отцы и дети"},
                new Book {Name="Вишневый сад"}
            };

            var enumerator = books.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
