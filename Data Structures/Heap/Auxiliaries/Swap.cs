using System.Collections.Generic;

namespace Heaps.Auxiliaries
{
    class Swap
    {
        public static void DoSwap(ref int A, ref int B)
        {
            (A, B) = (B, A);
        }
        public static void CollectionSwap(List<int> InitList, int index1, int index2)
        {
            (InitList[index1], InitList[index2]) = (InitList[index2], InitList[index1]);
        }
    }
}
