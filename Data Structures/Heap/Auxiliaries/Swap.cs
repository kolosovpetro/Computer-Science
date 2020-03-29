using System.Collections.Generic;

namespace Heaps.Auxiliaries
{
    internal class Swap
    {
        public static void CollectionSwap(List<int> InitList, int index1, int index2)
        {
            (InitList[index1], InitList[index2]) = (InitList[index2], InitList[index1]);
        }
    }
}
