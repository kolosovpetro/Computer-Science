using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class SelectionSort : AbstractSort
    {
        public SelectionSort(IEnumerable<int> Collection) : base(Collection) { }
        public SelectionSort(AbstractArray newAbsArray) : base(newAbsArray) { }

        public override void GetSortedArray()
        {
            SortedArray = DoSelectionSort(InitArray);
        }

        private int[] DoSelectionSort(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                int MinIndex = i;

                for (int j = i + 1; j < Array.Length; j++)
                {
                    MinIndex = Array[MinIndex] < Array[j] ? MinIndex : j;
                }

                Swap.DoSwap(ref Array[i], ref Array[MinIndex]);
            }

            return Array;
        }
    }
}
