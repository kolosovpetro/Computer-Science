using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class LinqMethods<T> : ILinqLibrary<T>
    {
        public IEnumerable<T> CollectionExcept(IEnumerable<T> mainCollection, IEnumerable<T> exceptCollection)
        {
            return mainCollection.Except(exceptCollection);
        }

        public IEnumerable<T> JoinCollections(IEnumerable<T> c1, IEnumerable<T> c2)
        {
            return c1.Concat(c2);       // concat much simpler than this method
        }

        public IEnumerable<T> Parseable(IEnumerable<T> collection)
        {
            return collection.Where(g => int.TryParse(g.ToString(), out int res));
        }

        public IEnumerable<T> RemoveAll(IEnumerable<T> collection, T term)
        {
            return collection.Where(p => !p.Equals(term));
        }

        public IEnumerable<T> ReplaceAll(IEnumerable<T> collection, T oldTerm, T newTerm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Subset(IEnumerable<T> collection, int startIndex, int endIndex)
        {
            return collection.Skip(startIndex).Take(endIndex);
        }

        public IEnumerable<T> Swap(IEnumerable<T> collection, int leftIndex, int rightIndex)
        {
            T[] tempCollection = collection.ToArray();
            T temp = tempCollection[leftIndex];
            tempCollection[leftIndex] = tempCollection[rightIndex];
            tempCollection[rightIndex] = temp;
            return tempCollection;
        }

        public int TermCount(IEnumerable<T> collection, T term)
        {
            return collection.Where(g => g.Equals(term)).Count();
        }

        
    }
}
