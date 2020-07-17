using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class BinarySearch : AbstractSearch
    {
        public BinarySearch(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        {
        }

        public override bool DoSearch()
        {
            return ExecuteBinarySearch(Array, SearchValue);
        }

        private static bool ExecuteBinarySearch(IReadOnlyList<int> array, int searchValue)
        {
            var min = 0;
            var max = array.Count - 1;

            while (min <= max)
            {
                var mid = (min + max) / 2;

                if (searchValue == array[mid]) return true;

                if (searchValue < array[mid]) max = mid - 1;

                else min = mid + 1;
            }

            return false;
        }
    }
}