using System.Collections.Generic;
using System.Linq;

namespace Queue.Auxiliaries
{
    class Swap<T>
    {
        public static void DoSwap(ref int A, ref int B)
        {
            (A, B) = (B, A);
        }
        
        public static void GenericSwap(IEnumerable<T> Collection, int LeftIndex, int RightIndex)
        {
            List<T> newCollection = Collection.ToList();
            T Temp = newCollection[LeftIndex];
            newCollection[LeftIndex] = newCollection[RightIndex];
            newCollection[RightIndex] = Temp;

        }
    }
}
