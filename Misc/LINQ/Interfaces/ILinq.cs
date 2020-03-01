using System.Collections.Generic;

namespace LINQ_Practice
{
    interface ILinq<T>
    {
        void PrintCollection(IEnumerable<T> enumer, bool inline = false);
        void PrintCollection(IEnumerable<dynamic> enumer, bool inline = false);
        IEnumerable<T> NumbersFromCollection(IEnumerable<T> Collection);
        IEnumerable<T> CollectionSubset(IEnumerable<T> Collection, int StartIndex, int EndIndex);
        IEnumerable<string> SubsetThatConsist(IEnumerable<string> Collection, string Item);
        void GenericSwap(IEnumerable<T> Collection, int LeftIndex, int RightIndex);
    }
}
