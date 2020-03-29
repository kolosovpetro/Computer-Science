using System.Collections.Generic;
using System.Linq;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class CountingSort : AbstractSort
    {
        public CountingSort(IEnumerable<int> Collection) : base(Collection) { }
        public CountingSort(AbstractArray newAbsArray) : base(newAbsArray) { }

        public override void GetSortedArray()
        {
            SortedArray = DoCountingSort(InitArray);
        }

        private int[] DoCountingSort(int[] Array)
        {
            int[] Sort = new int[Array.Length];

            int Min = Array.Min();
            int Max = Array.Max();

            int[] Counts = new int[Max - Min + 1];

            foreach (var term in Array)
                Counts[term - Min]++;

            Counts[0]--;
            for (int i = 1; i < Counts.Length; i++)
                Counts[i] += Counts[i - 1];

            for (int i = Array.Length - 1; i >= 0; i--)
                Sort[Counts[Array[i] - Min]--] = Array[i];

            return Sort;
        }
    }
}
