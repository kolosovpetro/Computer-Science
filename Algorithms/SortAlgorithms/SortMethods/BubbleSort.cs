using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class BubbleSort : AbstractSort
    {
        public BubbleSort(IEnumerable<int> collection) : base(collection) { }
        public BubbleSort(AbstractArray array) : base(array) { }

        public override void GetSortedArray()
        {
            SortedArray = DoBubbleSort(InitArray);
        }

        private static int[] DoBubbleSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                for (var j = array.Length - 1; j > 1; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        Swap.DoSwap(ref array[j], ref array[j - 1]);
                    }
                }
            }

            return array;
        }
    }
}
