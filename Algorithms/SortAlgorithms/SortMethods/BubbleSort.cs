using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class BubbleSort : AbstractSort
    {
        public BubbleSort(IEnumerable<int> Collection) : base(Collection) { }
        public BubbleSort(AbstractArray newAbsArray) : base(newAbsArray) { }

        public override void GetSortedArray()
        {
            SortedArray = DoBubbleSort(InitArray);
        }

        private int[] DoBubbleSort(int[] Array)
        {
            for (int i = 1; i < Array.Length; i++)
            {
                for (int j = Array.Length - 1; j > 1; j--)
                {
                    if (Array[j] < Array[j - 1])
                    {
                        Swap.DoSwap(ref Array[j], ref Array[j - 1]);
                    }
                }
            }

            return Array;
        }
    }
}
