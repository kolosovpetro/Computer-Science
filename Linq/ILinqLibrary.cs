using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    interface ILinqLibrary<T>
    {
        // get only numbers from collection

        IEnumerable<T> Parseable(IEnumerable<T> collection);

        // find how many terms t appears in collection s

        int TermCount(IEnumerable<T> collection, T term);

        // get collection's subset in range a,b

        IEnumerable<T> Subset(IEnumerable<T> collection, int startIndex, int endIndex);

        // generic swap

        void Swap(IEnumerable<T> collection, int leftIndex, int rightIndex);

        // remove all terms t from collection s

        void RemoveAll(IEnumerable<T> collection, T term);

        // replace all terms t from collection s

        void ReplaceAll(IEnumerable<T> collection, T oldTerm, T newTerm);

        // join two collections togather

        IEnumerable<T> JoinCollections(IEnumerable<T> c1, IEnumerable<T> c2);

        // exclude all items t of collection s from collection p

        IEnumerable<T> CollectionExcept(IEnumerable<T> mainCollection, IEnumerable<T> exceptCollection);

        //
    }
}
