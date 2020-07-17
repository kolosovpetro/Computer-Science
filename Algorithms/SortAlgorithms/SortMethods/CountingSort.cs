using System.Collections.Generic;
using System.Linq;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class CountingSort : AbstractSort
    {
        public CountingSort(IEnumerable<int> collection) : base(collection) { }
        public CountingSort(AbstractArray array) : base(array) { }

        public override void GetSortedArray()
        {
            SortedArray = DoCountingSort(InitArray);
        }

        private static int[] DoCountingSort(int[] array)
        {
            var Sort = new int[array.Length];

            var Min = array.Min();
            var Max = array.Max();

            var Counts = new int[Max - Min + 1];

            foreach (var term in array)
                Counts[term - Min]++;

            Counts[0]--;
            for (var i = 1; i < Counts.Length; i++)
                Counts[i] += Counts[i - 1];

            for (var i = array.Length - 1; i >= 0; i--)
                Sort[Counts[array[i] - Min]--] = array[i];

            return Sort;
        }
    }
}
