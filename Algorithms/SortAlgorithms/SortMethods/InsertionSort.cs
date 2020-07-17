using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class InsertionSort : AbstractSort
    {
        public InsertionSort(IEnumerable<int> collection) : base(collection) { }
        public InsertionSort(AbstractArray array) : base(array) { }

        public override void GetSortedArray()
        {
            SortedArray = DoInsertionSort(InitArray);
        }

        private static int[] DoInsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 1 && array[j - 1] > array[j])
                {
                    Swap.DoSwap(ref array[j], ref array[j - 1]);
                    j--;
                }
            }

            return array;
        }
    }
}
