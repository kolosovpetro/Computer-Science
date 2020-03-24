using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class LinqMethods<T> : ILinqLibrary<T>
    {
        public IEnumerable<T> CollectionExcept(IEnumerable<T> mainCollection, IEnumerable<T> exceptCollection)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> JoinCollections(IEnumerable<T> c1, IEnumerable<T> c2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Parseable(IEnumerable<T> collection)
        {
            return collection.Where(g => int.TryParse(g.ToString(), out int res));
        }

        public void RemoveAll(IEnumerable<T> collection, T term)
        {
            throw new NotImplementedException();
        }

        public void ReplaceAll(IEnumerable<T> collection, T oldTerm, T newTerm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Subset(IEnumerable<T> collection, int startIndex, int endIndex)
        {
            return collection.Skip(startIndex).Take(endIndex);
        }

        public void Swap(IEnumerable<T> collection, int leftIndex, int rightIndex)
        {
            throw new NotImplementedException();
        }

        public int TermCount(IEnumerable<T> collection, T term)
        {
            return collection.Where(g => g.Equals(term)).Count();
        }
    }
}
