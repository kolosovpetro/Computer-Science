using System;
using IteratorLibrary;

namespace IteratorConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            var library = new Library();
            var iterator = library.CreateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }

            iterator.Reset();

            Console.WriteLine("Even books");

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.NextEven());
            }

            // otherwise
            Console.WriteLine("Otherwise");

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
