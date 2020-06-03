using System;

namespace IteratorLibrary
{
    public class Reader
    {
        public void SeeBooks(IBookNumerable library)
        {
            // reader gets numerator of library
            var iterator = library.CreateIterator();

            while(iterator.HasNext())
            {
                var book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
        
        public void SeeBooksEven(IBookNumerable library)
        {
            // reader gets numerator of library
            var iterator = library.CreateIterator();

            while(iterator.HasNext())
            {
                var book = iterator.NextEven();
                Console.WriteLine(book.Name);
            }
        }
    }
}
