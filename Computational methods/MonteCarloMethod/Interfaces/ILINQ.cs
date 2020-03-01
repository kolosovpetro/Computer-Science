using System.Collections.Generic;

namespace MonteCarloMethod.Interfaces
{
    interface ILINQ<T>
    {
        void PrintCollection(IEnumerable<T> Collection, bool Inline = false);
        void PrintCollection(IEnumerable<dynamic> Collection, bool Inline = false);
        IEnumerable<T> NumbersFromCollection(IEnumerable<T> Collection);
        IEnumerable<T> CollectionSubset(IEnumerable<T> Collection, int StartIndex, int EndIndex);
        IEnumerable<string> SubsetThatConsist(IEnumerable<string> Collection, string Item);
        void GenericSwap(IEnumerable<T> Collection, int LeftIndex, int RightIndex);
    }
}
