using System.Collections.Generic;

namespace MonteCarloMethod.Interfaces
{
    internal interface ILinq<T>
    {
        void PrintCollection(IEnumerable<T> enumerable, bool inline = false);
        void PrintCollection(IEnumerable<dynamic> enumerable, bool inline = false);
        IEnumerable<T> NumbersFromCollection(IEnumerable<T> collection);
        IEnumerable<T> CollectionSubset(IEnumerable<T> collection, int startIndex, int endIndex);
        IEnumerable<string> SubsetThatConsist(IEnumerable<string> collection, string item);
        void GenericSwap(IEnumerable<T> collection, int leftIndex, int rightIndex);
    }
}
