using System.Collections.Generic;

namespace Linq
{
    static class IEnumerableExtensions
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> enumerable, int index, T value)
        {
            int current = 0;
            foreach (var item in enumerable)
            {
                yield return current == index ? value : item;
                current++;
            }
        }
    }
}
