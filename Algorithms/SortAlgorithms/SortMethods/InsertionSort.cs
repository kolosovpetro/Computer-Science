using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    class InsertionSort : AbstractSort
    {
        public InsertionSort(IEnumerable<int> Collection) : base(Collection) { }
        public InsertionSort(AbstractArray newAbsArray) : base(newAbsArray) { }
        public override void GetSortedArray()
        {
            SortedArray = DoInsertionSort(InitArray);
        }
        private int[] DoInsertionSort(int[] Array)
        {
            for (int i = 1; i < Array.Length; i++)
            {
                int j = i;
                while (j > 1 && Array[j - 1] > Array[j])
                {
                    Swap.DoSwap(ref Array[j], ref Array[j - 1]);
                    j--;
                }
            }
            return Array;
        }
    }
}
