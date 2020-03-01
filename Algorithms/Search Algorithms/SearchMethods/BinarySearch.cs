using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    class BinarySearch : AbstractSearch
    {
        public BinarySearch(IEnumerable<int> newCollection, int newSearchValue) : base(newCollection, newSearchValue)
        { }

        public override bool DoSearch()
        {
            return BinarySearching(Array, SearchValue);
        }

        private bool BinarySearching(int[] Array, int SearchValue)
        {
            int min = 0;
            int max = Array.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (SearchValue == Array[mid]) return true;

                else if (SearchValue < Array[mid]) max = mid - 1;

                else min = mid + 1;
            }

            return false;
        }
    }
}
