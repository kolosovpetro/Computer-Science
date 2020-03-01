using System.Collections.Generic;

namespace Trees.LINQ
{
    interface ILinq<T>
    {
        IEnumerable<T> NumbersFromCollection(IEnumerable<T> Collection);
        IEnumerable<T> CollectionSubset(IEnumerable<T> Collection, int StartIndex, int EndIndex);
        IEnumerable<string> SubsetThatConsist(IEnumerable<string> Collection, string Item);
    }
}
